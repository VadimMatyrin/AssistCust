using System;
using System.ComponentModel.DataAnnotations;

namespace AssistCust.Domain.Entities
{
    public class PurchaseDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Range(0, Int32.MaxValue)]
        public int Amount { get; set; }
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
    }
}
