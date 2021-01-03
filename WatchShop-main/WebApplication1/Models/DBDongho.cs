using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Models
{
    public partial class DBDongho : DbContext
    {
        public DBDongho()
            : base("name=DBDongho")
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<cusAuthe> cusAuthes { get; set; }
        public virtual DbSet<cusAuthe_Roles> cusAuthe_Roles { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .Property(e => e.brandDesription)
                .IsUnicode(false);

            modelBuilder.Entity<cusAuthe>()
                .Property(e => e.nameAuthe)
                .IsUnicode(false);

            modelBuilder.Entity<cusAuthe>()
                .HasMany(e => e.cusAuthe_Roles)
                .WithRequired(e => e.cusAuthe)
                .HasForeignKey(e => e.idCusAuthe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cusAuthe>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.cusAuthe)
                .HasForeignKey(e => e.idCusAuthe);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.id_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.id_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Delivery>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Delivery)
                .HasForeignKey(e => e.id_deli);

            modelBuilder.Entity<Order>()
                .Property(e => e.total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.productDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.promotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.turnover)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.id_product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.id_product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.cusAuthe_Roles)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Status)
                .HasForeignKey(e => e.id_stt);
        }
    }
}
