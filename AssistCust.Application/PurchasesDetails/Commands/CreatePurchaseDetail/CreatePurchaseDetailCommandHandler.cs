using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.PurchaseDetails.Commands.CreatePurchaseDetail
{
    public class CreatePurchaseDetailCommandHandler : IRequestHandler<CreatePurchaseDetailCommand, int>
    {
        private readonly IAssistDbContext _context;
        private readonly IUserAccessService _userAccessService;
        public CreatePurchaseDetailCommandHandler(IAssistDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
        }
        public async Task<int> Handle(CreatePurchaseDetailCommand request, CancellationToken cancellationToken)
        {
            if (!(await _userAccessService.IsPurchaseOwnerOrShopManagementAsync(request.PurchaseId)))
                throw new InsufficientPrivilegesException(nameof(PurchaseDetail));

            var entity = new PurchaseDetail
            {
                ProductId = request.ProductId,
                Amount = request.Amount,
                PurchaseId = request.PurchaseId
            };

            _context.PurchaseDetails.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
