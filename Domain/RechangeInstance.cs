using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RechangeInstance
    {
        public Guid Id { get; set; }
        public Guid AffectedDeviceId { get; set; }
        public IndividualDevice AffectedDevice { get; set; }
        public DateTime rechangeDate { get; set; }
    }
}
