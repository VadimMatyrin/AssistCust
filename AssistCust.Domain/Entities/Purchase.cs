using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CompanyShopId { get; set; }
        public CompanyShop CompanyShop { get; set; }
        public DateTime PurchaseTime { get; set; }
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
