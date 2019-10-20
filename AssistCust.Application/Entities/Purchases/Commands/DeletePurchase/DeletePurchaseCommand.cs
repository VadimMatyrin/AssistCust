using MediatR;

namespace AssistCust.Application.Purchases.Commands.DeletePurchase
{
    public class DeletePurchaseCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}