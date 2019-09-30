using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.Purchases.Commands.UpdatePurchase
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdatePurchaseCommand, Unit>
    {
        private readonly IAssistDbContext _context;
        public UpdateProductCommandHandler(IAssistDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Purchases.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Purchase), request.Id);
            }

            entity.Id = request.Id;
            entity.UserId = request.UserId;
            entity.CompanyShopId = request.CompanyShopId;
            entity.PurchaseTime = request.PurchaseTime;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
