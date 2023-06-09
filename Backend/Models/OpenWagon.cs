using System.ComponentModel.DataAnnotations;
using Backend.Models.Enum;

namespace API.Models
{
    public class OpenWagon
    {
        public int OpenWagonId { get; set; }
        [Required]
        public int WagonId { get; set; }
        [EnumDataType(typeof(OpenWagonType))]
        public OpenWagonType Type { get; set; }
        public virtual Wagon Wagon { get; set; }
    }
}