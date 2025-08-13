using AutoMapper;
using ECommerce.Domain.UnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Shared.Commands
{
    public class CreateCommand<TEntity, TCreateDto, TReadDto> : IRequest<TReadDto>
        where TEntity : class where TCreateDto : class where TReadDto : class
    {
        public required TCreateDto Dto { get; set; }
    }
    public class CreateCommandHandler<TEntity, TCreateDto, TReadDto> : IRequestHandler<CreateCommand<TEntity, TCreateDto, TReadDto>, TReadDto>
        where TEntity : class where TCreateDto : class where TReadDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TReadDto> Handle(CreateCommand<TEntity, TCreateDto, TReadDto> request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(request.Dto);

            await _unitOfWork.GetRepository<TEntity>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<TReadDto>(entity);
        }
    }
}