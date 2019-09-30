using AssistCust.Application.Interfaces;
using AssistCust.Application.Purchases.Queries.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.Purchases.Queries.GetAllPurchasesByUser
{
    public class GetAllPurchasesByUserQueryHandler : IRequestHandler<GetAllPurchasesByUserQuery, PurchaseListViewModel>
    {
        private readonly IAssistDbContext _context;
        private readonly IMapper _mapper;

        public GetAllPurchasesByUserQueryHandler(IAssistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PurchaseListViewModel> Handle(GetAllPurchasesByUserQuery request, CancellationToken cancellationToken)
        {
            var purchases = await _context.Purchases.Where(p => p.UserId == request.UserId).ToListAsync(cancellationToken);

            var model = new PurchaseListViewModel
            {
                Purchases = _mapper.Map<IEnumerable<PurchaseViewModel>>(purchases)
            };

            return model;
        }
    }
}
