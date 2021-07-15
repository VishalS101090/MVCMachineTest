using Microsoft.EntityFrameworkCore;
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
                try
                {
                    var result = DbContext.Categories.Add(category);
                    DbContext.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw;
                }
            }
            return category;
        }

        public Category GetCategory(string id)
        {
            return DbContext.Categories.Find(id);
        }

        public Category Update(Category category)
        {
            if (category != null)
            {
                var updateResult = DbContext.Categories.Attach(category);
                updateResult.State = EntityState.Modified;
                DbContext.SaveChanges();
            }
            return category;
        }

        public Category Delete(string id)
        {
            Category category = DbContext.Categories.Find(id);
            DbContext.Categories.Remove(category);
            DbContext.SaveChanges();
            return category;
        }
    }
}
