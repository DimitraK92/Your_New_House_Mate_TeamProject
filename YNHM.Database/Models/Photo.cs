using System.Collections.Generic;
using YNHM.Database.Models.Base;

namespace YNHM.Database.Models
{
    public class Photo : BaseModel
    {
        public string PhotoUrl { get; set; }

        public int? HouseId { get; set; }
        public virtual House House { get; set; }
    }
}
