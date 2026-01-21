using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Models;

namespace OrderManagementApp
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure unique constraints
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Sku)
                .IsUnique();

            modelBuilder.Entity<Order>()
                .HasIndex(o => o.OrderNumber)
                .IsUnique();

            modelBuilder.Entity<Order>()
                .HasIndex(o => o.CustomerEmail)
                .IsUnique();

            // Configure foreign key
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Products
            var products = new List<Product>();
            var categories = new[] { "Electronics", "Clothing", "Books", "Home", "Sports" };
            var random = new Random(42); // For reproducible data

            for (int i = 1; i <= 15; i++)
            {
                products.Add(new Product
                {
                    Id = i,
                    Name = $"Product {i}",
                    Sku = $"SKU{i:D4}",
                    Description = $"Description for Product {i}",
                    Price = Math.Round((decimal)(random.Next(10, 1000) + random.NextDouble()), 2),
                    StockQuantity = random.Next(1, 100),
                    Category = categories[random.Next(categories.Length)],
                    CreatedAt = new DateTime(2024, 1, 1),
                    UpdatedAt = new DateTime(2024, 1, 1)
                });
            }

            modelBuilder.Entity<Product>().HasData(products);

            // Seed Orders
            var orders = new List<Order>();
            var customerNames = new[] { "John Doe", "Jane Smith", "Bob Johnson", "Alice Brown", "Charlie Wilson", "Diana Prince", "Eve Adams", "Frank Miller", "Grace Lee", "Henry Ford" };
            var emails = new[] { "john@example.com", "jane@example.com", "bob@example.com", "alice@example.com", "charlie@example.com", "diana@example.com", "eve@example.com", "frank@example.com", "grace@example.com", "henry@example.com" };

            int orderId = 1;
            for (int i = 0; i < 30; i++)
            {
                var product = products[i % products.Count];
                var orderDate = new DateTime(2024, 1, 1).AddDays(-i);
                var deliveryDate = (i % 2 == 0) ? (DateTime?)orderDate.AddDays(7) : null;

                orders.Add(new Order
                {
                    Id = orderId++,
                    ProductId = product.Id,
                    OrderNumber = $"ORD-{orderDate:yyyyMMdd}-{i + 1:D4}",
                    CustomerName = customerNames[i % customerNames.Length],
                    CustomerEmail = $"customer{i + 1}@example.com",
                    Quantity = random.Next(1, Math.Min(10, product.StockQuantity + 1)),
                    OrderDate = orderDate,
                    DeliveryDate = deliveryDate,
                    CreatedAt = orderDate,
                    UpdatedAt = new DateTime(2024, 1, 1)
                });
            }

            // Ensure unique emails and order numbers
            var uniqueOrders = orders.GroupBy(o => o.CustomerEmail).Select(g => g.First()).ToList();
            while (uniqueOrders.Count < 30)
            {
                var product = products[(uniqueOrders.Count) % products.Count];
                var orderDate = new DateTime(2024, 1, 1).AddDays(-uniqueOrders.Count);
                var deliveryDate = (uniqueOrders.Count % 2 == 0) ? (DateTime?)orderDate.AddDays(7) : null;
                var newOrder = new Order
                {
                    Id = orderId++,
                    ProductId = product.Id,
                    OrderNumber = $"ORD-{orderDate:yyyyMMdd}-{uniqueOrders.Count + 1:D4}",
                    CustomerName = customerNames[uniqueOrders.Count % customerNames.Length],
                    CustomerEmail = $"customer{uniqueOrders.Count + 1}@example.com",
                    Quantity = random.Next(1, Math.Min(10, product.StockQuantity + 1)),
                    OrderDate = orderDate,
                    DeliveryDate = deliveryDate,
                    CreatedAt = orderDate,
                    UpdatedAt = new DateTime(2024, 1, 1)
                };
                uniqueOrders.Add(newOrder);
            }

            modelBuilder.Entity<Order>().HasData(uniqueOrders.Take(30));
        }
    }
}