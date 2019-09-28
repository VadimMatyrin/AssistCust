using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Application.CompanyShops.Commands.CreateCompanyShop
{
    public class CreateCompanyShopCommand : IRequest<int>
    {
        public string ShopName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string AddressField1 { get; set; }
        public string AddressField2 { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
    }
}
