using AssistCust.Application.Companies.Commands.CreateCompany;
using AssistCust.Application.Companies.Commands.DeleteCompany;
using AssistCust.Application.Companies.Commands.UpdateCompany;
using AssistCust.Application.Companies.Queries.GetAllCompaniesByUser;
using AssistCust.Application.Companies.Queries.GetCompany;
using AssistCust.Application.Companies.Queries.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistCust.Controllers
{
    public class CompaniesController: BaseController
    {
        [HttpGet("{id}")]
        public Task<CompanyViewModel> Get(int id)
        {
            return Mediator.Send(new GetCompanyQuery { Id = id });
        }

        [HttpGet]
        public Task<CompanyListViewModel> GetAllCompaniesByUser()
        {
            return Mediator.Send(new GetAllCompaniesByUserQuery());
        }

        [HttpPost]
        public Task<int> Create([FromBody] CreateCompanyCommand command)
        {
            return Mediator.Send(command);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCompanyCommand { Id = id });
            return NoContent();
        }
    }
}
