using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YNHM.Entities.TestResources;

namespace YNHM.WebApp.Models
{
    public class TakeTestVM
    {
        public Test Test { get; set; }
        public QuestionSet QuestionSet { get; set; }

        public Answer Answer { get; set; }
        public AnswerType AnswerType { get; set; }
        public Importance Importance { get; set; }

        public TakeTestVM(Test test)
        {
            Test = test;
            QuestionSet = test.QuestionSet;
        }


    }
}