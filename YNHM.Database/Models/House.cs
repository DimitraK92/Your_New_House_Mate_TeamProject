using System.Collections.Generic;

namespace YNHM.Database.Models
{
    public class House
    {
        public int HouseId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public int Area { get; set; }
        public int Floor { get; set; }
        public int Bedrooms { get; set; }
        public int Rent { get; set; }
        public string District { get; set; }
        public string MapLocation { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public int ManagerId { get; set; }
        public virtual Person Manager { get; set; }
    }
}
