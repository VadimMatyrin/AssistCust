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
        public double Price { get; set; }
        public int CompanyId { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Product, ProductViewModel>();
            configuration.CreateMap<ProductViewModel, Product>();
        }
    }
}
