using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Queries
{
    public class GetByIdQuery<TEntity, TDto> : IRequest<TDto>
        where TEntity : class
        where TDto : class
    {
        public int Id { get; set; }

        public GetByIdQuery(int id)
        {
            Id = id;
        }
    }
}