using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Application.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}