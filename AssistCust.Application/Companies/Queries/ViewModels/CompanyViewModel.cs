using AutoMapper;
using AssistCust.Application.Interfaces.Mapping;
using AssistCust.Domain.Entities;

namespace AssistCust.Application.Companies.Queries.ViewModels
{
    public class CompanyViewModel : IHaveCustomMapping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int CompanyId { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Company, CompanyViewModel>()
               .ForMember(pDTO => pDTO.Id, opt => opt.MapFrom(p => p.Id))
               .ForMember(pDTO => pDTO.Name, opt => opt.MapFrom(p => p.Name))
               .ForMember(pDTO => pDTO.Country, opt => opt.MapFrom(p => p.Country));
        }
    }
}
