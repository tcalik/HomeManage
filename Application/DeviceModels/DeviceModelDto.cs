using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DeviceModels
{
    public class DeviceModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DeviceType { get; set; }
        public string DeviceBrand { get; set; }
        public string DefaultRechange { get; set; }
    }
}
