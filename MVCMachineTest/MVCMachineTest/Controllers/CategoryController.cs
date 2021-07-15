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
                try
                {
                    category.CategoryID = Guid.NewGuid().ToString();
                    category.CreationTime = DateTime.Now;
                    CategoryRepository.AddCategory(category);
                }
                catch (Exception ex)
                {

                    //throw;
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult ViewCategory(string id)
        {
            Category category = CategoryRepository.GetCategory(id);
            return View(category);
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            Category category = CategoryRepository.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoryRepository.Update(category);
            }
            return View(category);
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            return View();
        }   
    }
}
