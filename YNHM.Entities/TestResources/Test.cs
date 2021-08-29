using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNHM.Entities.TestResources
{
    public class Test
    {
        public int TestId { get; set; }
        public string Name { get; set; }

        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }

        //Navigation properties
        public virtual int PersonId { get; set; }
        //TODO: VASSILIS: Change this
        public string PersonName { get; set; }

        public void AnswerQuestions(Question question, AnswerType userAnswer, AnswerType importance,AnswerType preferedAnswer)
        {
            Answer a = new Answer(question);

            a.MyAnswer = userAnswer;
            a.Importance = importance;
            a.PreferedAnswer = preferedAnswer;
            Answers.Add(a);
        }
    }

    public class Answer
    {
        public Question Question{ get; set; }
        public Answer(Question question)
        {
            Question = question;
        }

        public AnswerType MyAnswer { get; set; }
        public AnswerType PreferedAnswer { get; set; }
        public AnswerType Importance { get; set; }

        public List<AnswerType> AcceptedAnswers { get; set; }
        public Importance Significance { get; set; }
    }

    public class Question
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
    }

    public class HouseMateMatching
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }

}
