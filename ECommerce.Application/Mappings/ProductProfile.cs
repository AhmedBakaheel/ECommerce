using ECommerce.Application.DTOs.Products;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Mappings
{
    public class ProductProfile : EntityMappingProfile<Product, ProductDto, CreateProductDto, UpdateProductDto>
    {
        public ProductProfile()
        {
            // إذا كان لديك خرائط معقدة خاصة بـ Product، يمكنك إضافتها هنا
            // على سبيل المثال، لجلب اسم الفئة:
            // CreateMap<Product, ProductDto>()
            //    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}