using Microsoft.EntityFrameworkCore;
using Orders_CRUD.Models;
using System.Xml.Linq;

namespace Orders_CRUD
{
    class ApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!; 
        public DbSet<Provider> Providers { get; set; } = null!;

        public ApplicationContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;database=order_db2;username=postgres;password=123456");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasIndex(p => new { p.Number, p.ProviderId }).IsUnique();


            modelBuilder.Entity<Provider>().HasData(
                new Provider { Id = 1, Name = "Поставщик 1" },
                new Provider { Id = 2, Name = "Поставщик 2" },
                new Provider { Id = 3, Name = "Поставщик 3" }
            );
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, Number = "123qwe", Date = DateTime.SpecifyKind(DateTime.Parse("2023-11-12T14:00:00.000000Z"), DateTimeKind.Utc), ProviderId = 1 },
                new Order { Id = 2, Number = "456qwe", Date = DateTime.SpecifyKind(DateTime.Parse("2022-11-12T14:00:00.000000Z"), DateTimeKind.Utc), ProviderId = 1 },
                new Order { Id = 3, Number = "789qwe", Date = DateTime.SpecifyKind(DateTime.Parse("2023-09-12T14:00:00.000000Z"), DateTimeKind.Utc), ProviderId = 2 },
                new Order { Id = 4, Number = "123abc", Date = DateTime.SpecifyKind(DateTime.Parse("2023-11-07T14:00:00.000000Z"), DateTimeKind.Utc), ProviderId = 2 },
                new Order { Id = 5, Number = "123def", Date = DateTime.SpecifyKind(DateTime.Parse("2023-08-12T14:00:00.000000Z"), DateTimeKind.Utc), ProviderId = 3 },
                new Order { Id = 6, Number = "123ghi", Date = DateTime.SpecifyKind(DateTime.Parse("2023-11-02T14:00:00.000000Z"), DateTimeKind.Utc), ProviderId = 3 }
            );
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { Id = 1, OrderId = 1, Name = "Товар 1", Quantity = 3, Unit = "шт" },

                new OrderItem { Id = 2, OrderId = 2, Name = "Товар 3", Quantity = 300, Unit = "гр" },

                new OrderItem { Id = 3, OrderId = 3, Name = "Товар 2", Quantity = 400, Unit = "л" },

                new OrderItem { Id = 4, OrderId = 4, Name = "Товар 4", Quantity = 10, Unit = "шт" },

                new OrderItem { Id = 5, OrderId = 5, Name = "Товар 4", Quantity = 5, Unit = "шт" },

                new OrderItem { Id = 6, OrderId = 6, Name = "Товар 2", Quantity = 500, Unit = "л" }
            );
        }
    }
}
