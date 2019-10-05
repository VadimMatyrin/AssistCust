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
using AssistCust.Application.PurchaseDetails.Queries.ViewModels;

namespace AssistCust.Application.PurchaseDetails.Queries.GetPurchaseDetail
{
    public class GetPurchaseDetailQueryHandler : IRequestHandler<GetPurchaseDetailQuery, PurchaseDetailViewModel>
    {
        private readonly IAssistDbContext _context;
        private readonly IMapper _mapper;

        public GetPurchaseDetailQueryHandler(IAssistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PurchaseDetailViewModel> Handle(GetPurchaseDetailQuery request, CancellationToken cancellationToken)
        {
            var purchaseDetail = _mapper.Map<PurchaseDetailViewModel>(await _context
                .PurchaseDetails.Where(pd => pd.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (purchaseDetail == null)
            {
                throw new NotFoundException(nameof(PurchaseDetail), request.Id);
            }

            return purchaseDetail;
        }
    }
}
