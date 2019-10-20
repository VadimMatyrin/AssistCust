using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Application.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
