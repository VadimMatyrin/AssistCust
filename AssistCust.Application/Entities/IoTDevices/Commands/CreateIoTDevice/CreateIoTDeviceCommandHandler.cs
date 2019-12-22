using AssistCust.Application.Exceptions;
using AssistCust.Application.Interfaces;
using AssistCust.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AssistCust.Application.Entities.IoTDevices.Commands.CreateIoTDevice
{
    public class CreateIoTDeviceCommandHandler : IRequestHandler<CreateIoTDeviceCommand, Guid>
    {
        private readonly IAssistDbContext _context;
        private readonly IUserAccessService _userAccessService;
        public CreateIoTDeviceCommandHandler(IAssistDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
        }
        public async Task<Guid> Handle(CreateIoTDeviceCommand request, CancellationToken cancellationToken)
        {
           // if (!(await _userAccessService.IsCompanyOwnerAsync(request.CompanyShopId)))
                //throw new InsufficientPrivilegesException(nameof(IoTDevice));

            var entity = new IoTDevice
            {
                Id = request.Id,
                CompanyShopId = request.CompanyShopId
            };

            if (request.RegistrationTime != default)
            {
                entity.RegistrationTime = request.RegistrationTime;
            }

            _context.IoTDevices.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
