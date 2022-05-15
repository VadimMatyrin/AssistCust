using System.Threading;
using System.Threading.Tasks;
using AssistCust.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssistCust.Application.Interfaces
{
    public interface IAssistDbContext
    {
        DbSet<Company> Companies { get; set; }
        DbSet<CompanyShop> CompanyShops { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Purchase> Purchases { get; set; }
        DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<AttentionRequest> AttentionRequests { get; set; }
        DbSet<IoTDevice> IoTDevices { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
