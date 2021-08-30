using System.Collections.Generic;

namespace YNHM.Entities.TestResources
{
    public class QuestionSet
    {
        public int QuestionSetId { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }

        //navigation properties
        public virtual IEnumerable<Test> Tests { get; set; }
    }

}
