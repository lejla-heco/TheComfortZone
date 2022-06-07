using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            List<DAO.Model.FurnitureColor> furnitureColors = context.FurnitureColors.Where(fc => fc.FurnitureItemId == id).ToList();
            List<DAO.Model.OrderItem> orderItems = context.OrderItems.Where(oi => oi.FurnitureItemId == id).ToList();
            List<DAO.Model.Favourite> favourites = context.Favourites.Where(f => f.FurnitureItemId == id).ToList();

            context.RemoveRange(furnitureColors);
            context.RemoveRange(orderItems);
            context.RemoveRange(favourites);

            context.SaveChanges();
        }

        public List<LineChartListResponse> GetBestSellingItems(string space)
        {

            var lastYear = DateTime.Now.Year - 1;

            var query = context.OrderItems.Include(x => x.FurnitureItem)
                .ThenInclude(x => x.Category)
                .ThenInclude(x => x.Space)
                .Include(x => x.Order)
                .Where(x => x.FurnitureItem.Category.Space.Name.ToLower() == space.ToLower())
                .Select(x => new {
                    furnitureId = x.FurnitureItemId,
                    furnitureName = x.FurnitureItem.Name,
                    numberOfOrders = x.FurnitureItem.OrderItems
                        .Where(y => y.FurnitureItemId == x.FurnitureItemId)
                        .Sum(y => y.OrderQuantity),
                    year = x.Order.OrderDate.Value.Year,
                })
                .Where(x => x.year == lastYear)
                .Distinct()
                .OrderByDescending(x => x.numberOfOrders)
                .Take(10);

            var list = query.ToList();

            var furnitureIdList = list.Select(x => x.furnitureId).ToList();

            var query2 = context.OrderItems.Where(oi => furnitureIdList.Contains(oi.FurnitureItemId))
                .Include(x => x.FurnitureItem)
                .ThenInclude(x => x.Category)
                .ThenInclude(x => x.Space)
                .Include(x => x.Order)
                .Where(x => x.FurnitureItem.Category.Space.Name.ToLower() == space.ToLower())
                .Select(x => new
                {
                    furnitureId = x.FurnitureItemId,
                    furnitureName = x.FurnitureItem.Name,
                    numberOfOrders = x.FurnitureItem.OrderItems
                        .Where(y => y.FurnitureItemId == x.FurnitureItemId)
                        .Where(y => y.Order.OrderDate.Value.Month == x.Order.OrderDate.Value.Month)
                        .Sum(y => y.OrderQuantity),
                    year = x.Order.OrderDate.Value.Year,
                    month = x.Order.OrderDate.Value.Month,
                })
                .Where(x => x.year == lastYear)
                .Distinct()
                .OrderByDescending(x => x.numberOfOrders);

            var furnitureItems = query2.ToList();

            List<LineChartListResponse> chartResponse = new List<LineChartListResponse>();

            for (int x = 0; x < furnitureIdList.Count; x++)
            {
                var id = furnitureIdList[x];
                LineChartListResponse series = new LineChartListResponse();
                series.FurnitureName = furnitureItems.First(l => l.furnitureId == id).furnitureName;

                for (int i = 1; i <= 12; i++)
                {
                    if (!furnitureItems.Where(l => l.month == i && l.furnitureId == id).Any())
                        series.ChartData.Add(new LineChartResponse()
                        {
                            YValue = 0,
                            XValue = i,
                        }) ;
                    else
                        series.ChartData.Add(new LineChartResponse()
                        {
                            YValue = (int)furnitureItems.SingleOrDefault(l => l.month == i && l.furnitureId == id).numberOfOrders,
                            XValue = i,
                        });
                }

                chartResponse.Add(series);
            }

            return chartResponse;
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
}
