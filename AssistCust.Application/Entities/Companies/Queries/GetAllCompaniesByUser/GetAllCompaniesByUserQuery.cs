using AssistCust.Application.Companies.Queries.ViewModels;
using AssistCust.Application.Products.Queries.ViewModels;
using MediatR;

namespace AssistCust.Application.Companies.Queries.GetAllCompaniesByUser
{
    public class GetAllCompaniesByUserQuery : IRequest<CompanyListViewModel>
    {
    }
}
