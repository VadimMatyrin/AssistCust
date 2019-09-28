using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.CompanyShops.Commands.UpdateCompanyShop
{
    public class UpdateCompanyShopCommandHandler : IRequestHandler<UpdateCompanyShopCommand, Unit>
    {
        private readonly IAssistDbContext _context;
        public UpdateCompanyShopCommandHandler(IAssistDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateCompanyShopCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CompanyShops.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CompanyShop), request.Id);
            }

            entity.Id = request.Id;
            entity.ShopName = request.ShopName;
            entity.State = request.State;
            entity.City = request.City;
            entity.AddressField1 = request.AddressField1;
            entity.AddressField2 = request.AddressField2;
            entity.UserId = request.UserId;
            entity.CompanyId = request.CompanyId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
