using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
