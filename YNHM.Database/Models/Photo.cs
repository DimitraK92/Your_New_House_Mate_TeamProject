

namespace YNHM.Database.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string PhotoUrl { get; set; }

        public int? HouseId { get; set; }
        public virtual House House { get; set; }
    }
}
