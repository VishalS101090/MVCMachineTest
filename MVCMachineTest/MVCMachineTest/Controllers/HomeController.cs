using Microsoft.AspNetCore.Mvc;
using MVCMachineTest.Models;
using MVCMachineTest.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMachineTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository CategoryRepository;
        private readonly IProductRepository ProductRepository;

        public HomeController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            CategoryRepository = categoryRepository;
            ProductRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Product> products = ProductRepository.GetProducts();
            IEnumerable<Category> categories = CategoryRepository.GetCategories();
            foreach (var item in products)
            {
                Category categoryDetails = categories.FirstOrDefault(c => c.CategoryID.Equals(item.CategoryID));
                item.CategoryName = categoryDetails.CategoryName;
            }
            return View(products);
        }


        [HttpGet]
        public IActionResult AddProduct()
        {
            IEnumerable<Category> categories = CategoryRepository.GetCategories();
            AddProductViewModel viewModel = new AddProductViewModel()
            {
                Categories = categories,
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            AddProductViewModel viewModel = new AddProductViewModel();
            if (ModelState.IsValid)
            {
                try
                {
                    product.ProductID = Guid.NewGuid().ToString();
                    product.CreationTime = DateTime.Now;
                    if (ProductRepository.AddProduct(product) != null)
                    {
                        viewModel.Message = $"<strong>{product.ProductName}</strong> created successfully!";
                    }
                }
                catch (Exception ex)
                {
                    viewModel.Message = $"Production creation fail due to: {ex.InnerException}";
                }
            }
            IEnumerable<Category> categories = CategoryRepository.GetCategories();
            viewModel.Product = product;
            viewModel.Categories = categories;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult ViewProduct(string productId)
        {
            Product product = ProductRepository.GetProduct(productId);
            Category category = CategoryRepository.GetCategory(product.CategoryID);
            product.CategoryName = category.CategoryName;
            return View(product);
        }

        [HttpGet]
        public IActionResult UpdateProduct(string productId)
        {
            IEnumerable<Category> categories = CategoryRepository.GetCategories();
            Product product = ProductRepository.GetProduct(productId);
            AddProductViewModel viewModel = new AddProductViewModel()
            {
                Product =product,
                Categories = categories,
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductRepository.UpdateProduct(product);
            }

            IEnumerable<Category> categories = CategoryRepository.GetCategories();
            AddProductViewModel viewModel = new AddProductViewModel()
            {
                Product = product,
                Categories = categories,
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeleteProduct(string productId)
        {
            Product product = ProductRepository.DeleteProduct(productId);
            return View();
        }

    }
}
