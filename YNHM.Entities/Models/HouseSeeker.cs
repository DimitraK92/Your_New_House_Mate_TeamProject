using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YNHM.Entities.TestResources;

namespace YNHM.Entities.Models
{
    public class HouseSeeker : Person
    {
        public int HouseSeekerId { get; set; }
        public int? MatchPercent { get; set; }


        //Navigation Properties
        //[ForeignKey("Test")]
        public int? TestId { get; set; }
        public virtual Test Test { get; set; }

        //[ForeignKey("House")]
        //public int? HouseId { get; set; }
        public virtual House House { get; set; }

    }
}
