using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Appointment;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;
using TheComfortZone.SERVICES.CORE.Utils;
using TheComfortZone.SERVICES.DAO;
using TheComfortZone.SERVICES.DAO.Model;

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class AppointmentService : BaseCRUDService<AppointmentResponse, DAO.Model.Appointment, AppointmentSearchRequest, AppointmentInsertRequest, AppointmentUpdateRequest>, IAppointmentService
    {
        public AppointmentService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<Appointment> IncludeList(IQueryable<Appointment> query)
        {
            query = query
                .Include(x => x.User)
                .Include(x => x.Designer)
                .Include(x => x.AppointmentType);
            return query;
        }
        public override IQueryable<Appointment> AddFilter(IQueryable<Appointment> query, AppointmentSearchRequest search = null)
        {
            if (search?.AppointmentDate.HasValue == true)
                query = query.Where(x => x.AppointmentDate.Value.Date == search.AppointmentDate.Value.Date);

            return query.OrderByDescending(x => x.AppointmentDate);
        }

        public async Task<List<AppointmentResponse>> GetAppointmentsByEmployeeId(int id, AppointmentSearchRequest search = null)
        {
            /** VALIDATION **/
            if (context.Users.Include(u => u.Role)
                .Where(u => u.UserId == id && u.Role.Name == UserType.Employee.ToString()).Count() == 0)
                throw new UserException("Employee with specified ID does not exist!");

            var query = context.Appointments.Where(o => o.EmployeeId == id).AsQueryable();

            query = IncludeList(query);
            query = AddFilter(query, search);

            return mapper.Map<List<AppointmentResponse>>(query.ToList());
        }

        public async Task<List<AppointmentResponse>> GetAppointmentsByUserId(int id, AppointmentSearchRequest search = null)
        {
            /** VALIDATION **/
            if (context.Users.Include(u => u.Role)
                .Where(u => u.UserId == id).Count() == 0)
                throw new UserException("User with specified ID does not exist!");

            var query = context.Appointments.Where(o => o.UserId == id).AsQueryable();

            query = IncludeList(query);
            query = AddFilter(query, search);

            return mapper.Map<List<AppointmentResponse>>(query.ToList());
        }

        public override void BeforeInsert(AppointmentInsertRequest insert, Appointment entity)
        {
            entity.AppointmentNumber = Guid.NewGuid().ToString().Substring(0, 8);

            int numberOfEmployees = context.Users.Where(u => u.Role.Name == UserType.Employee.ToString()).Count();
            Random rand = new Random();
            int nextNum = rand.Next(0, numberOfEmployees);

            entity.EmployeeId = context.Users.Where(u => u.Role.Name == UserType.Employee.ToString()).ToList()[nextNum].UserId;
        }

        public override void ValidateInsert(AppointmentInsertRequest insert)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool exception = false;
            if (context.Users.Find(insert.UserId) == null)
            {
                exception = true;
                stringBuilder.Append("User with specified ID does not exist!\n");
            }
            if (context.Designers.Find(insert.DesignerId) == null)
            {
                exception = true;
                stringBuilder.Append("Designer with specified ID does not exist!");
            }
            if (context.AppointmentTypes.Find(insert.AppointmentTypeId) == null)
            {
                exception = true;
                stringBuilder.Append("Appointment Type with specified ID does not exist!");
            }
            if (exception)
            {
                throw new UserException(stringBuilder.ToString());
            }
        }
    }
}
