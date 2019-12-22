using System;
using System.Collections.Generic;
using System.Text;

namespace AssistCust.Domain.Entities
{
    public class IoTDevice
    {
        public Guid Id { get; set; }
        public DateTime? RegistrationTime { get; set; }
    }
}
