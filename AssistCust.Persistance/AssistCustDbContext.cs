using System;
using AssistCust.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssistCust.Persistance
{
    public class AssistCustDbContext: DbContext
    {
        public DbSet<Company>  Companies { get; set; }
        public DbSet<CompanyShop> CompanyShops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails{ get; set; }
        public DbSet<User> Users { get; set; }

        public AssistCustDbContext(DbContextOptions<AssistCustDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssistCustDbContext).Assembly);
        }
    }
}
