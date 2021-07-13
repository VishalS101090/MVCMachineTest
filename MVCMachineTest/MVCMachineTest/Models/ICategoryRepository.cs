using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMachineTest.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetProducts();
        Category AddProduct(Category product);
    }
}
