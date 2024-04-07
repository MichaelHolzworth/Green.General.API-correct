using Project.Green.General.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Project.Green.General.Domain.Orders;

namespace Project.Green.General.Data{

    public class StoreContext : DbContext{
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        { }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            DbInitalizer.Initalize(builder);
        }
    }
}