using AssistCust.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AssistCust.Application.Services
{
    public class UserAccessService : IUserAccessService
    {
        private readonly IAssistDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string UserId { get; }
        public UserAccessService(IAssistDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public async Task<bool> IsCompanyOwnerAsync(int companyId)
        {
            var isCompanyOwner = await _context.Companies.AnyAsync(c => c.Id == companyId && c.UserId == UserId);
            return isCompanyOwner;
        }

        public async Task<bool> IsShopManagerAsync(int shopId)
        {
            var isShopManagerOwner = await _context.CompanyShops.AnyAsync(c => c.Id == shopId && c.UserId == UserId);
            return isShopManagerOwner;
        }

        public async Task<bool> IsCompanyOwnerOrShopManagerAsync(int shopId)
        {
            var isShopOwner = await IsShopManagerAsync(shopId);
            if (isShopOwner)
                return true;

            var companyId = await _context.CompanyShops.Where(s => s.Id == shopId).Select(s => s.CompanyId).FirstOrDefaultAsync();
            if (companyId != default)
                return await IsCompanyOwnerAsync(companyId);

            return false;
        }

        public async Task<bool> IsPurchaseOwnerAsync(int purchaseId)
        {
            var isPurchaseOwner = await _context.Purchases.AnyAsync(c => c.Id == purchaseId && c.UserId == UserId);
            return isPurchaseOwner;
        }

        public async Task<bool> IsPurchaseOwnerOrShopManagerAsync(int purchaseId)
        {
            var isPurchaseOwner = await IsPurchaseOwnerAsync(purchaseId);
            if (isPurchaseOwner)
                return true;

            var shopId = await _context.Purchases.Where(p => p.Id == purchaseId).Select(p => p.CompanyShopId).FirstOrDefaultAsync();
            if (shopId != default)
                return await IsShopManagerAsync(shopId);

            return false;
        }
    }
}
