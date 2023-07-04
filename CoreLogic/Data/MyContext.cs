using CoreLogic.Model;
using Microsoft.EntityFrameworkCore;

namespace CoreLogic.Data;
    public class MyContext : DbContext
    {
        public DbSet<Users> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var server = "(localdb)";
            var instance = "mssqllocaldb";
            var database = "ToDoDB";
            var authentication = "Integrated Security = true";

            var conString = $"Data Source={server}\\{instance}; Initial Catalog={database};{authentication}";

            options.UseSqlServer(conString);
        }
    }