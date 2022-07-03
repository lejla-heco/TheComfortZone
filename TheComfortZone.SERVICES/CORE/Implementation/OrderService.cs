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
            query = query
                .Include(x => x.User)
                .Include(x => x.Employee);

            return query;
        }

        public override IQueryable<Order> AddFilter(IQueryable<Order> query, OrderSearchRequest search = null)
        {
            if (search?.OrderDate.HasValue == true)
                query = query.Where(x => x.OrderDate.Value.Date.CompareTo(search.OrderDate.Value.Date) == 0);

            return query.OrderByDescending(x => x.OrderDate);
        }

        public async Task<List<OrderResponse>> GetOrdersByEmployeeId(int id, OrderSearchRequest search = null)
        {
            /** VALIDATION **/
            if (context.Users.Include(u => u.Role)
                .Where(u => u.UserId == id && u.Role.Name == UserType.Employee.ToString()).Count() == 0)
                throw new UserException("Employee with specified ID does not exist!");

            var query = context.Orders.Where(o => o.EmployeeId == id).AsQueryable();

            query = IncludeList(query);
            query = AddFilter(query, search);

            return mapper.Map<List<OrderResponse>>(query.ToList());
        }

        public async Task<List<OrderResponse>> GetOrdersByUserId(int id, OrderSearchRequest search = null)
        {
            /** VALIDATION **/
            if (context.Users.Include(u => u.Role)
                .Where(u => u.UserId == id).Count() == 0)
                throw new UserException("User with specified ID does not exist!");

            var query = context.Orders.Where(o => o.UserId == id).AsQueryable();

            query = IncludeList(query);
            query = AddFilter(query, search);

            return mapper.Map<List<OrderResponse>>(query.ToList());
        }
    }
}
