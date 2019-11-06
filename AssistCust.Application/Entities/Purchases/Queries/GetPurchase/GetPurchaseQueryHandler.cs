using AutoMapper;
using AssistCust.Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using AssistCust.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AssistCust.Application.Exceptions;
using MediatR;
using AssistCust.Application.Purchases.Queries.ViewModels;

namespace AssistCust.Application.Purchases.Queries.GetPurchase
{
    public class GetPurchaseQueryHandler : IRequestHandler<GetPurchaseQuery, PurchaseViewModel>
    {
        private readonly IAssistDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserAccessService _userAccessService;

        public GetPurchaseQueryHandler(IAssistDbContext context, IMapper mapper, IUserAccessService userAccessService)
        {
            _context = context;
            _mapper = mapper;
            _userAccessService = userAccessService;
        }

        public async Task<PurchaseViewModel> Handle(GetPurchaseQuery request, CancellationToken cancellationToken)
        {
            if (!(await _userAccessService.IsPurchaseOwnerOrShopManagementAsync(request.Id)))
                throw new InsufficientPrivilegesException(nameof(Purchase));

            var purchase = _mapper.Map<PurchaseViewModel>(await _context
                .Purchases.Where(p => p.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (purchase == null)
            {
                throw new NotFoundException(nameof(Purchase), request.Id);
            }

            return purchase;
        }
    }
}
