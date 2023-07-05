using CoreLogic.Model;
using Microsoft.EntityFrameworkCore;

namespace CoreLogic.Data;
    public class MyContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Model.Task> tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var server = "(localdb)";
            var instance = "mssqllocaldb";
            var database = "TodoDB";
            var authentication = "Integrated Security = true";

            var conString = $"Data Source={server}\\{instance}; Initial Catalog={database};{authentication}";

            options.UseSqlServer(conString);
        }
    }