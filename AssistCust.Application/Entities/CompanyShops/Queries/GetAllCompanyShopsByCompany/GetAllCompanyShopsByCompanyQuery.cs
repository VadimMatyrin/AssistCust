using AssistCust.Application.CompanyShops.Queries.ViewModels;
using MediatR;

namespace AssistCust.Application.CompanyShops.Queries.GetAllCompanyShopsByCompany
{
    public class GetAllCompanyShopsByCompanyQuery : IRequest<CompanyShopsListViewModel>
    {
        public int CompanyId { get; set; }
    }
}
