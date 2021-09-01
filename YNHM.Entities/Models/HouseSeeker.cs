using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YNHM.Entities.TestResources;

namespace YNHM.Entities.Models
{
    public class HouseSeeker : Person
    {
        public int HouseSeekerId { get; set; }
        public int MatchPercent { get; set; }


        //
        public virtual Test Test { get; set; }

        public virtual int? HouseId { get; set; }


    }
}
