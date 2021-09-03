//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using YNHM.Entities.Models;

//namespace YNHM.Entities.TestResources
//{
//    public class Test
//    {
//        public Test()
//        {

//        }
//        //TODO: VASSILIS: Bind test to person
//        public Test(QuestionSet questionSet)
//        {
//            QuestionSet = questionSet;
//            Name = questionSet.Name;
//            Answers = new List<Answer>();
//        }

//        public int TestId { get; set; }
//        public string Name { get; set; }
//        public List<Question> Questions { get; set; }
//        public List<Answer> Answers { get; set; }

//        //Navigation properties
//        [Key,ForeignKey("HouseSeeker")]
//        public int HouseSeekerId { get; set; }
//        [Required]
//        public virtual HouseSeeker HouseSeeker{ get; set; }
        
        
//        //TODO: VASSILIS: Change this

//        public int QuestionSetId { get; set; }
//        public virtual QuestionSet QuestionSet { get; set; }

//        //Methods
//        public void AnswerQuestions(Question question, AnswerType userAnswer, AnswerType importance,AnswerType preferedAnswer)
//        {
//            Answer a = new Answer(question);

//            a.MyAnswer = userAnswer;
//            a.Importance = importance;
//            a.PreferedAnswer = preferedAnswer;
//            Answers.Add(a);
//        }
//    }

//}
