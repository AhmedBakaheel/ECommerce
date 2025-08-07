using AutoMapper;
using ECommerce.Domain.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Queries
{
    public class GetAllQuery<TDto> : IRequest<IEnumerable<TDto>> where TDto : class { }
    public class GetAllQueryHandler<TEntity, TDto> : IRequestHandler<GetAllQuery<TDto>, IEnumerable<TDto>>
        where TEntity : class where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> Handle(GetAllQuery<TDto> request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.GetRepository<TEntity>().GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }
    }
}
