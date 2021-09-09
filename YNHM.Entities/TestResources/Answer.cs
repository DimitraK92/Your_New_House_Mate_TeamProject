using System.Collections.Generic;

namespace YNHM.Entities.TestResources
{
    public class Answer
    {
        public int Id { get; set; }
        
        public string Response { get; set; }

        public AnswerType MyAnswer { get; set; }
        //public AnswerType PreferedAnswer { get; set; }
        //public AnswerType Importance { get; set; }

        public List<AnswerType> AcceptedAnswers { get; set; }
        public Importance Significance { get; set; }

        //Navigation properties
        //public int? TestId { get; set; }
        //public virtual Test Test { get; set; }
    }

}
