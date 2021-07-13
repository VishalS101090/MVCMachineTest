using Microsoft.AspNetCore.Mvc;
using MVCMachineTest.Models;
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

        public HomeController(ICategoryRepository categoryRepository,IProductRepository productRepository)
        {
            CategoryRepository = categoryRepository;
            ProductRepository = productRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            product.ProductID = Guid.NewGuid().ToString();
            return View();
        }

        [HttpGet]
        public IActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            category.CategoryID = Guid.NewGuid().ToString();
            return View();
        }
    }
}
