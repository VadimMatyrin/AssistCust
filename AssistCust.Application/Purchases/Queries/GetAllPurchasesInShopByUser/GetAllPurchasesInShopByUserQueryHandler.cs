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

namespace AssistCust.Application.Purchases.Queries.GetAllPurchasesInShopByUserQuery
{
    public class GetAllPurchasesInShopByUserQueryHandler : IRequestHandler<GetAllPurchasesInShopByUserQuery, PurchaseListViewModel>
    {
        private readonly IAssistDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserAccessService _userAccessService;

        public GetAllPurchasesInShopByUserQueryHandler(IAssistDbContext context, IMapper mapper, IUserAccessService userAccessService)
        {
            _context = context;
            _mapper = mapper;
            _userAccessService = userAccessService;
        }

        public async Task<PurchaseListViewModel> Handle(GetAllPurchasesInShopByUserQuery request, CancellationToken cancellationToken)
        {
            if(!(await _userAccessService.IsCompanyOwnerOrShopManagerAsync(request.CompanyShopId)))
                throw new InsufficientPrivilegesException(nameof(Purchase));

            var purchases = await _context.Purchases.Where(p => p.UserId == request.UserId && p.CompanyShopId == request.CompanyShopId).ToListAsync();

            var model = new PurchaseListViewModel
            {
                Purchases = _mapper.Map<IEnumerable<PurchaseViewModel>>(purchases)
            };

            return model;
        }
    }
}
