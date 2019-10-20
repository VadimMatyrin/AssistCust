using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Application.Purchases.Queries.ViewModels;
using AssistCust.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.Purchases.Queries.GetAllPurchasesByShop
{
    public class GetAllPurchasesByShopQueryHandler : IRequestHandler<GetAllPurchasesByShopQuery, PurchaseListViewModel>
    {
        private readonly IAssistDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserAccessService _userAccessService;

        public GetAllPurchasesByShopQueryHandler(IAssistDbContext context, IMapper mapper, IUserAccessService userAccessService)
        {
            _context = context;
            _mapper = mapper;
            _userAccessService = userAccessService;
        }

        public async Task<PurchaseListViewModel> Handle(GetAllPurchasesByShopQuery request, CancellationToken cancellationToken)
        {
            if (!(await _userAccessService.IsCompanyOwnerOrShopManagerAsync(request.ShopId)))
                throw new InsufficientPrivilegesException(nameof(Purchase));

            var purchases = await _context.Purchases.Where(p => p.CompanyShopId == request.ShopId).ToListAsync(cancellationToken);

            var model = new PurchaseListViewModel
            {
                Purchases = _mapper.Map<IEnumerable<PurchaseViewModel>>(purchases)
            };

            return model;
        }
    }
}
