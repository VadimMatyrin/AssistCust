using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.Entities.IoTDevices.Commands.CreateIoTPurchaseDetail
{
    public class CreateIoTPurchaseDetailCommandHandler : IRequestHandler<CreateIoTPurchaseDetailCommand, int>
    {
        private readonly IAssistDbContext _context;
        private readonly IUserAccessService _userAccessService;
        public CreateIoTPurchaseDetailCommandHandler(IAssistDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
        }
        public async Task<int> Handle(CreateIoTPurchaseDetailCommand request, CancellationToken cancellationToken)
        {

            var purchase = await _context.Purchases.FirstOrDefaultAsync(p => p.Id == request.PurchaseId);
            var iotDevice = await _context.IoTDevices.FirstOrDefaultAsync(d => d.Id == request.IoTDeviceId);
            if (purchase is null || iotDevice is null || purchase.CompanyShopId != iotDevice.CompanyShopId)
            {
                throw new NotFoundException(nameof(iotDevice), request.IoTDeviceId);
            }

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
