using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Token { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
