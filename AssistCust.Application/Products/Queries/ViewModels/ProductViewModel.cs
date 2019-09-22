using AutoMapper;
using AssistCust.Application.Interfaces.Mapping;
using AssistCust.Domain.Entities;

namespace AssistCust.Application.Products.Queries.ViewModels
{
    public class ProductViewModel : IHaveCustomMapping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Product, ProductViewModel>()
               .ForMember(pDTO => pDTO.Id, opt => opt.MapFrom(p => p.Id))
               .ForMember(pDTO => pDTO.Name, opt => opt.MapFrom(p => p.Name))
               .ForMember(pDTO => pDTO.Description, opt => opt.MapFrom(p => p.Description))
               .ForMember(pDTO => pDTO.CompanyId, opt => opt.MapFrom(p => p.CompanyId));
        }
    }
}
