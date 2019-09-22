using AssistCust.Application.Products.Queries.GetAllProductsByCompany;
using AssistCust.Application.Products.Queries.GetProduct;
using AssistCust.Application.Products.Queries.ViewModels;
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
        public Task<ProductsListViewModel> GetProductsByCompany(int id)
        {
            return Mediator.Send(new GetAllProductsByCompanyQuery { CompanyId = id });
        }
    }
}
