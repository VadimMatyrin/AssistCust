using AssistCust.Application.AttentionRequests.Queries.ViewModels;
using System.Collections.Generic;

namespace AssistCust.Application.AttentionRequests.Queries.ViewModels
{
    public class AttentionRequestsListViewModel
    {
        public IEnumerable<AttentionRequestViewModel> AttentionRequests { get; set; }
    }
}
