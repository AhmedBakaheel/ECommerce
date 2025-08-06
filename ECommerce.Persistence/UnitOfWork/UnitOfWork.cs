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
            Products = new ProductRepository(_context);
            Orders = new OrderRepository(_context);
        }

        public IProductRepository Products { get; }
        public IOrderRepository Orders { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}