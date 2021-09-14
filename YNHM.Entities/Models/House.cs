using System.Collections.Generic;

namespace YNHM.Entities.Models
{
    public class House
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public int Floor { get; set; }
        public int Area { get; set; }
        public int Bedrooms { get; set; }
        public int Rent { get; set; }

        public House()
        {
            Roomies = new List<Roomie>();
        }

        //Navigation properties
        public virtual ICollection<Roomie> Roomies { get; set; }
    }
}
