using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<CompanyShop> CompanyShops { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
