using System.ComponentModel.DataAnnotations;
using Backend.Models.Enum;

namespace API.Models
{
    public class OpenWagon : Wagon
    {
        public int OpenWagonId { get; set; }
        [Required]
        [EnumDataType(typeof(OpenWagonType))]
        public OpenWagonType Type { get; set; }
        public virtual Wagon Wagon { get; set; }
    }
}