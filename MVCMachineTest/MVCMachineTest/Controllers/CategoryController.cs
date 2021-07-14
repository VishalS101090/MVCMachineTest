using Microsoft.AspNetCore.Mvc;
using MVCMachineTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMachineTest.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository CategoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> categories = CategoryRepository.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                category.CategoryID = Guid.NewGuid().ToString();
                category.CreationTime = DateTime.Now;
                CategoryRepository.AddCategory(category);
            }
            return View();
        }
    }
}
