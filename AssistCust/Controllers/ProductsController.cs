using AssistCust.Application.Products.Queries.GetProduct;
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
    }
}
