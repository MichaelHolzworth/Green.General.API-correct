using Project.Green.General.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Project.Green.General.Data{

    public class StoreContext : DbContext{
        public StoreContext(DbContextOptions<StoreContext> options) : base (options)
        { }

        public DbSet<Item> Items { get; set; }
    }
}