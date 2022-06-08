using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Charts;
using TheComfortZone.DTO.Role;
using TheComfortZone.DTO.User;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;
using TheComfortZone.SERVICES.CORE.Utils;
using TheComfortZone.SERVICES.DAO;
using TheComfortZone.SERVICES.DAO.Model;

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class UserService : BaseCRUDService<UserResponse, User, UserSearchRequest, UserInsertRequest, UserUpdateRequest>, IUserService
    {
        public UserService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<User> IncludeList(IQueryable<User> query)
        {
            return query.Include("Role");
        }

        public override void BeforeInsert(UserInsertRequest insert, User entity)
        {
            var passwordSalt = PasswordGenerator.GenerateSalt();
            var passwordHash = PasswordGenerator.GenerateHash(passwordSalt, insert.Password);
            entity.PasswordSalt = passwordSalt;
            entity.PasswordHash = passwordHash;
            entity.RoleId = context.Roles.Where(r => r.Name == insert.RoleName).First().RoleId;
        }

        public override void BeforeUpdate(User entity, UserUpdateRequest update)
        {
            if (!string.IsNullOrWhiteSpace(update.Password) && !string.IsNullOrWhiteSpace(update.PasswordConfirmation))
            {
                var passwordSalt = PasswordGenerator.GenerateSalt();
                var passwordHash = PasswordGenerator.GenerateHash(passwordSalt, update.Password);
                entity.PasswordSalt = passwordSalt;
                entity.PasswordHash = passwordHash;
            }
        }

        public async Task<UserResponse> Login(string username, string password)
        {
            var entity = context.Users.Include("Role").FirstOrDefault(x => x.Username == username);
            if (entity == null)
            {
                return null;
            }

            var hash = PasswordGenerator.GenerateHash(entity.PasswordSalt, password);

            if (hash != entity.PasswordHash)
            {
                return null;
            }

            return mapper.Map<UserResponse>(entity);
        }

        public async Task<LoggedUser> GetUserRole(string username, string password)
        {
            UserResponse currentUser = await Login(username, password);
            return new LoggedUser { UserId = currentUser.UserId, UserRole = currentUser.Role.Name };
        }

        public override IQueryable<User> AddFilter(IQueryable<User> query, UserSearchRequest search = null)
        {
            if (!string.IsNullOrWhiteSpace(search?.RoleName))
            {
                query = query.Where(u => u.Role.Name == search.RoleName);
            }
            if (!string.IsNullOrWhiteSpace(search?.Username))
            {
                query = query.Where(u => u.Username.ToLower().StartsWith(search.Username.ToLower()));
            }

            return query;
        }

        public override void BeforeDelete(int id)
        {
            if (context.Users.Include(u => u.Role).Where(u => u.UserId == id).First().Role.Name == UserType.Employee.ToString())
            {
                List<DAO.Model.Order> orders = context.Orders.Where(o => o.EmployeeId == id).ToList();
                List<DAO.Model.Appointment> appointments = context.Appointments.Where(a => a.EmployeeId == id).ToList();

                orders.ForEach(o =>
                {
                    o.EmployeeId = null;
                    if (o.Status != OrderStatus.Sent.ToString())
                        o.OrderDate = DateTime.Now;
                });
                appointments.ForEach(a =>
                {
                    a.EmployeeId = null;
                    if (a.Approved == null)
                        a.AppointmentDate = DateTime.Now;
                }
                );
            }

            context.SaveChanges();
        }

        public async Task<List<UserCmbList>> GetUsernames()
        {
            var query = context.Users.Include(u => u.Role).Where(u => u.Role.Name == UserType.User.ToString());
            return mapper.Map<List<UserCmbList>>(query.ToList());
        }

        public async Task<List<SalesResponse>> GetSalesByPeriod(DateTime? fromDate = null, DateTime? toDate = null)
        {

            if (fromDate != default(DateTime) && toDate != default(DateTime)
                && fromDate.Value.Date.CompareTo(toDate.Value.Date) > 0)
                throw new UserException("Start date must be earlier than end date");

            var queryOrders = context.Orders.Include(x => x.User).Include(x => x.Employee).AsQueryable();
            var queryAppointments = context.Appointments.Include(x => x.User).Include(x => x.Employee).AsQueryable();

            if (fromDate.HasValue && fromDate != default(DateTime))
            {
                queryOrders = queryOrders.Where(x => x.OrderDate.Value.Date.CompareTo(fromDate.Value.Date) >= 0);
                queryAppointments = queryAppointments.Where(x => x.AppointmentDate.Value.Date.CompareTo(fromDate.Value.Date) >= 0);
            }

            if (toDate.HasValue && toDate != default(DateTime))
            {
                queryOrders = queryOrders.Where(x => x.OrderDate.Value.Date.CompareTo(toDate.Value.Date) <= 0);
                queryAppointments = queryAppointments.Where(x => x.AppointmentDate.Value.Date.CompareTo(toDate.Value.Date) <= 0);
            }

            var queryOrdersList = queryOrders.ToList();
            var queryAppointmentsList = queryAppointments.ToList();

            List<SalesResponse> salesOrders = mapper.Map<List<SalesResponse>>(queryOrdersList);
            List<SalesResponse> salesAppointments = mapper.Map<List<SalesResponse>>(queryAppointmentsList);

            salesOrders.AddRange((IEnumerable<SalesResponse>)salesAppointments);

            var response = salesOrders.Select(x => new SalesResponse()
            {
                Customer = x.Customer,
                Employee = x.Employee,
                TotalPrice = salesOrders
                .Where(y => y.Customer == x.Customer)
                .Where(y => y.Employee == x.Employee)
                .Where(y => y.Date.Date == x.Date.Date)
                .Sum(y => y.TotalPrice),
                Date = x.Date.Date,
            })
                .GroupBy(x => new { x.Customer, x.Employee, x.Date})
                .Select(x => x.First())
                .OrderByDescending(x => x.Date);

            return response.ToList();
        }

        /** VALIDATION **/
        public override void ValidateInsert(UserInsertRequest insert)
        {
            if (insert.Password != insert.PasswordConfirmation)
                throw new UserException("Password and Password confirmation must be the same!");
        }

        public override void ValidateUpdate(int id, UserUpdateRequest update)
        {
            if (!string.IsNullOrWhiteSpace(update.Password) && !string.IsNullOrWhiteSpace(update.PasswordConfirmation))
            {
                if (update.Password != update.PasswordConfirmation)
                    throw new UserException("Password and Password confirmation must be the same!");
            }
        }
    }
}
