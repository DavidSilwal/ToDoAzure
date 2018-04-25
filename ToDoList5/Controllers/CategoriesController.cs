using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using ToDoList5.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoList5.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryRepository categoryRepo;  // New!

        public CategoriesController(ICategoryRepository repo = null)
        {
            if (repo == null)
            {
                this.categoryRepo = new EFCategoryRepository();
            }
            else
            {
                this.categoryRepo = repo;
            }
        }
        public ViewResult Index()
        {
            List<Category> model = categoryRepo.Categories.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            categoryRepo.Save(category);
            //categoryRepo.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisCategory = categoryRepo.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            return View(thisCategory);
        }

        public IActionResult Edit(int id)
        {
            var thisCategory = categoryRepo.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            return View(thisCategory);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            categoryRepo.Edit(category);
            //categoryRepo.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisCategory = categoryRepo.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            return View(thisCategory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisCategory = categoryRepo.Categories.FirstOrDefault(categories => categories.CategoryId == id);
            categoryRepo.Remove(thisCategory);
            //categoryRepo.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
