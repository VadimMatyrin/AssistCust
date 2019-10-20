using AutoMapper;
using AssistCust.Application.Interfaces.Mapping;
using AssistCust.Domain.Entities;
using System;
using System.Collections.Generic;
using AssistCust.Application.Purchases.Commands.CreatePurchase;

namespace AssistCust.Application.PurchaseDetails.Queries.ViewModels
{
    public class PurchaseDetailViewModel : IHaveCustomMapping
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int PurchaseId { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<PurchaseDetail, PurchaseDetailViewModel>()
               .ForMember(pDTO => pDTO.Id, opt => opt.MapFrom(p => p.Id))
               .ForMember(pDTO => pDTO.ProductId, opt => opt.MapFrom(p => p.ProductId))
               .ForMember(pDTO => pDTO.Amount, opt => opt.MapFrom(p => p.Amount))
               .ForMember(pDTO => pDTO.PurchaseId, opt => opt.MapFrom(p => p.PurchaseId));
        }
    }
}
