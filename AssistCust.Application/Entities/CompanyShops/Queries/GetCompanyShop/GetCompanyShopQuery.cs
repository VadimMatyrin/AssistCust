using AssistCust.Application.CompanyShops.Queries.ViewModels;
using MediatR;

namespace AssistCust.Application.CompanyShops.Queries.GetCompanyShop
{
    public class GetCompanyShopQuery : IRequest<CompanyShopViewModel>
    {
        public int Id { get; set; }
    }
}
