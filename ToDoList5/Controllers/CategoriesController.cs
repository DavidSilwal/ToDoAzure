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
        private ToDoListContext db = new ToDoListContext();
        public IActionResult Index()
        {
            List<Category> model = db.Categories.ToList();
            return View(model);
        }
    }
}
