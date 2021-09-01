using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNHM.Entities.Models
{
    public class HouseManager : Person
    {
        public int HouseManagerId { get; set; }

        //Navigation properties
        //public virtual ICollection<House> OwnsHouses { get; set; }




    }
}
