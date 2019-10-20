using AssistCust.Application.PurchaseDetails.Queries.ViewModels;
using MediatR;

namespace AssistCust.Application.PurchaseDetails.Queries.GetPurchaseDetail
{
    public class GetPurchaseDetailQuery : IRequest<PurchaseDetailViewModel>
    {
        public int Id { get; set; }
    }
}
