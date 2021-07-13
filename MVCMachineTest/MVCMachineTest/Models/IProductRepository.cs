using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMachineTest.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product AddProduct(Product product);
        Product GetProduct(string id);
        Product UpdateProduct(Product product);
        Product DeleteProduct(string id);
    }
}
