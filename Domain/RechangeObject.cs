using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RechangeObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid RechangeTypeId { get; set; }
        public RechangeType RechangeType { get; set; }
    }
}
