using AssistCust.Application.Products.Queries.ViewModels;
using MediatR;

namespace AssistCust.Application.Products.Queries.GetAllProductsByCompany
{
    public class GetAllProductsByCompanyQuery : IRequest<ProductsListViewModel>
    {
        public int CompanyId { get; set; }
    }
}
