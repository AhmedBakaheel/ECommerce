using ECommerce.Domain.Interfaces;
using System.Threading.Tasks;

namespace ECommerce.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        Task<int> SaveChangesAsync();
    }
}