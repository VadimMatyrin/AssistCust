using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Application.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int UserId { get; set; }
    }
}
