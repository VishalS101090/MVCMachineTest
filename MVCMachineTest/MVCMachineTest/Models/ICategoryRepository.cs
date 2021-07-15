using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMachineTest.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category AddCategory(Category category);
        Category GetCategory(string  id);
        Category Update(Category category);
        Category Delete(string id);

    }
}
