using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Devices
{
    public class IndividualDeviceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceRechangeObject { get; set; }
        public int DeviceRechangeQuantity { get; set; }
        public string Room { get; set; }
    }
}
