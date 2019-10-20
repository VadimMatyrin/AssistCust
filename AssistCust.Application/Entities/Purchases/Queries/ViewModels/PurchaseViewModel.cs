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

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Purchase, PurchaseViewModel>()
               .ForMember(pDTO => pDTO.Id, opt => opt.MapFrom(p => p.Id))
               .ForMember(pDTO => pDTO.UserId, opt => opt.MapFrom(p => p.UserId))
               .ForMember(pDTO => pDTO.CompanyShopId, opt => opt.MapFrom(p => p.CompanyShopId))
               .ForMember(pDTO => pDTO.PurchaseTime, opt => opt.MapFrom(p => p.PurchaseTime));
        }
    }
}
