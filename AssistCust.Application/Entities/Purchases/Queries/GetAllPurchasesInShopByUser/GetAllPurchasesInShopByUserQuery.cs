using AssistCust.Application.Purchases.Queries.ViewModels;
using MediatR;

namespace AssistCust.Application.Purchases.Queries.GetAllPurchasesInShopByUserQuery
{
    public class GetAllPurchasesInShopByUserQuery : IRequest<PurchaseListViewModel>
    {
        public string UserId { get; set; }
        public int CompanyShopId { get; set; }
    }
}
