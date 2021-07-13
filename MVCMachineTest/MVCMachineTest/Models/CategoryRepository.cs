using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMachineTest.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext DbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }


        public IEnumerable<Category> GetProducts()
        {
            return DbContext.Categories;
        }

        public Category AddProduct(Category category)
        {
            DbContext.Categories.Add(category);
            DbContext.SaveChanges();
            return category;
        }

       
    }
}
