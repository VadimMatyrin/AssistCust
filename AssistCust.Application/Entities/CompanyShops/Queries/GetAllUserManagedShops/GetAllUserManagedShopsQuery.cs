using AssistCust.Application.CompanyShops.Queries.ViewModels;
using MediatR;

namespace AssistCust.Application.CompanyShops.Queries.GetAllUserManagedShops
{
    public class GetAllUserManagedShopsQuery : IRequest<CompanyShopsListViewModel>
    {
    }
}
