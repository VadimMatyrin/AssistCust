using AssistCust.Application.Purchases.Queries.ViewModels;
using MediatR;

namespace AssistCust.Application.Purchases.Queries.GetPurchase
{
    public class GetPurchaseQuery : IRequest<PurchaseViewModel>
    {
        public int Id { get; set; }
    }
}
