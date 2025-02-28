using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesDatePrediction_Domain.Entities.DB;

namespace SalesDatePrediction_Infraestructure.Persistence
{
    public class CoreDBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public CoreDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") ?? _configuration.GetConnectionString("salesDatePredictionConnection");
            if (!string.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            else
            {
                throw new ArgumentNullException("The connection string in empty");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                // Key
                entity.HasKey(e => e.Id);
                // Columns
                entity.Property(e => e.Id).HasColumnName("empid");
                entity.Property(e => e.FirstName).HasColumnName("firstname");
                entity.Property(e => e.LastName).HasColumnName("lastname");
                entity.Property(e => e.Title).HasColumnName("title");
                entity.Property(e => e.TitleCourtesy).HasColumnName("titleofcourtesy");
                entity.Property(e => e.BirthDate).HasColumnName("birthdate");
                entity.Property(e => e.HireDate).HasColumnName("hiredate");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.City).HasColumnName("city");
                entity.Property(e => e.Region).HasColumnName("region");
                entity.Property(e => e.PostalCode).HasColumnName("postalcode");
                entity.Property(e => e.Country).HasColumnName("country");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.ManagerId).HasColumnName("mgrid");
                // Foreign Keys
                entity.HasOne(e => e.Manager).WithMany(e => e.Subordinates).HasForeignKey(e => e.ManagerId);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                // Key
                entity.HasKey(e => e.Id);

                // Columns
                entity.Property(e => e.Id).HasColumnName("supplierid");
                entity.Property(e => e.CompanyName).HasColumnName("companyname");
                entity.Property(e => e.ContactName).HasColumnName("contactname");
                entity.Property(e => e.ContactTitle).HasColumnName("contacttitle");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.City).HasColumnName("city");
                entity.Property(e => e.Region).HasColumnName("region");
                entity.Property(e => e.PostalCode).HasColumnName("postalcode");
                entity.Property(e => e.Country).HasColumnName("country");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.Fax).HasColumnName("fax");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                // Key
                entity.HasKey(e => e.Id);

                // Columns
                entity.Property(e => e.Id).HasColumnName("categoryid");
                entity.Property(e => e.Name).HasColumnName("categoryname");
                entity.Property(e => e.Description).HasColumnName("description");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                // Key
                entity.HasKey(e => e.Id);

                // Columns
                entity.Property(e => e.Id).HasColumnName("productid");
                entity.Property(e => e.Name).HasColumnName("productname");
                entity.Property(e => e.SupplierId).HasColumnName("supplierid");
                entity.Property(e => e.CategoryId).HasColumnName("categoryid");
                entity.Property(e => e.Price).HasColumnName("unitprice");
                entity.Property(e => e.Discontinued).HasColumnName("discontinued");

                // Foreign Keys
                entity.HasOne(e => e.Supplier).WithMany(e => e.Products).HasForeignKey(e => e.SupplierId);
                entity.HasOne(e => e.Category).WithMany(e => e.Products).HasForeignKey(e => e.CategoryId);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                // Key
                entity.HasKey(e => e.Id);

                // Columns
                entity.Property(e => e.Id).HasColumnName("custid");
                entity.Property(e => e.CompanyName).HasColumnName("companyname");
                entity.Property(e => e.ContactName).HasColumnName("contactname");
                entity.Property(e => e.ContactTitle).HasColumnName("contacttitle");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.City).HasColumnName("city");
                entity.Property(e => e.Region).HasColumnName("region");
                entity.Property(e => e.PostalCode).HasColumnName("postalcode");
                entity.Property(e => e.Country).HasColumnName("country");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.Fax).HasColumnName("fax");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                // Key
                entity.HasKey(e => e.Id);

                // Columns
                entity.Property(e => e.Id).HasColumnName("shipperid");
                entity.Property(e => e.CompanyName).HasColumnName("companyname");
                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                // Key
                entity.HasKey(e => e.Id);

                // Columns
                entity.Property(e => e.Id).HasColumnName("orderid");
                entity.Property(e => e.CustomerId).HasColumnName("custid");
                entity.Property(e => e.EmployeeId).HasColumnName("empid");
                entity.Property(e => e.OrderDate).HasColumnName("orderdate");
                entity.Property(e => e.RequiredDate).HasColumnName("requireddate");
                entity.Property(e => e.ShippedDate).HasColumnName("shippeddate");
                entity.Property(e => e.ShipperId).HasColumnName("shipperid");
                entity.Property(e => e.Freight).HasColumnName("freight");
                entity.Property(e => e.ShipName).HasColumnName("shipname");
                entity.Property(e => e.ShipAddress).HasColumnName("shipaddress");
                entity.Property(e => e.ShipCity).HasColumnName("shipcity");
                entity.Property(e => e.ShipRegion).HasColumnName("shipregion");
                entity.Property(e => e.ShipPostalCode).HasColumnName("shippostalcode");
                entity.Property(e => e.ShipCountry).HasColumnName("shipcountry");

                // Foreign Keys
                entity.HasOne(e => e.Customer).WithMany(e => e.Orders).HasForeignKey(e => e.CustomerId);
                entity.HasOne(e => e.Employee).WithMany(e => e.Orders).HasForeignKey(e => e.EmployeeId);
                entity.HasOne(e => e.Shipper).WithMany(e => e.Orders).HasForeignKey(e => e.ShipperId);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                // Key
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                // Columns
                entity.Property(e => e.OrderId).HasColumnName("orderid");
                entity.Property(e => e.ProductId).HasColumnName("productid");
                entity.Property(e => e.Price).HasColumnName("unitprice");
                entity.Property(e => e.Quantity).HasColumnName("qty");
                entity.Property(e => e.Discount).HasColumnName("discount");

                // Foreign Keys
                entity.HasOne(e => e.Order).WithMany(e => e.Details).HasForeignKey(e => e.OrderId);
                entity.HasOne(e => e.Product).WithMany(e => e.OrderDetails).HasForeignKey(e => e.ProductId);
            });
        }
    }
}
