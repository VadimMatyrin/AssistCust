using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace AssistCust.Domain.Entities
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Token { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<CompanyShop> CompanyShops{ get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
