using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.Entities.IoTDevices.Commands.FinishIoTPurchase
{
    public class FinishIoTPurchaseCommandHandler : IRequestHandler<FinishIoTPurchaseCommand, Unit>
    {
        private readonly IAssistDbContext _context;
        private readonly IUserAccessService _userAccessService;
        public FinishIoTPurchaseCommandHandler(IAssistDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
        }
        public async Task<Unit> Handle(FinishIoTPurchaseCommand request, CancellationToken cancellationToken)
        {
            var iotDevice = _context.IoTDevices.FirstOrDefault(d => d.Id == request.IoTDeviceId);
            var purchase = _context.Purchases.FirstOrDefault(p => p.Id == request.PurchaseId);
            if (iotDevice is null || purchase is null || iotDevice.CompanyShopId != purchase.CompanyShopId)
            {
                throw new NotFoundException(nameof(iotDevice), request.IoTDeviceId);
            }

            if (request.FinishTime == default)
            {
                purchase.FinishTime = DateTime.UtcNow;
            }
            else
            {
                purchase.FinishTime = request.FinishTime;
            }

            _context.Purchases.Update(purchase);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
