using MediatR;
using System;

namespace AssistCust.Application.AttentionRequests.Commands.CreateAttentionRequest
{
    public class CreateAttentionRequestCommand : IRequest<int>
    {
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
        public string ManagerId { get; set; }
        public int CompanyShopId { get; set; } 
    }
}
