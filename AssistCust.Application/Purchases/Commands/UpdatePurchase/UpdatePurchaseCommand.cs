﻿using MediatR;
using System;

namespace AssistCust.Application.Purchases.Commands.UpdatePurchase
{
    public class UpdatePurchaseCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CompanyShopId { get; set; }
        public DateTime PurchaseTime { get; set; }
    }
}
