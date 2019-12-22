using MediatR;
using System;

namespace AssistCust.Application.Entities.IoTDevices.Commands.CreateIoTDevice
{
    public class CreateIoTDeviceCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public DateTime RegistrationTime { get; set; }
        public int CompanyShopId { get; set; }
    }
}
