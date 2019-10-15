using AutoMapper;
using AssistCust.Application.Interfaces.Mapping;
using AssistCust.Domain.Entities;

namespace AssistCust.Application.CompanyShops.Queries.ViewModels
{
    public class CompanyShopViewModel : IHaveCustomMapping
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string AddressField1 { get; set; }
        public string AddressField2 { get; set; }
        public string UserId { get; set; }
        public int CompanyId { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<CompanyShop, CompanyShopViewModel>()
               .ForMember(pDTO => pDTO.Id, opt => opt.MapFrom(p => p.Id))
               .ForMember(pDTO => pDTO.ShopName, opt => opt.MapFrom(p => p.ShopName))
               .ForMember(pDTO => pDTO.State, opt => opt.MapFrom(p => p.State))
               .ForMember(pDTO => pDTO.City, opt => opt.MapFrom(p => p.City))
               .ForMember(pDTO => pDTO.AddressField1, opt => opt.MapFrom(p => p.AddressField1))
               .ForMember(pDTO => pDTO.AddressField2, opt => opt.MapFrom(p => p.AddressField2))
               .ForMember(pDTO => pDTO.UserId, opt => opt.MapFrom(p => p.UserId))
               .ForMember(pDTO => pDTO.CompanyId, opt => opt.MapFrom(p => p.CompanyId));
        }
    }
}
