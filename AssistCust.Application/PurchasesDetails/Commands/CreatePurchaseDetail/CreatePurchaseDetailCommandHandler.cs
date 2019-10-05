using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.PurchaseDetails.Commands.CreatePurchaseDetail
{
    public class CreatePurchaseDetailCommandHandler : IRequestHandler<CreatePurchaseDetailCommand, int>
    {
        private readonly IAssistDbContext _context;
        private readonly IMapper _mapper;
        public CreatePurchaseDetailCommandHandler(IAssistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreatePurchaseDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = new PurchaseDetail
            {
                ProductId = request.ProductId,
                Amount = request.Amount,
                PurchaseId = request.PurchaseId
            };

            _context.PurchaseDetails.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
