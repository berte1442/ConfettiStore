using ConfettiStore.Models;
using Microsoft.EntityFrameworkCore;


namespace ConfettiStore.Data
{
    public class StoreContext : DbContext 
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories  { get; set; }
        public DbSet<Confetti> Confetti { get; set; }
        public DbSet<ConfettiCategory> ConfettiCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<OrderAttachment> OrderAttachments { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
