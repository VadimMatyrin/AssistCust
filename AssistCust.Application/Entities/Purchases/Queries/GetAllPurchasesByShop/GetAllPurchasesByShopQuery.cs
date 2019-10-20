using AssistCust.Application.Purchases.Queries.ViewModels;
using MediatR;

namespace AssistCust.Application.Purchases.Queries.GetAllPurchasesByShop
{
    public class GetAllPurchasesByShopQuery : IRequest<PurchaseListViewModel>
    {
        public int ShopId { get; set; }
    }
}
