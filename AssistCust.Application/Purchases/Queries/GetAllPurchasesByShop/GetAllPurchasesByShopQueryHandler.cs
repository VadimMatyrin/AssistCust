using AssistCust.Application.Interfaces;
using AssistCust.Application.Purchases.Queries.ViewModels;
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

        public GetAllPurchasesByShopQueryHandler(IAssistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PurchaseListViewModel> Handle(GetAllPurchasesByShopQuery request, CancellationToken cancellationToken)
        {
            var purchases = await _context.Purchases.Where(p => p.CompanyShopId == request.ShopId).ToListAsync(cancellationToken);

            var model = new PurchaseListViewModel
            {
                Purchases = _mapper.Map<IEnumerable<PurchaseViewModel>>(purchases)
            };

            return model;
        }
    }
}
