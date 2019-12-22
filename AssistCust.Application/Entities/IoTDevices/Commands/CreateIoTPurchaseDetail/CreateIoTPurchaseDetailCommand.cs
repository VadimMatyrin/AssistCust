using MediatR;
using System;

namespace AssistCust.Application.Entities.IoTDevices.Commands.CreateIoTPurchaseDetail
{
    public class CreateIoTPurchaseDetailCommand : IRequest<int>
    {
        public Guid IoTDeviceId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public int PurchaseId { get; set; }
    }
}
