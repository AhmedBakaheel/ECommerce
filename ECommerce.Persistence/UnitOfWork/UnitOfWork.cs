using ECommerce.Domain.Interfaces;
using ECommerce.Domain.UnitOfWork;
using ECommerce.Persistence.Data;
using ECommerce.Persistence.Repositories;
using System.Threading.Tasks;

namespace ECommerce.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {           
            return new Repository<TEntity>(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}