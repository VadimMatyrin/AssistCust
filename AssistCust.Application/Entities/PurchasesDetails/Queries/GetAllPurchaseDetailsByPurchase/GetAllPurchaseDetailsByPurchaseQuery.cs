using AssistCust.Application.PurchaseDetails.Queries.ViewModels;
using MediatR;

namespace AssistCust.Application.PurchaseDetails.Queries.GetAllPurchaseDetailsByPurchase
{
    public class GetAllPurchaseDetailsByPurchaseQuery : IRequest<PurchaseDetailListViewModel>
    {
        public int PurchaseId { get; set; }
    }
}
