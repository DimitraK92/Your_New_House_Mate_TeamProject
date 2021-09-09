using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YNHM.Entities.Models;

namespace YNHM.Entities.TestResources
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation properties
        public virtual IEnumerable<Roomie> Roomies { get; set; }
        public virtual IEnumerable<Question> Questions { get; set; }
    }

}
