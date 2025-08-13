using ECommerce.Application.DTOs.Categories;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Mappings
{
    public class CategoryProfile : EntityMappingProfile<Category, CategoryDto, CreateCategoryDto, UpdateCategoryDto>
    {
        public CategoryProfile()
        {
        }
    }
}