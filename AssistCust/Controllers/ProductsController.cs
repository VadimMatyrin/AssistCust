using AssistCust.Application.Products.Commands.CreateProduct;
using AssistCust.Application.Products.Commands.DeleteProduct;
using AssistCust.Application.Products.Queries.GetAllProductsByCompany;
using AssistCust.Application.Products.Queries.GetProduct;
using AssistCust.Application.Products.Queries.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AssistCust.Controllers
{
    public class ProductsController: BaseController
    {
        [HttpGet("{id}")]
        public Task<ProductViewModel> Get(int id)
        {
            return Mediator.Send(new GetProductQuery { Id = id });
        }

        [HttpGet("{id}")]
        public Task<ProductsListViewModel> GetAllProductsByCompany(int id)
        {
            return Mediator.Send(new GetAllProductsByCompanyQuery { CompanyId = id });
        }

        [HttpPost]
        public Task<int> Create([FromBody] CreateProductCommand command)
        {
            return Mediator.Send(command);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id });
            return NoContent();
        }
    }
}
