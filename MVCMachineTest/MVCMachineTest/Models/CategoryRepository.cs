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


        public IEnumerable<Category> GetCategories()
        {
            return DbContext.Categories.ToList();
        }


        public Category AddCategory(Category category)
        {
            if (category != null)
            {
                var result = DbContext.Categories.Add(category);
              //  result.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                DbContext.SaveChanges();
            }
            return category;
        }

        public Category GetCategory(string id)
        {
            return DbContext.Categories.Find(id);
        }
    }
}
