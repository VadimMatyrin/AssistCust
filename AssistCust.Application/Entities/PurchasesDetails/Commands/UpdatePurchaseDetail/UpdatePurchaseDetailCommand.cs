using MediatR;
using System;

namespace AssistCust.Application.PurchaseDetails.Commands.UpdatePurchaseDetail
{
    public class UpdatePurchaseDetailCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int PurchaseId { get; set; }
    }
}
