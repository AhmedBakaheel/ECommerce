// ECommerce.Application/Mappings/ProductProfile.cs
using ECommerce.Application.DTOs.Products;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Mappings
{
    public class ProductProfile : EntityMappingProfile<Product, ProductDto, CreateProductDto, UpdateProductDto>
    {
        public ProductProfile()
        {           
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name));
        }
    }
}