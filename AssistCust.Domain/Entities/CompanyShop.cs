﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Domain.Entities
{
    public class CompanyShop
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string AddressField1 { get; set; }
        public string AddressField2 { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } 
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
