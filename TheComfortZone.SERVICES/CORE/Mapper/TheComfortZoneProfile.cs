using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheComfortZone.SERVICES.CORE.Mapper
{
    public class TheComfortZoneProfile : Profile
    {
       public TheComfortZoneProfile()
        {
            /** USER **/
            CreateMap<DAO.Model.User, DTO.User.UserResponse>();
            CreateMap<DTO.User.UserUpsertRequest, DAO.Model.User>();
            CreateMap<DTO.User.UserUpsertRequest, DAO.Model.User>();

            /** ROLE **/
            CreateMap<DAO.Model.Role, DTO.Role.RoleResponse>();
        }
    }
}
