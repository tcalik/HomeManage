using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RechangeObjects
{
    public class RechangeObjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RechangeType { get; set; }
    }
}
