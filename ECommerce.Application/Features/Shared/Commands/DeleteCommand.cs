using ECommerce.Domain.Exceptions;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.UnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Shared.Commands
{
    public class DeleteCommand<TEntity> : IRequest<Unit> where TEntity : class
    {
        public int Id { get; set; }
    }
    public class DeleteCommandHandler<TEntity> : IRequestHandler<DeleteCommand<TEntity>, Unit> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<TEntity>();
            var entity = await repository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new EntityNotFoundException<TEntity>(request.Id);
            }

            await repository.DeleteAsync(request.Id);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}