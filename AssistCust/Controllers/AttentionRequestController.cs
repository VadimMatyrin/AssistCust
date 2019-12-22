using AssistCust.Application.AttentionRequests.Commands.CreateAttentionRequest;
using AssistCust.Application.AttentionRequests.Commands.DeleteAttentionRequest;
using AssistCust.Application.AttentionRequests.Commands.UpdateAttentionRequest;
using AssistCust.Application.AttentionRequests.Queries.GetAllShopAttentionRequests;
using AssistCust.Application.AttentionRequests.Queries.GetAttentionRequest;
using AssistCust.Application.AttentionRequests.Queries.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AssistCust.Controllers
{
    public class AttentionRequestController : BaseController
    {
        [HttpGet("{id}")]
        public Task<AttentionRequestViewModel> Get(int id)
        {
            return Mediator.Send(new GetAttentionRequestQuery { Id = id });
        }

        [HttpGet("{id}")]
        public Task<AttentionRequestsListViewModel> GetAllShopAttentionRequests(int id)
        {
            return Mediator.Send(new GetAllShopAttentionRequestsQuery { CompanyShopId = id });
        }

        [HttpPost]
        public Task<int> Create([FromBody] CreateAttentionRequestCommand command)
        {
            return Mediator.Send(command);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateAttentionRequestCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteAttentionRequestCommand { Id = id });
            return NoContent();

        }
    }
}
