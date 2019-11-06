using MediatR;
using System;

namespace AssistCust.Application.Purchases.Commands.UpdatePurchase
{
    public class UpdatePurchaseCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DateTime PurchaseTime { get; set; }
        public DateTime FinishTime { get; set; }
    }
}
