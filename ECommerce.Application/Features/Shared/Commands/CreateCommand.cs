using AutoMapper;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.UnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Shared.Commands
{
   
    public class CreateCommand<TEntity, TDto> : IRequest<TDto> where TEntity : class
    {
        public TDto Dto { get; set; }
    }

    public class CreateCommandHandler<TEntity, TDto> : IRequestHandler<CreateCommand<TEntity, TDto>, TDto>
        where TEntity : class where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TDto> Handle(CreateCommand<TEntity, TDto> request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(request.Dto);

            await _unitOfWork.GetRepository<TEntity>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);
        }
    }
}