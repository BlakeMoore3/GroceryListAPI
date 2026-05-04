namespace GroceryListAPI.Data
{
    using GroceryListAPI.Models;
    using Microsoft.EntityFrameworkCore;

    public class GroceryDbContext : DbContext
    {

        public GroceryDbContext(DbContextOptions<GroceryDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
    }
}
