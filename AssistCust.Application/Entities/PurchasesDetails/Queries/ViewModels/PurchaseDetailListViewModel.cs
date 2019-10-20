using System.Collections.Generic;

namespace AssistCust.Application.PurchaseDetails.Queries.ViewModels
{
    public class PurchaseDetailListViewModel
    {
        public IEnumerable<PurchaseDetailViewModel> PurchaseDetails { get; set; }
    }
}
