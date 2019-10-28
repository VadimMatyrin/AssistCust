using System.Collections.Generic;

namespace AssistCust.Application.Purchases.Queries.ViewModels
{
    public class PurchaseListViewModel
    {
        public IEnumerable<PurchaseViewModel> Purchases { get; set; }
    }
}
