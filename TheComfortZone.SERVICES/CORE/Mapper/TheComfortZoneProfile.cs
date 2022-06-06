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
            CreateMap<DTO.User.UserInsertRequest, DAO.Model.User>();
            CreateMap<DTO.User.UserUpdateRequest, DAO.Model.User>();

            /** ROLE **/
            CreateMap<DAO.Model.Role, DTO.Role.RoleResponse>();

            /** SPACE **/
            CreateMap<DAO.Model.Space, DTO.Space.SpaceResponse>();
            CreateMap<DTO.Space.SpaceUpsertRequest, DAO.Model.Space>(); 

            /** CATEGORY **/
            CreateMap<DAO.Model.Category, DTO.Category.CategoryResponse>();
            CreateMap<DTO.Category.CategoryUpsertRequest, DAO.Model.Category>();

            /** DESIGNER **/
            CreateMap<DAO.Model.Designer, DTO.Designer.DesignerResponse>();
            CreateMap<DTO.Designer.DesignerUpsertRequest, DAO.Model.Designer>();

            /** COLLECTION **/
            CreateMap<DAO.Model.Collection, DTO.Collection.CollectionResponse>();
            CreateMap<DTO.Collection.CollectionUpsertRequest, DAO.Model.Collection>();

            /** MATERIAL **/
            CreateMap<DAO.Model.Material, DTO.Material.MaterialResponse>();

            /** METRIC UNIT **/
            CreateMap<DAO.Model.MetricUnit, DTO.MetricUnit.MetricUnitResponse>();
            CreateMap<DTO.MetricUnit.MetricUnitUpsertRequest, DAO.Model.MetricUnit>();

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

            /** ORDER **/
            CreateMap<DAO.Model.Order, DTO.Order.OrderResponse>()
                .ForMember(dto => dto.Customer, opts => opts.MapFrom(entity => $"{entity.User.FirstName} {entity.User.LastName}"))
                .ForMember(dto => dto.PhoneNumber, opts => opts.MapFrom(entity => entity.User.PhoneNumber))
                .ForMember(dto => dto.Adress, opts => opts.MapFrom(entity => entity.User.Adress));
            CreateMap<DTO.Order.OrderUpdateRequest, DAO.Model.Order>();
            CreateMap<DTO.Order.OrderUpdateRequest, DAO.Model.Order>();

            /** ORDER ITEM **/
            CreateMap<DAO.Model.OrderItem, DTO.OrderItem.OrderItemResponse>()
                .ForMember(dto => dto.ProductName, opts => opts.MapFrom(entity => entity.FurnitureItem.Name))
                .ForMember(dto => dto.CategoryName, opts => opts.MapFrom(entity => entity.FurnitureItem.Category.Name))
                .ForMember(dto => dto.CollectionName, opts => opts.MapFrom(entity => entity.FurnitureItem.Collection.Name))
                .ForMember(dto => dto.UnitPrice, opts => opts
                .MapFrom(entity => entity.FurnitureItem.OnSale == true ? entity.FurnitureItem.DiscountPrice : entity.FurnitureItem.RegularPrice))
                .ForMember(dto => dto.MaterialName, opts => opts.MapFrom(entity => entity.FurnitureItem.Material.Name));

            /** APPOINTMENT **/
            CreateMap<DAO.Model.Appointment, DTO.Appointment.AppointmentResponse>()
                .ForMember(dto => dto.Customer, opts => opts.MapFrom(entity => $"{entity.User.FirstName} {entity.User.LastName}"));
            CreateMap<DTO.Appointment.AppointmentUpdateRequest, DAO.Model.Appointment>();

            /** APPOINTMENT TYPE **/
            CreateMap<DAO.Model.AppointmentType, DTO.AppointmentType.AppointmentTypeResponse>();
        }
    }
}
