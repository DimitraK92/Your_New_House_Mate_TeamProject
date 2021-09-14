using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using YNHM.Entities.Models;

namespace YNHM.Entities.TestResources
{
    public class Test
    {
        [ForeignKey("Roomie")]
        public int TestId { get; set; }
        public string Name { get; set; }

        //Navigation properties
        public virtual Roomie Roomie { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }

}
