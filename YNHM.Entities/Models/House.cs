using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public virtual ICollection<Roomie> Roomies { get; set; }
    }
}
