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
        private readonly IUserAccessService _userAccessService;
        public UpdateCompanyShopCommandHandler(IAssistDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
        }
        public async Task<Unit> Handle(UpdateCompanyShopCommand request, CancellationToken cancellationToken)
        {
            if(!(await _userAccessService.IsCompanyOwnerOrShopManagerAsync(request.Id)))
                throw new InsufficientPrivilegesException(nameof(CompanyShop));

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

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
