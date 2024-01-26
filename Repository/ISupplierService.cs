using Inventory.Models;

namespace Inventory.Repository
{
    public interface ISupplierService
    {
        Task<bool> Create(Supplier supplier);
        Task<bool> Update(Supplier supplier);
        Task<bool> Delete(Supplier supplier);
        Task<Supplier> Get(int id);
        Task<List<Supplier>> GetAll();
    }
}
