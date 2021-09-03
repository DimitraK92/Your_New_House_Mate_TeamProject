

using System.ComponentModel.DataAnnotations.Schema;

namespace YNHM.Entities.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string PhotoUrl { get; set; }

        [ForeignKey("House")]
        public int? HouseId { get; set; }
        public virtual House House { get; set; }
    }
}
