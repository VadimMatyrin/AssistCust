using AssistCust.Application.Purchases.Commands.CreatePurchase;
using AssistCust.Application.Purchases.Commands.DeletePurchase;
using AssistCust.Application.Purchases.Commands.UpdatePurchase;
using AssistCust.Application.Purchases.Queries.GetPurchase;
using AssistCust.Application.Purchases.Queries.GetAllPurchasesByShop;
using AssistCust.Application.Purchases.Queries.GetAllPurchasesInShopByUserQuery;
using AssistCust.Application.Purchases.Queries.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            return Mediator.Send(new GetAllPurchasesInShopByUserQuery { UserId = id });
        }

        [HttpGet("{id}")]
        public Task<PurchaseListViewModel> GetAllPurchasesByShop(int id)
        {
            return Mediator.Send(new GetAllPurchasesByShopQuery { ShopId = id });
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
