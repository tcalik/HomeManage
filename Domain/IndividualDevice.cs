using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class IndividualDevice
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public Guid DeviceModelId { get; set; }
        public DeviceModel DeviceModel{ get; set; }
        public Guid DeviceRechangeTypeId { get; set; }
        public RechangeType DeviceRechangeType { get; set; }
        public int DeviceRechangeQuantity { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }

    }
}
