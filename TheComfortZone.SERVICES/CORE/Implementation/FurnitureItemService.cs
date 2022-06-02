using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.FurnitureItem;
using TheComfortZone.SERVICES.API;
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
            return base.IncludeList(query);
        }

        public override FurnitureItemResponse Insert(FurnitureItemUpsertRequest insert)
        {
            var entity = base.Insert(insert);
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

            context.SaveChanges(true);
        }
    }
}
