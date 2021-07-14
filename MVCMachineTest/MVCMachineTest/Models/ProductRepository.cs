using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMachineTest.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext DbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return DbContext.Products.ToList();
        }

        public Product AddProduct(Product product)
        {
            var result = DbContext.Products.Add(product);
            DbContext.SaveChanges();
            return product;
        }

        public Product GetProduct(string id)
        {
            Product product = DbContext.Products.FirstOrDefault(p => p.ProductID.Equals(id));
            return product;
        }

        public Product DeleteProduct(string id)
        {
            Product product = DbContext.Products.FirstOrDefault(p => p.ProductID.Equals(id));
            DbContext.Remove(product);
            DbContext.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            DbContext.Products.Attach(product);
            DbContext.SaveChanges();
            return product;
        }
    }
}
