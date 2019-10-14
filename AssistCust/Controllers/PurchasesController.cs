using AssistCust.Application.Purchases.Commands.CreatePurchase;
using AssistCust.Application.Purchases.Commands.DeletePurchase;
using AssistCust.Application.Purchases.Queries.GetAllPurchasesByUser;
using AssistCust.Application.Purchases.Queries.ViewModels;
using AssistCust.Application.Purchases.Queries.GetPurchase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AssistCust.Application.Purchases.Commands.UpdatePurchase;

namespace AssistCust.Controllers
{
    public class PurchasesController: BaseController
    {
        [HttpGet("{id}")]
        public Task<PurchaseViewModel> Get(int id)
        {
            return Mediator.Send(new GetPurchaseQuery { Id = id });
        }

        [HttpGet("{id}")]
        public Task<PurchaseListViewModel> GetAllPurchasesByUser(string id)
        {
            return Mediator.Send(new GetAllPurchasesByUserQuery { UserId = id });
        }

        [HttpPost]
        public Task<int> Create([FromBody] CreatePurchaseCommand command)
        {
            return Mediator.Send(command);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdatePurchaseCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletePurchaseCommand { Id = id });
            return NoContent();
        }
    }
}
