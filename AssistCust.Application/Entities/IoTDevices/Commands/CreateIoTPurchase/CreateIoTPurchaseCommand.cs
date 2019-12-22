using MediatR;
using System;

namespace AssistCust.Application.Entities.IoTDevices.Commands.CreateIoTPurchase
{
    public class CreateIoTPurchaseCommand : IRequest<int>
    {
        public Guid IoTDeviceId { get; set; }
        public string UserId { get; set; }
        public int CompanyShopId { get; set; }
        public DateTime PurchaseTime { get; set; }
    }
}
