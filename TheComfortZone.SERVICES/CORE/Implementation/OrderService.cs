using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                query = query.Include(x => x.Employee)
                    .Where(x => x.EmployeeId == search.EmployeeId && x.Status != OrderStatus.Completed.ToString());
            if (search?.UserId.HasValue == true)
                query = query.Include(x => x.User).Where(x => x.UserId == search.UserId);

            if (search?.OrderDate.HasValue == true)
                query = query.Where(x => x.OrderDate.Value.Date == search.OrderDate.Value.Date);

            return query.OrderByDescending(x => x.OrderDate);
        }

    }
}
