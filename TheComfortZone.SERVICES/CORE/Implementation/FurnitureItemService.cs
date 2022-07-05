using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Charts;
using TheComfortZone.DTO.FurnitureItem;
using TheComfortZone.SERVICES.API;
using TheComfortZone.SERVICES.CORE.Utils;
using TheComfortZone.SERVICES.DAO;
using TheComfortZone.SERVICES.DAO.Model;

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class FurnitureItemService : BaseCRUDService<FurnitureItemResponse, DAO.Model.FurnitureItem, FurnitureItemSearchRequest, FurnitureItemUpsertRequest, FurnitureItemUpsertRequest>, IFurnitureItemService
    {
        public FurnitureItemService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<FurnitureItem> IncludeList(IQueryable<FurnitureItem> query)
        {
            query = query.Include(x => x.Category.Space)
                .Include(x => x.Collection.Designer)
                .Include(x => x.Material)
                .Include(x => x.MetricUnit)
                .Include("FurnitureColors.Color");
            return query;
        }

        public override IQueryable<FurnitureItem> AddFilter(IQueryable<FurnitureItem> query, FurnitureItemSearchRequest search = null)
        {
            if (!string.IsNullOrWhiteSpace(search?.Name))
                query = query.Where(x => x.Name.ToLower().StartsWith(search.Name.ToLower()));
            if (search?.SpaceId.HasValue == true)
                query = query.Where(x => x.Category.SpaceId == search.SpaceId);
            if (search?.CategoryId.HasValue == true)
                query = query.Where(x => x.CategoryId == search.CategoryId);
            if (!string.IsNullOrWhiteSpace(search?.State))
                query = query.Where(x => x.State == search.State);

            return query;
        }

        public async override Task<FurnitureItemResponse> Insert(FurnitureItemUpsertRequest insert)
        {
            var entity = await base.Insert(insert);
            if (insert?.ColorIdList != null)
            {
                foreach (int colorId in insert.ColorIdList)
                {
                    DAO.Model.FurnitureColor furnitureColor = new DAO.Model.FurnitureColor();
                    furnitureColor.FurnitureItemId = entity.FurnitureItemId;
                    furnitureColor.ColorId = colorId;
                    context.FurnitureColors.Add(furnitureColor);
                }
            }
            context.SaveChanges();
            return entity;
        }

        public override void BeforeInsert(FurnitureItemUpsertRequest insert, FurnitureItem entity)
        {
            base.BeforeInsert(insert, entity);
        }

        public override void BeforeUpdate(FurnitureItem entity, FurnitureItemUpsertRequest update)
        {
            if (update?.ColorIdList != null)
            {
                var colors = context.FurnitureColors.Where(fc => fc.FurnitureItemId == entity.FurnitureItemId).ToList();
                context.RemoveRange(colors);

                foreach (int colorId in update.ColorIdList)
                {
                    DAO.Model.FurnitureColor furnitureColor = new DAO.Model.FurnitureColor();
                    furnitureColor.FurnitureItemId = entity.FurnitureItemId;
                    furnitureColor.ColorId = colorId;
                    context.FurnitureColors.Add(furnitureColor);
                }
            }
        }

        public override void BeforeDelete(int id)
        {
            List<int> orderIds = context.OrderItems.Where(oi => oi.FurnitureItemId == id).Select(oi => oi.OrderId).ToList();

            List<DAO.Model.FurnitureColor> furnitureColors = context.FurnitureColors.Where(fc => fc.FurnitureItemId == id).ToList();
            List<DAO.Model.OrderItem> orderItems = context.OrderItems.Where(oi => orderIds.Contains(oi.OrderId)).ToList();
            List<DAO.Model.Favourite> favourites = context.Favourites.Where(f => f.FurnitureItemId == id).ToList();

            context.RemoveRange(furnitureColors);
            context.RemoveRange(orderItems);
            context.RemoveRange(favourites);

            var orders = context.Orders.Where(o => orderIds.Contains(o.OrderId)).ToList();

            context.RemoveRange(orders);

            context.SaveChanges();
        }

        public async Task<List<FurnitureItemResponse>> GetFurnitureItemsUserData(int id, FurnitureItemSearchRequest search = null)
        {
            IEnumerable<FurnitureItemResponse> response = await Get(search);
            List<FurnitureItemResponse> responseList = response.ToList();

            List<int> favorites = context.Favourites.Where(x => x.UserId == id).Select(x => x.FurnitureItemId).ToList();


            foreach (var item in responseList)
                if (favorites.Contains(item.FurnitureItemId)) item.Favourited = true;

            return response.ToList();
        }

        public async Task<string> LikeFurnitureItem(int userId, int furnitureItemId)
        {
            /** VALIDATION **/
            StringBuilder stringBuilder = new StringBuilder();
            bool exception = false;
            if (context.Users.Find(userId) == null)
            {
                exception = true;
                stringBuilder.Append("User with specified ID does not exist!\n");
            }
            if (context.FurnitureItems.Find(furnitureItemId) == null)
            {
                exception = true;
                stringBuilder.Append("Furniture item with specified ID does not exist!\n");
            }
            if (exception)
            {
                throw new UserException(stringBuilder.ToString());
            }

            bool condition = context.Favourites.Where(x => x.UserId == userId && x.FurnitureItemId == furnitureItemId).Count() == 0;
            if (!condition)
                throw new UserException("This item is already in Favourites!");

            Favourite favourite = new Favourite()
            {
                UserId = userId,
                FurnitureItemId = furnitureItemId,
            };
            context.Favourites.Add(favourite);
            context.SaveChanges();

            string response = "Liked item is added in your Favourites section!";

            return response;
        }

        public async Task<List<FurnitureItemResponse>> GetFavourites(int userId, FurnitureItemSearchRequest search = null)
        {
            var query = context.Favourites
                .Where(x => x.UserId == userId)
                .Include(x => x.FurnitureItem.Category)
                .Include(x => x.FurnitureItem.Category.Space)
                .Include(x => x.FurnitureItem.Collection)
                .Include(x => x.FurnitureItem.Collection.Designer)
                .Include(x => x.FurnitureItem.MetricUnit)
                .Include(x => x.FurnitureItem.Material)
                .Include(x => x.FurnitureItem.FurnitureColors)
                .ThenInclude(y => y.Color)
                .Select(x => x.FurnitureItem)
                .AsQueryable();
            query = AddFilter(query, search);

            return mapper.Map<List<FurnitureItemResponse>>(query.ToList());
        }
        public async Task<string> DeleteFavourite(int userId, int furnitureItemId)
        {
            /** VALIDATION **/
            StringBuilder stringBuilder = new StringBuilder();
            bool exception = false;
            if (context.Users.Find(userId) == null)
            {
                exception = true;
                stringBuilder.Append("User with specified ID does not exist!\n");
            }
            if (context.FurnitureItems.Find(furnitureItemId) == null)
            {
                exception = true;
                stringBuilder.Append("Furniture item with specified ID does not exist!\n");
            }
            if (context.Favourites.Where(x => x.UserId == userId && x.FurnitureItemId == furnitureItemId).Single() == null)
            {
                exception = true;
                stringBuilder.Append("Combination of IDs does not exist!\n");
            }
            if (exception)
            {
                throw new UserException(stringBuilder.ToString());
            }

            Favourite favourite = context.Favourites.Where(x => x.UserId == userId && x.FurnitureItemId == furnitureItemId).Single();
            context.Favourites.Remove(favourite);
            context.SaveChanges();

            return "Successfully deleted favourite item!";
        }

        static object isLocked = new object();
        static MLContext mlContext = null;
        static ITransformer model = null;
        public async Task<List<FurnitureItemResponse>> Recommend(int id)
        {
            trainData();

            var finalResult = preditctItems(id);

            return mapper.Map<List<FurnitureItemResponse>>(finalResult);
        }

        private void trainData()
        {
            lock (isLocked)
            {
                if (mlContext == null)
                {
                    mlContext = new MLContext();

                    var tmpData = context.Orders.Include("OrderItems").ToList();

                    var data = new List<ProductEntry>();

                    foreach (var x in tmpData)
                    {
                        if (x.OrderItems.Count > 1)
                        {
                            var distinctItemId = x.OrderItems.Select(y => y.FurnitureItemId).ToList();

                            distinctItemId.ForEach(y =>
                            {
                                var relatedItems = x.OrderItems.Where(z => z.FurnitureItemId != y);

                                foreach (var z in relatedItems)
                                {
                                    data.Add(new ProductEntry()
                                    {
                                        ProductID = (uint)y,
                                        CoPurchaseProductID = (uint)z.FurnitureItemId,
                                    });
                                }
                            });
                        }
                    }

                    var disctintData = data.Select(y => new
                    {
                        ProductID = y.ProductID,
                        CoPurchaseProductID = y.CoPurchaseProductID,
                    }).Distinct();

                    var productEntries = new List<ProductEntry>();

                    foreach (var item in disctintData)
                    {
                        productEntries.Add(new ProductEntry()
                        {
                            ProductID = item.ProductID,
                            CoPurchaseProductID = item.CoPurchaseProductID,
                            Label = 0
                        });
                    }

                    var traindata = mlContext.Data.LoadFromEnumerable(productEntries);


                    //STEP 3: Your data is already encoded so all you need to do is specify options for MatrxiFactorizationTrainer with a few extra hyperparameters
                    //        LossFunction, Alpa, Lambda and a few others like K and C as shown below and call the trainer.
                    MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                    options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
                    options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
                    options.LabelColumnName = "Label";
                    options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                    options.Alpha = 0.01;
                    options.Lambda = 0.025;
                    // For better results use the following parameters
                    options.NumberOfIterations = 100;
                    options.C = 0.00001;


                    var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                    model = est.Fit(traindata);
                }

            }
        }
        private List<FurnitureItem> preditctItems(int id)
        {
            List<FurnitureItem> allItems = new List<FurnitureItem>();

            for (int i = 0; i < 10000; i++)
            {
                var tmp = context.FurnitureItems.Where(x => x.FurnitureItemId != id);
                allItems.AddRange(tmp);
            }


            var predictionResult = new List<Tuple<FurnitureItem, float>>();

            foreach (var item in allItems)
            {
                var predictionEngine = mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                var prediction = predictionEngine.Predict(new ProductEntry()
                {
                    ProductID = (uint)id,
                    CoPurchaseProductID = (uint)item.FurnitureItemId
                });

                predictionResult.Add(new Tuple<FurnitureItem, float>(item, prediction.Score));
            }

            return predictionResult.OrderByDescending(x => x.Item2).Distinct()
                .Select(x => x.Item1).Take(3).ToList();
        }


        /** VALIDATION **/
        public override void ValidateInsert(FurnitureItemUpsertRequest insert)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool exception = false;
            if (context.Categories.Find(insert.CategoryId) == null)
            {
                exception = true;
                stringBuilder.Append("Category with specified ID does not exist!\n");
            }
            if (context.Collections.Find(insert.CollectionId) == null)
            {
                exception = true;
                stringBuilder.Append("Collection with specified ID does not exist!\n");
            }
            if (context.Materials.Find(insert.MaterialId) == null)
            {
                exception = true;
                stringBuilder.Append("Material with specified ID does not exist!\n");
            }
            if (context.MetricUnits.Find(insert.MetricUnitId) == null)
            {
                exception = true;
                stringBuilder.Append("Metric unit with specified ID does not exist!\n");
            }
            if (insert?.ColorIdList.Count == 0)
            {
                exception = true;
                stringBuilder.Append("Furniture item must have at least one color!\n");
            }
            if (exception)
            {
                throw new UserException(stringBuilder.ToString());
            }
        }

        public override void ValidateUpdate(int id, FurnitureItemUpsertRequest update)
        {
            if (context.FurnitureItems.Find(id) == null)
                throw new UserException("Furniture item with specified ID does not exist!");

            ValidateInsert(update);
        }
    }
    public class Copurchase_prediction
    {
        public float Score { get; set; }
    }

    public class ProductEntry
    {
        [KeyType(count: 25000)]
        public uint ProductID { get; set; }

        [KeyType(count: 25000)]
        public uint CoPurchaseProductID { get; set; }

        public float Label { get; set; }
    }
}
