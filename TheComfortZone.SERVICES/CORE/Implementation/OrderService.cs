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

        public override async Task<OrderResponse> Insert(OrderInsertRequest insert)
        {
            /** VALIDATION **/
            if (context.Users.Find(insert.UserId) == null)
                throw new UserException("User with specified ID does not exsist!");
            int numberOfOrders = context.Orders.Where(o => o.UserId == insert.UserId).Count();

            Order order = new Order();
            order.OrderDate = DateTime.Now;
            order.Status = OrderStatus.Sent.ToString();
            order.OrderNumber = ++numberOfOrders;
            if (insert?.CouponId != null)
            {
                if (context.Coupons.Find(insert.CouponId) == null)
                    throw new UserException("Coupon with specified ID does not exsist!");

                Coupon coupon = context.Coupons.Where(o => o.CouponId == insert.CouponId).Single();
                order.UsedDiscountCoupon = true;
                order.Discount = coupon.Discount;
                coupon.Active = false;
            }
            else order.UsedDiscountCoupon = false;

            order.UserId = insert.UserId;

            int numberOfEmployees = context.Users.Where(u => u.Role.Name == UserType.Employee.ToString()).Count();
            Random rand = new Random();
            int nextNum = rand.Next(0, numberOfEmployees);

            order.EmployeeId = context.Users.Where(u => u.Role.Name == UserType.Employee.ToString()).ToList()[nextNum].UserId;
            order.Noip = 0;
            order.TotalPrice = 0;

            context.Add(order);
            context.SaveChanges();

            int numberOfItemsPurchased = 0;
            float totalPrice = 0;

            foreach(var orderItemReq in insert.items)
            {
                OrderItem orderItem = new OrderItem();
                orderItem.FurnitureItemId = orderItemReq.FurnitureItemId;
                orderItem.OrderId = order.OrderId;
                orderItem.OrderQuantity = orderItemReq.OrderQuantity;
                orderItem.Color = orderItemReq.Color;
                numberOfItemsPurchased += orderItemReq.OrderQuantity;
                totalPrice += orderItemReq.OrderQuantity * orderItemReq.UnitPrice;

                FurnitureItem item = context.FurnitureItems.Find(orderItem.FurnitureItemId);
                item.InStockQuantity -= orderItemReq.OrderQuantity;
                if (item.InStockQuantity <= 0)
                {
                    item.State = StateEnum.Hidden.ToString();
                    item.InStockQuantity = 0;
                }

                context.OrderItems.Add(orderItem);
            }

            order.Noip = numberOfItemsPurchased;
            order.TotalPrice = totalPrice;

            if (insert.CouponId != null)
            {
                order.TotalPrice = order.TotalPrice * (1 - (order.Discount / 100f));
            }

            context.SaveChanges();

            return mapper.Map<OrderResponse>(order);
        }
    }
}
