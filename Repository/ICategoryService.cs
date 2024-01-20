using Inventory.Models;

namespace Inventory.Repository
{
    public interface ICategoryService
    {
        bool Create(Category category);
        bool Update(Category category);
        bool Delete(int id);
        IEnumerable<Category> GetCategories();  
        Category GetById(int id);
    }
}
