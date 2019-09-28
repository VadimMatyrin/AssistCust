using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Application.CompanyShops.Commands.DeleteCompanyShop
{
    public class DeleteCompanyShopCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}