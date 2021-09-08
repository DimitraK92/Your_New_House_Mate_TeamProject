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
        public Test()
        {

        }
        public Test(QuestionSet questionSet)
        {
            QuestionSet = questionSet;
            Name = questionSet.Name;
            Answers = new List<Answer>();
        }

        public int TestId { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }

        //Navigation properties
        [Required]
        public virtual IEnumerable<Roomie> Roomies { get; set; }

        public virtual QuestionSet QuestionSet { get; set; }

    }

}
