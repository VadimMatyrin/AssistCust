using MediatR;

namespace AssistCust.Application.PurchaseDetails.Commands.DeletePurchaseDetail
{
    public class DeletePurchaseDetailCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}