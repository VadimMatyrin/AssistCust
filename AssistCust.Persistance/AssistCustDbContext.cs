using System;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AssistCust.Persistance
{
    public class AssistCustDbContext: ApiAuthorizationDbContext<User>, IAssistDbContext
    {
        public DbSet<Company>  Companies { get; set; }
        public DbSet<CompanyShop> CompanyShops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<AttentionRequest> AttentionRequests { get; set; }
        public DbSet<IoTDevice> IoTDevices { get; set; }

        public AssistCustDbContext(DbContextOptions<AssistCustDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssistCustDbContext).Assembly);
        }
    }
}
