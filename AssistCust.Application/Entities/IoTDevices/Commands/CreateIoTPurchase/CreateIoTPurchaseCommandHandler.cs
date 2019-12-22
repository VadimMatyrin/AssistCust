using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.Entities.IoTDevices.Commands.CreateIoTPurchase
{
    public class CreateIoTPurchaseCommandHandler : IRequestHandler<CreateIoTPurchaseCommand, int>
    {
        private readonly IAssistDbContext _context;
        private readonly IUserAccessService _userAccessService;
        public CreateIoTPurchaseCommandHandler(IAssistDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
        }
        public async Task<int> Handle(CreateIoTPurchaseCommand request, CancellationToken cancellationToken)
        {
            var iotDevice = _context.IoTDevices.FirstOrDefault(d => d.Id == request.IoTDeviceId); 
            if(iotDevice is null || iotDevice.CompanyShopId != request.CompanyShopId)
            {
                throw new NotFoundException(nameof(iotDevice), request.IoTDeviceId);
            }

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
