using Inventory.Data;
using Inventory.Models;
using Dapper;
namespace Inventory.Repository
{
    public class CategoryServiceImpl : ICategoryService
    {
        private readonly DapperContext _cxt;

        public CategoryServiceImpl(DapperContext cxt)
        {
            _cxt = cxt;
        }

        public bool Create(Category category)
        {
            var sql = "INSERT INTO categories(CategoryName,Description) VALUES(@CategoryName,@Description);";
           var rowEffect= _cxt.Connection.Execute(sql, new
            {
                CategoryName=category.CategoryName,
                Description=category.Description
            });
            return rowEffect > 0;
        }
        public bool Update(Category category)
        {
            var sql = @"UPDATE categories CategoryName=@CategoryName,Description=@Description 
                       WHERE Id=@Id;";
            var rowEffect = _cxt.Connection.Execute(sql, category);
            return rowEffect > 0;
        }
        public bool Delete(int id)
        {
            var sql = "DELETE FROM categories WHERE Id=@id";
            var rowEffect = _cxt.Connection.Execute(sql, new { @id=id });
            return rowEffect > 0;
        }

        public Category GetById(int id)
        {
            var sql = "SELECT * FROM categories WHERE Id=@id";
            var category = _cxt.Connection.QueryFirstOrDefault<Category>(sql, new { @id = id });
            return category!;
        }

        public IEnumerable<Category> GetCategories()
        {
            var sql = "SELECT * FROM categories";
            var categories= _cxt.Connection.Query<Category>(sql);   
            return categories;
        }

        

    }
}
