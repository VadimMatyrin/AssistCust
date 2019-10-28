using MediatR;

namespace AssistCust.Application.AttentionRequests.Commands.DeleteAttentionRequest
{
    public class DeleteAttentionRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}