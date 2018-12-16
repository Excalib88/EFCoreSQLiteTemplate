using Microsoft.EntityFrameworkCore;

namespace EFSQLiteLesson
{
    public class ShopContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public ShopContext()
        {
            Database.EnsureCreated();//Можно юзать EnsureCreatedAsync но в SQLite нет многопоточности поэтому смысла нет 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Shop.db");
        }
    }
}
