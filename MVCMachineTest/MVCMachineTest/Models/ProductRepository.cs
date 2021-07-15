using Microsoft.EntityFrameworkCore;
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
            if (product != null)
            {
                try
                {
                    var result = DbContext.Products.Add(product);
                    DbContext.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw;
                }
            }
            return product;
        }

        public Product GetProduct(string id)
        {
            return DbContext.Products.Find(id);
        }

        public Product DeleteProduct(string id)
        {
            Product product = DbContext.Products.Find(id);
            DbContext.Remove(product);
            DbContext.SaveChanges();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            if (product != null)
            {
                var productUpdate= DbContext.Products.Attach(product);
                productUpdate.State = EntityState.Modified;
                DbContext.SaveChanges();
            }
            return product;
        }
    }
}
