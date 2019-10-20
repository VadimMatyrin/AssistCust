using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Application.AttentionRequests.Commands.UpdateAttentionRequest
{
    public class UpdateAttentionRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public bool IsResolved { get; set; }
        public string Message { get; set; }
    }
}
