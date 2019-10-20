using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Application.PurchaseDetails.Queries.ViewModels;
using AssistCust.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.PurchaseDetails.Queries.GetAllPurchaseDetailsByPurchase
{
    public class GetAllPurchaseDetailsByPurchaseQueryHandler : IRequestHandler<GetAllPurchaseDetailsByPurchaseQuery, PurchaseDetailListViewModel>
    {
        private readonly IAssistDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserAccessService _userAccessService;

        public GetAllPurchaseDetailsByPurchaseQueryHandler(IAssistDbContext context, IMapper mapper, IUserAccessService userAccessService)
        {
            _context = context;
            _mapper = mapper;
            _userAccessService = userAccessService;
        }

        public async Task<PurchaseDetailListViewModel> Handle(GetAllPurchaseDetailsByPurchaseQuery request, CancellationToken cancellationToken)
        {
            if (!(await _userAccessService.IsPurchaseOwnerOrShopManagementAsync(request.PurchaseId)))
                throw new InsufficientPrivilegesException(nameof(PurchaseDetail));

            var purchaseDetails = await _context.PurchaseDetails.Where(p => p.PurchaseId == request.PurchaseId).ToListAsync(cancellationToken);

            var model = new PurchaseDetailListViewModel
            {
                PurchaseDetails = _mapper.Map<IEnumerable<PurchaseDetailViewModel>>(purchaseDetails)
            };

            return model;
        }
    }
}
