using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DeviceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DeviceTypeId { get; set; }
        public DeviceType DeviceType { get; set; }
        public Guid DeviceBrandId { get; set; }
        public DeviceBrand DeviceBrand { get; set; }
        public Guid DefaultRechangeId { get; set; }
        public RechangeObject DefaultRechange { get; set; }
        public int DefaulRechangeQuantity { get; set; }
        public ICollection<IndividualDevice> IndividualDevices { get; set; } = new List<IndividualDevice>();
    }
}
