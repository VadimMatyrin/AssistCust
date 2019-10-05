using AssistCust.Application.Interfaces;
using AssistCust.Application.PurchaseDetails.Queries.ViewModels;
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

        public GetAllPurchaseDetailsByPurchaseQueryHandler(IAssistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PurchaseDetailListViewModel> Handle(GetAllPurchaseDetailsByPurchaseQuery request, CancellationToken cancellationToken)
        {
            var purchaseDetails = await _context.PurchaseDetails.Where(p => p.PurchaseId == request.PurchaseId).ToListAsync(cancellationToken);

            var model = new PurchaseDetailListViewModel
            {
                PurchaseDetails = _mapper.Map<IEnumerable<PurchaseDetailViewModel>>(purchaseDetails)
            };

            return model;
        }
    }
}
