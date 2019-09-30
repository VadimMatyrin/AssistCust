using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.Purchases.Commands.DeletePurchase
{
    public class DeletePurchaseCommandCommandHandler : IRequestHandler<DeletePurchaseCommand, Unit>
    {
        private readonly IAssistDbContext _context;
        public DeletePurchaseCommandCommandHandler(IAssistDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeletePurchaseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Purchases.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Purchase), request.Id);
            }

            var hadDetails = _context.PurchaseDetails.Any(pd => pd.PurchaseId == entity.Id);
            if (hadDetails)
            {
                throw new DeleteFailureException(nameof(Purchase), request.Id, "There are existing details associated with this purchase.");
            }

            _context.Purchases.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}