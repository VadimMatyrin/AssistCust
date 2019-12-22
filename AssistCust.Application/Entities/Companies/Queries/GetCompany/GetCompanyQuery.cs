using AssistCust.Application.Companies.Queries.ViewModels;
using AssistCust.Application.Products.Queries.ViewModels;
using MediatR;

namespace AssistCust.Application.Companies.Queries.GetCompany
{
    public class GetCompanyQuery : IRequest<CompanyViewModel>
    {
        public int Id { get; set; }
    }
}
