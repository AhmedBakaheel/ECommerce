using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Mappings
{
    public class EntityMappingProfile<TEntity, TReadDto, TCreateDto, TUpdateDto> : Profile
        where TEntity : class
        where TReadDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        public EntityMappingProfile()
        {            
            CreateMap<TEntity, TReadDto>().ReverseMap();            
            CreateMap<TCreateDto, TEntity>();
            CreateMap<TUpdateDto, TEntity>();
        }
    }
}