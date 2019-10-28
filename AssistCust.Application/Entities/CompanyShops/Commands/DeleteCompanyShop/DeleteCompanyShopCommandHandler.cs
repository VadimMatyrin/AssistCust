using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.CompanyShops.Commands.DeleteCompanyShop
{
    public class DeleteCompanyShopCommandHandler : IRequestHandler<DeleteCompanyShopCommand>
    {
        private readonly IAssistDbContext _context;
        private readonly IUserAccessService _userAccessService;
        public DeleteCompanyShopCommandHandler(IAssistDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
        }
        public async Task<Unit> Handle(DeleteCompanyShopCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CompanyShops.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CompanyShop), request.Id);
            }

            if (!(await _userAccessService.IsCompanyOwnerAsync(entity.CompanyId)))
                throw new InsufficientPrivilegesException(nameof(CompanyShop));

            var hasOrders = _context.Purchases.Any(p => p.CompanyShopId == entity.Id);
            if (hasOrders)
            {
                throw new DeleteFailureException(nameof(CompanyShop), request.Id, "There are existing purchases associated with this shop.");
            }

            _context.CompanyShops.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}