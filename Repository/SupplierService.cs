using Inventory.Data;
using Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repository
{
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext context;

        public SupplierService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> Create(Supplier supplier)
        {
            context.Suppliers.Add(supplier);
            await context.SaveChangesAsync();
            return true;
        }

        public Task<bool> Delete(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> Get(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Supplier>> GetAll()
        {
            var results =context.Suppliers;
            return await results.ToListAsync();
        }

        public Task<bool> Update(Supplier supplier)
        {
            throw new NotImplementedException();
        }
    }
}
