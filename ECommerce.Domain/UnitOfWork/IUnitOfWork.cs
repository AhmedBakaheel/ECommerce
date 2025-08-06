using ECommerce.Domain.Interfaces;
using System.Threading.Tasks;

namespace ECommerce.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {     
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}