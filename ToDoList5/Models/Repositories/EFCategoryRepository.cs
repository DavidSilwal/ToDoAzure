using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoList5.Models
{
    public class EFCategoryRepository : ICategoryRepository
    {
        ToDoListContext db = new ToDoListContext();

        public IQueryable<Category> Categories
        { get { return db.Categories; } }

        //public IQueryable<Category> Categories => throw new NotImplementedException();

        public Category Save(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return category;
        }

        public Category Edit(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return category;
        }

        public void Remove(Category category)
        {
            db.Categories.Remove(category);
            db.SaveChanges();
        }
    }
}
