using Inventory.Models;

namespace Inventory.Repository
{
    public interface ISupplierService
    {
        Task<bool> Create(Supplier supplier);
        Task<bool> Update(Supplier supplier);
        Task<bool> Delete(Supplier supplier);
        Task<Supplier> Get(Supplier supplier);
        Task<List<Supplier>> GetAll();
    }
}
