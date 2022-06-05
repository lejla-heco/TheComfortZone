using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.OrderItem;
using TheComfortZone.SERVICES.API;
using TheComfortZone.SERVICES.DAO;
using TheComfortZone.SERVICES.DAO.Model;

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class OrderItemService : BaseReadService<DTO.OrderItem.OrderItemResponse, DAO.Model.OrderItem, DTO.OrderItem.OrderItemSearchRequest>, IOrderItemService
    {
        public OrderItemService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<OrderItem> IncludeList(IQueryable<OrderItem> query)
        {
            query = query.Include(x => x.FurnitureItem)
                .Include(x => x.FurnitureItem.Category)
                .Include(x => x.FurnitureItem.Collection)
                .Include(x => x.FurnitureItem.Material);
            return query;
        }
        public override IQueryable<OrderItem> AddFilter(IQueryable<OrderItem> query, OrderItemSearchRequest search = null)
        {
            if (search?.OrderId.HasValue == true)
                query = query.Where(x => x.OrderId == search.OrderId);

            return query;
        }
    }
}
