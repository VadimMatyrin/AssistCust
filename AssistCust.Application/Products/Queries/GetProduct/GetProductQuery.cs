namespace AssistCust.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : MediatR.IRequest<ProductViewModel>
    {
        public int Id { get; set; }
    }
}
