using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssistCust.Application.Interfaces
{
    public interface IUserAccessService
    {
        string UserId { get; }
        Task<bool> IsCompanyOwnerAsync(int companyId);
        Task<bool> IsShopManagerAsync(int shopId);
        Task<bool> IsCompanyOwnerOrShopManagerAsync(int shopId);
        Task<bool> IsPurchaseOwnerAsync(int purchaseId);
        Task<bool> IsPurchaseOwnerOrShopManagementAsync(int purchaseId);
    }
}
