using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.CompanyShops.Commands.DeleteCompanyShop
{
    public class DeleteCompanyShopCommandHandler : IRequestHandler<DeleteCompanyShopCommand>
    {
        private readonly IAssistDbContext _context;
        public DeleteCompanyShopCommandHandler(IAssistDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteCompanyShopCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CompanyShops.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CompanyShop), request.Id);
            }

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