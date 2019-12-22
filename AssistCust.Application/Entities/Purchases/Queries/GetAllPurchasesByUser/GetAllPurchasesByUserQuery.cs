using AssistCust.Application.Purchases.Queries.ViewModels;
using MediatR;

namespace AssistCust.Application.Purchases.Queries.GetAllPurchasesInShopByUserQuery
{
    public class GetAllPurchasesByUserQuery : IRequest<PurchaseListViewModel>
    {
    }
}
