using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.Purchases.Commands.UpdatePurchase
{
    public class UpdatePurchaseCommandHandler : IRequestHandler<UpdatePurchaseCommand, Unit>
    {
        private readonly IAssistDbContext _context;
        private readonly IUserAccessService _userAccessService;
        public UpdatePurchaseCommandHandler(IAssistDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
    }
        public async Task<Unit> Handle(UpdatePurchaseCommand request, CancellationToken cancellationToken)
        {
            if (!(await _userAccessService.IsPurchaseOwnerOrShopManagementAsync(request.Id)))
                throw new InsufficientPrivilegesException(nameof(Purchase));

            var entity = await _context.Purchases.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Purchase), request.Id);
            }

            entity.Id = request.Id;
            entity.PurchaseTime = request.PurchaseTime;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
