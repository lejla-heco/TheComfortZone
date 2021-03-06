using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.SERVICES.API
{
    public interface IAppointmentTypeService : IReadService<DTO.AppointmentType.AppointmentTypeResponse, BaseSearchObject>
    {
    }
}
