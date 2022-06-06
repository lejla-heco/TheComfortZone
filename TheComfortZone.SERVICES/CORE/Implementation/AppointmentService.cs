using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Appointment;
using TheComfortZone.SERVICES.API;
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
            query = query.Include(x => x.User)
                .Include(x => x.Designer)
                .Include(x => x.AppointmentType);
            return query;
        }
    }
}
