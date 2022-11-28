using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ECommerceProject.Models
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<ECommerceProject.Models.Departaments> Departaments { get; set; }

        public System.Data.Entity.DbSet<ECommerceProject.Models.City> Cities { get; set; }

        //Desabilitar cascatas

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<ECommerceProject.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<ECommerceProject.Models.User> Users { get; set; }
        public IEnumerable<object> TaxPaers { get; internal set; }

        public System.Data.Entity.DbSet<ECommerceProject.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<ECommerceProject.Models.Tax> Taxes { get; set; }

        public System.Data.Entity.DbSet<ECommerceProject.Models.WareHouse> WareHouses { get; set; }

        public System.Data.Entity.DbSet<ECommerceProject.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<ECommerceProject.Models.OrderDetail> OrderDetails { get; set; }

        public System.Data.Entity.DbSet<ECommerceProject.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<ECommerceProject.Models.Status> Status { get; set; }

        public System.Data.Entity.DbSet<ECommerceProject.Models.Inventory> Inventories { get; set; }

        public System.Data.Entity.DbSet<ECommerceProject.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<ECommerceProject.Models.CompanyCustomer> CompanyCustomers { get; set; }

        public System.Data.Entity.DbSet<ECommerceProject.Models.NewOrderView> NewOrderViews { get; set; }

        public System.Data.Entity.DbSet<ECommerceProject.Models.OrderDetailsTmp> OrderDetailsTmps { get; set; }
    }
}