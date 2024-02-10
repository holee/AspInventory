using Inventory.Data;
using Inventory.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

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

        public async Task<Supplier> Get(int id)
        {
            var supplier = await context.Suppliers
                                    .Include(p=>p.Address)
                                    .FirstOrDefaultAsync(x => x.Id == id);
            ///SELECT TOP(1) FROM Supplier WHERE id=@id;
            return supplier!;
        }

        public async Task<List<Supplier>> GetAll()
        {
            var results = await context.Suppliers.ToListAsync();
            //select * from supplier;
            return results;
        }

        public async Task<bool> Update(Supplier supplier)
        {
            var sup=await context.Suppliers
                        .Include(p=>p.Address)      
                                .FirstOrDefaultAsync(x=>x.Id==supplier.Id);
            sup!.Name = supplier.Name;
            sup!.Description = supplier.Description;
            sup!.Address = supplier.Address;
            sup!.City = supplier.City;
            sup!.Email = supplier.Email;
            sup!.Phone = supplier.Phone;
            sup.Gender = supplier.Gender;   
            sup!.Address= supplier.Address;
            return await context.SaveChangesAsync() > 0;

        }

        public async Task<bool> Update1(Supplier supplier)
        {
            context.Suppliers.Update(supplier);
            return await context.SaveChangesAsync() > 0;
        }
    }
}
