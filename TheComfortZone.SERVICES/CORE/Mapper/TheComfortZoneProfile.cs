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

            /** SPACE **/
            CreateMap<DAO.Model.Space, DTO.Space.SpaceResponse>();

            /** CATEGORY **/
            CreateMap<DAO.Model.Category, DTO.Category.CategoryResponse>();

            /** DESIGNER **/
            CreateMap<DAO.Model.Designer, DTO.Designer.DesignerResponse>();

            /** COLLECTION **/
            CreateMap<DAO.Model.Collection, DTO.Collection.CollectionResponse>();

            /** MATERIAL **/
            CreateMap<DAO.Model.Material, DTO.Material.MaterialResponse>();

            /** METRIC UNIT **/
            CreateMap<DAO.Model.MetricUnit, DTO.MetricUnit.MetricUnitResponse>();

            /** COLOR **/
            CreateMap<DAO.Model.Color, DTO.Color.ColorResponse>();

            /** FURNITURE COLOR **/
            CreateMap<DAO.Model.FurnitureColor, DTO.FurnitureColor.FurnitureColorResponse>();

            /** FURNITURE ITEM **/
            CreateMap<DAO.Model.FurnitureItem, DTO.FurnitureItem.FurnitureItemResponse>()
                .ForMember(dto => dto.DesignerName, opts => opts.MapFrom(entity => entity.Collection.Designer.Name))
                .ForMember(dto => dto.CategoryName, opts => opts.MapFrom(entity => entity.Category.Name))
                .ForMember(dto => dto.SpaceName, opts => opts.MapFrom(entity => entity.Category.Space.Name))
                .ForMember(dto => dto.CollectionName, opts => opts.MapFrom(entity => entity.Collection.Name))
                .ForMember(dto => dto.Colors, opts => opts.MapFrom(entity => string.Join(", ", entity.FurnitureColors.Select(x => x.Color.Name).ToList())))
                .ForMember(dto => dto.Material, opts => opts.MapFrom(entity => entity.Material.Name))
                .ForMember(dto => dto.SpaceId, opts => opts.MapFrom(entity => entity.Category.SpaceId))
                .ForMember(dto => dto.DesignerId, opts => opts.MapFrom(entity => entity.Collection.DesignerId));

            CreateMap<DTO.FurnitureItem.FurnitureItemUpsertRequest, DAO.Model.FurnitureItem>();
        }
    }
}
