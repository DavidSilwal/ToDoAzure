using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace ToDoList5.Models
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext()
        {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql(@"Server=localhost;Port=8889;database=todoazure;uid=root;pwd=root;");
            //optionsBuilder.UseMySql(@"Server = tcp:webapplication120180717093406dbserver.database.windows.net,1433; Initial Catalog = ToDoAzure20180717110030_db; Persist Security Info = False; User ID = {SaraHamilton}; Password = {33kr8-)6SUpz721}; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
            optionsBuilder.UseMySql(@"Server=tcp:webapplication120180717093406dbserver.database.windows.net,1433; Initial Catalog = ToDoAzure20180717110030_db; User Id = SaraHamilton@webapplication120180717093406dbserver; Password = 33kr8-)6SUpz721;");


            //optionsBuilder.UseMySql(connectionString: @"DefaultConnection");
        }

        public ToDoListContext(DbContextOptions<ToDoListContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
