using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options)
                 : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<OrderDetail>().HasKey(x => new { OrderID = x.OrderId, ProductID = x.ProductId });

            // Relationships
            builder.Entity<OrderDetail>()
             .HasOne(pt => pt.Orders)
             .WithMany(p => p.OrderODs)
             .HasForeignKey(pt => pt.OrderId).HasPrincipalKey(pt => pt.OrderId)
             .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderDetail>()
                .HasOne(pt => pt.Products)
                .WithMany(t => t.ProODs)
                .HasForeignKey(pt => pt.ProductId).HasPrincipalKey(pt => pt.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            

            // Put this at the end of your configure method

            //builder.Entity<OrderDetail>(entity =>
            //{
            //    entity.HasKey(e => new { e.OrderID, e.ProductID });

            //    entity.HasIndex(e => e.ProductID);

            //    entity.Property(e => e.OrderID).HasColumnName("OrderID");

            //    entity.Property(e => e.ProductID).HasColumnName("ProductID");

            //    entity.HasOne(d => d.Orders)
            //        .WithMany(p => p.OrderDetails)
            //        .HasForeignKey(d => d.OrderID)
            //        .IsRequired()
            //        .OnDelete(DeleteBehavior.Cascade);

            //    entity.HasOne(d => d.Products)
            //        .WithMany(p => p.OrderDetails)
            //        .HasForeignKey(d => d.ProductID)
            //        .IsRequired()
            //        .OnDelete(DeleteBehavior.Cascade);
            //});


            base.OnModelCreating(builder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=InvoiceDbCore;Trusted_Connection=True;MultipleActiveResultSets=true");
        //    base.OnConfiguring(builder);
        //}

        
            
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Company> Companys { get; set; }
    }
}
