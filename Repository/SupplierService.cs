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
           return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Supplier supplier)
        {
            context.Suppliers.Remove(supplier);
            return await context.SaveChangesAsync() >0;
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

        public async Task<bool> Update(Supplier supplier)
        {
            //var sup=await context.Suppliers.FirstOrDefaultAsync(x=>x.Id==supplier.Id);
            //sup!.Name=supplier.Name;
            //sup!.Description=supplier.Description;
            //sup!.Address=supplier.Address;
            //sup!.City=supplier.City;
            //sup!.Email=supplier.Email;
            //sup!.Phone=supplier.Phone;
            context.Suppliers.Update(supplier);
            return await context.SaveChangesAsync() > 0;

        }
    }
}
