using AssistCust.Application.Products.Queries.ViewModels;
using MediatR;

namespace AssistCust.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductViewModel>
    {
        public int Id { get; set; }
    }
}
