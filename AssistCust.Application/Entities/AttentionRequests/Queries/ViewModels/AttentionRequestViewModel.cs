using AssistCust.Application.Interfaces.Mapping;
using AssistCust.Domain.Entities;
using AutoMapper;
using System;

namespace AssistCust.Application.AttentionRequests.Queries.ViewModels
{ 
    public class AttentionRequestViewModel : IHaveCustomMapping
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool IsResolved { get; set; }
        public DateTime CreationDate { get; set; }
        public string ManagerId { get; set; }
        public int CompanyShopId { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<AttentionRequest, AttentionRequestViewModel>();
        }
    }
}
