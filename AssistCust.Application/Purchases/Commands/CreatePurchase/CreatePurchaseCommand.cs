using AssistCust.Application.Interfaces.Mapping;
using AssistCust.Application.Products.Queries.ViewModels;
using AssistCust.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;

namespace AssistCust.Application.Purchases.Commands.CreatePurchase
{
    public class CreatePurchaseCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int CompanyShopId { get; set; }
        public DateTime PurchaseTime { get; set; }
    }
}
