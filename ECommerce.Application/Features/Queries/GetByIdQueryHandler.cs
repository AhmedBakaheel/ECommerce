// ECommerce.Application/Features/Queries/GetByIdQueryHandler.cs
using AutoMapper;
using ECommerce.Domain.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Queries
{
    public class GetByIdQueryHandler<TEntity, TDto> : IRequestHandler<GetByIdQuery<TEntity, TDto>, TDto>
        where TEntity : class
        where TDto : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TDto> Handle(GetByIdQuery<TEntity, TDto> request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<TDto>(entity);
        }
    }
}