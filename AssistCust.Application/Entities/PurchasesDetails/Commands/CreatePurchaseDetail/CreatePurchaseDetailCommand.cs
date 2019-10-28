using MediatR;

namespace AssistCust.Application.PurchaseDetails.Commands.CreatePurchaseDetail
{
    public class CreatePurchaseDetailCommand : IRequest<int>
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int PurchaseId { get; set; }
    }
}
