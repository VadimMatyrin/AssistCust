using MediatR;
using System;

namespace AssistCust.Application.Purchases.Commands.CreatePurchase
{
    public class CreatePurchaseCommand : IRequest<int>
    {
        public int CompanyShopId { get; set; }
        public DateTime PurchaseTime { get; set; }
    }
}
