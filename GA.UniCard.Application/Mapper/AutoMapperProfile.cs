using AutoMapper;
using GA.UniCard.Application.Models;
using GA.UniCard.Domain.Entities;

namespace GA.UniCard.Application.Mapper
{
    /// <summary>
    /// AutoMapper profile for mapping between DTOs and entities.
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Constructor to create mappings between DTOs and entities.
        /// </summary>
        public AutoMapperProfile()
        {
            // User mappings
            CreateMap<UserDto, User>().ReverseMap();

            // Product mappings
            CreateMap<ProductDto, Product>().ReverseMap();

            // Order mappings
            CreateMap<Order, OrderDto>().ReverseMap();

            // OrderItem mappings
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        }
    }
}
