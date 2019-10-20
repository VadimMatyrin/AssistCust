using AssistCust.Application.AttentionRequests.Queries.ViewModels;
using AssistCust.Application.CompanyShops.Queries.ViewModels;
using MediatR;

namespace AssistCust.Application.AttentionRequests.Queries.GetAllShopAttentionRequests
{
    public class GetAllShopAttentionRequestsQuery : IRequest<AttentionRequestsListViewModel>
    {
        public int CompanyShopId { get; set; }
    }
}
