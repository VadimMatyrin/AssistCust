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
        private readonly IMapper _mapper;
        public CreatePurchaseCommandHandler(IAssistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
        {
            var entity = new Purchase
            {
                UserId = request.UserId,
                CompanyShopId = request.CompanyShopId,
                PurchaseTime = request.PurchaseTime
            };

            _context.Purchases.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
