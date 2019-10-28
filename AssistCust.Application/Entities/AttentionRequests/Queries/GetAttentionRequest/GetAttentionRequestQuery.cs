using AssistCust.Application.AttentionRequests.Queries.ViewModels;
using MediatR;

namespace AssistCust.Application.AttentionRequests.Queries.GetAttentionRequest
{
    public class GetAttentionRequestQuery : IRequest<AttentionRequestViewModel>
    {
        public int Id { get; set; }
    }
}
