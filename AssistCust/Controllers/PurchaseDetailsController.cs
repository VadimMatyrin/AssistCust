using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AssistCust.Application.PurchaseDetails.Queries.ViewModels;
using AssistCust.Application.PurchaseDetails.Queries.GetPurchaseDetail;
using AssistCust.Application.PurchaseDetails.Commands.CreatePurchaseDetail;
using AssistCust.Application.PurchaseDetails.Commands.UpdatePurchaseDetail;
using AssistCust.Application.PurchaseDetails.Commands.DeletePurchaseDetail;
using AssistCust.Application.PurchaseDetails.Queries.GetAllPurchaseDetailsByPurchase;

namespace AssistCust.Controllers
{
    public class PurchaseDetailsController : BaseController
    {
        [HttpGet("{id}")]
        public Task<PurchaseDetailViewModel> Get(int id)
        {
            return Mediator.Send(new GetPurchaseDetailQuery { Id = id });
        }

        [HttpGet("{id}")]
        public Task<PurchaseDetailListViewModel> GetAllPurchaseDetailsByPurchase(int id)
        {
            return Mediator.Send(new GetAllPurchaseDetailsByPurchaseQuery { PurchaseId = id });
        }

        [HttpPost]
        public Task<int> Create([FromBody] CreatePurchaseDetailCommand command)
        {
            return Mediator.Send(command);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdatePurchaseDetailCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletePurchaseDetailCommand { Id = id });
            return NoContent();
        }
    }
}
