using AutoMapper;
using AssistCust.Application.Interfaces.Mapping;
using AssistCust.Domain.Entities;
using System;
using System.Collections.Generic;
using AssistCust.Application.Purchases.Commands.CreatePurchase;

namespace AssistCust.Application.Purchases.Queries.ViewModels
{
    public class PurchaseViewModel : IHaveCustomMapping
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CompanyShopId { get; set; }
        public DateTime PurchaseTime { get; set; }
        public DateTime? FinistTime { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Purchase, PurchaseViewModel>();
        }
    }
}
