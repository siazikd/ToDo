using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.Models
{
    internal sealed class AppDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./Models/AppDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>().Property(e => e.IsComplete).HasDefaultValue(false);

           

        }
    }
}
