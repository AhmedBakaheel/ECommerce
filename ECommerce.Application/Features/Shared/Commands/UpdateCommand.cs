using AutoMapper;
using ECommerce.Domain.Exceptions;
using ECommerce.Domain.UnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Shared.Commands
{
   
    public class UpdateCommand<TEntity, TDto> : IRequest<TDto>
        where TEntity : class where TDto : class
    {
        public int Id { get; set; }
        public TDto Dto { get; set; }
    }
    public class UpdateCommandHandler<TEntity, TDto> : IRequestHandler<UpdateCommand<TEntity, TDto>, TDto>
        where TEntity : class where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TDto> Handle(UpdateCommand<TEntity, TDto> request, CancellationToken cancellationToken)
        {
            var existingEntity = await _unitOfWork.GetRepository<TEntity>().GetByIdAsync(request.Id);

            if (existingEntity == null)
            {
                throw new EntityNotFoundException<TEntity>(request.Id);
            }

            _mapper.Map(request.Dto, existingEntity);

            await _unitOfWork.GetRepository<TEntity>().UpdateAsync(existingEntity);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<TDto>(existingEntity);
        }
    }
}