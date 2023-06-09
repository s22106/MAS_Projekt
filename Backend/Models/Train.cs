using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Train
    {
        public int TrainId { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(15)]
        public string Type { get; set; }
        public IEnumerable<Transit> Transits { get; set; }
        public IEnumerable<Wagon> Wagons { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}