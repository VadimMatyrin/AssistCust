using AssistCust.Application.CompanyShops.Commands.CreateCompanyShop;
using AssistCust.Application.CompanyShops.Commands.DeleteCompanyShop;
using AssistCust.Application.CompanyShops.Commands.UpdateCompanyShop;
using AssistCust.Application.CompanyShops.Queries.GetAllCompanyShopsByCompany;
using AssistCust.Application.CompanyShops.Queries.GetCompanyShop;
using AssistCust.Application.CompanyShops.Queries.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AssistCust.Controllers
{
    public class CompanyShopsController: BaseController
    {
        [HttpGet("{id}")]
        public Task<CompanyShopViewModel> Get(int id)
        {
            return Mediator.Send(new GetCompanyShopQuery { Id = id });
        }

        [HttpGet("{id}")]
        public Task<CompanyShopsListViewModel> GetAllCompanyShopsByCompany(int id)
        {
            return Mediator.Send(new GetAllCompanyShopsByCompanyQuery { CompanyId = id });
        }

        [HttpPost]
        public Task<int> Create([FromBody] CreateCompanyShopCommand command)
        {
            return Mediator.Send(command);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyShopCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCompanyShopCommand { Id = id });
            return NoContent();
        }
    }
}
