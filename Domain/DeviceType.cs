﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DeviceType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<DeviceModel> DeviceModels { get; set; } = new List<DeviceModel>();
    }
}
