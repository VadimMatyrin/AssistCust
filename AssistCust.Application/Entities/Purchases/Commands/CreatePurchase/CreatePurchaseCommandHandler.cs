using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.Purchases.Commands.CreatePurchase
{
    public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, int>
    {
        private readonly IAssistDbContext _context;
        private readonly IUserAccessService _userAccessService;
        public CreatePurchaseCommandHandler(IAssistDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
        }
        public async Task<int> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var userId = _userAccessService.UserId;;
            if (request.UserId != null && (await _userAccessService.IsCompanyOwnerOrShopManagerAsync(request.CompanyShopId)))
            {
                userId = request.UserId;
            }

            var entity = new Purchase
            {
                UserId = userId,
                CompanyShopId = request.CompanyShopId,
                PurchaseTime = request.PurchaseTime
            };

            _context.Purchases.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
