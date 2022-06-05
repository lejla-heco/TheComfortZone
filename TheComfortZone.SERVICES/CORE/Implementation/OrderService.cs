using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Order;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;
using TheComfortZone.SERVICES.CORE.Utils;
using TheComfortZone.SERVICES.DAO;
using TheComfortZone.SERVICES.DAO.Model;

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class OrderService : BaseCRUDService<DTO.Order.OrderResponse, DAO.Model.Order, OrderSearchRequest, DTO.Order.OrderInsertRequest, DTO.Order.OrderUpdateRequest>, IOrderService
    {
        public OrderService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Order> IncludeList(IQueryable<Order> query)
        {
            query = query.Include(x => x.User)
                .Include(x => x.Employee);
            return query;
        }

        public override IQueryable<Order> AddFilter(IQueryable<Order> query, OrderSearchRequest search = null)
        {
            if (search?.EmployeeId.HasValue == true)
                query = query.Include(x => x.Employee).Where(x => x.EmployeeId == search.EmployeeId);
            if (search?.UserId.HasValue == true)
                query = query.Include(x => x.User).Where(x => x.UserId == search.UserId);

            return query.OrderByDescending(x => x.OrderDate);
        }
    }
}
