using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.PurchaseDetails.Commands.DeletePurchaseDetail
{
    public class DeletePurchaseDetailCommandCommandHandler : IRequestHandler<DeletePurchaseDetailCommand, Unit>
    {
        private readonly IAssistDbContext _context;
        private readonly IUserAccessService _userAccessService;
        public DeletePurchaseDetailCommandCommandHandler(IAssistDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
        }
        public async Task<Unit> Handle(DeletePurchaseDetailCommand request, CancellationToken cancellationToken)
        {

            var entity = await _context.PurchaseDetails.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PurchaseDetail), request.Id);
            }

            if (!(await _userAccessService.IsPurchaseOwnerOrShopManagementAsync(entity.PurchaseId)))
                throw new InsufficientPrivilegesException(nameof(PurchaseDetail));

            _context.PurchaseDetails.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}