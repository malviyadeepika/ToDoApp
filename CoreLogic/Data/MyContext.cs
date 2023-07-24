using CoreLogic.Model;
using Microsoft.EntityFrameworkCore;

namespace CoreLogic.Data;
    public class MyContext : DbContext
    {
        public DbSet<User> users { get; set; }
       public DbSet<Model.Task> tasks { get; set; }
       
       public DbSet<Category> categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var server = "(localdb)";
            var instance = "mssqllocaldb";
            var database = "TodoDB";
            var authentication = "Integrated Security = true";

            var conString = $"Data Source={server}\\{instance}; Initial Catalog={database};{authentication}";

            options.UseSqlServer(conString);
        }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Home"
            },
            new Category
            {
                Id = 12,
                Name = "Office"
            }
            , new Category
            {
                Id = 3,
                Name = "Personal"
            },
            new Category
            {
                Id = 4,
                Name = "Event"
            }
            ) ;

    }
}