using AssistCust.Application.Purchases.Queries.ViewModels;
using MediatR;

namespace AssistCust.Application.Purchases.Queries.GetAllPurchasesByUser
{
    public class GetAllPurchasesByUserQuery : IRequest<PurchaseListViewModel>
    {
        public string UserId { get; set; }
    }
}
