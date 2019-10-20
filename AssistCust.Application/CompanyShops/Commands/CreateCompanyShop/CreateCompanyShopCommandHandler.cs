using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.CompanyShops.Commands.CreateCompanyShop
{
    public class CreateCompanyShopCommandHandler : IRequestHandler<CreateCompanyShopCommand, int>
    {
        private readonly IAssistDbContext _context;
        private readonly IUserAccessService _userAccessService;
        public CreateCompanyShopCommandHandler(IAssistDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
        }
        public async Task<int> Handle(CreateCompanyShopCommand request, CancellationToken cancellationToken)
        {
            if (!(await _userAccessService.IsCompanyOwnerAsync(request.CompanyId)))
                throw new InsufficientPrivilegesException(nameof(CompanyShop));

            var entity = new CompanyShop
            {
                ShopName = request.ShopName,
                State = request.State,
                City = request.City,
                AddressField1 = request.AddressField1,
                AddressField2 = request.AddressField2,
                UserId = request.UserId,
                CompanyId = request.CompanyId
            };

            _context.CompanyShops.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
