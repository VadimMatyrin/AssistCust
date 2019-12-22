using AssistCust.Application.Entities.IoTDevices.Commands.CreateIoTDevice;
using AssistCust.Application.Entities.IoTDevices.Commands.CreateIoTPurchase;
using AssistCust.Application.Entities.IoTDevices.Commands.CreateIoTPurchaseDetail;
using AssistCust.Application.Entities.IoTDevices.Commands.FinishIoTPurchase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistCust.Controllers
{
    public class IoTDevicesController : BaseController
    {
        [HttpPost]
        public Task<Guid> CreateIoTDevice([FromBody] CreateIoTDeviceCommand command)
        {
            return Mediator.Send(command);
        }

        [HttpPost]
        public Task<int> CreateIoTPurchase([FromBody] CreateIoTPurchaseCommand command)
        {
            return Mediator.Send(command);
        }

        [HttpPost]
        public Task<int> CreateIoTPurchaseDetail([FromBody] CreateIoTPurchaseDetailCommand command)
        {
            return Mediator.Send(command);
        }

        [HttpPut]
        public async Task<IActionResult> CreateIoTPurchaseDetail([FromBody] FinishIoTPurchaseCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
