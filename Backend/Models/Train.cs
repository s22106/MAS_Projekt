using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Train
    {
        public int TrainId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IEnumerable<Transit> Transits { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}