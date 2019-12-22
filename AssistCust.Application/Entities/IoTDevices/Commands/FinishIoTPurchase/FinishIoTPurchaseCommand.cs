using MediatR;
using System;

namespace AssistCust.Application.Entities.IoTDevices.Commands.FinishIoTPurchase
{
    public class FinishIoTPurchaseCommand : IRequest<Unit>
    {
        public Guid IoTDeviceId { get; set; }
        public int PurchaseId { get; set; }
        public DateTime FinishTime { get; set; }
    }
}
