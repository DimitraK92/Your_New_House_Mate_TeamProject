using System;
using System.Collections.Generic;
using System.Linq;

namespace YNHM.Entities.TestResources
{
    public class Comparison
    {
        public int CalculateMatchPercentage(Test test1, Test test2)
        {
            var questions1 = test1.Questions.ToList();
            var questions2 = test2.Questions.ToList();

            double userOneScore = CalculateScore(questions2, questions1);
            double possibleUserOneScore = CalculateScore(questions1, questions1);

            double userTwoScore = CalculateScore(questions1, questions2);
            double possibleUserTwoScore = CalculateScore(questions2, questions2);

            double userOnePercentage = CalculatePercentage(userOneScore, possibleUserTwoScore);
            double userTwoPercentage = CalculatePercentage(userTwoScore, possibleUserOneScore);

            int outcome = CalculateOutcome(userOnePercentage, userTwoPercentage);
            return (int)Math.Round(Math.Sqrt(userOnePercentage * userTwoPercentage));
        }

        private int CalculateOutcome(double userOnePercentage, double userTwoPercentage)
        {
            double percentageMultiplication = userOnePercentage * userTwoPercentage;
            double multiplicationSqrt = Math.Sqrt(percentageMultiplication);
            return (int)Math.Round(multiplicationSqrt);
        }

        private double CalculateScore(List<Question> answersTestOne, List<Question> answersTestTwo)
        {
            double userScore = 0;

            for (int i = 0; i < answersTestOne.Count(); i++)
            {
                var answer1 = answersTestOne[i];
                var answer2 = answersTestTwo[i];

                userScore += Compare(answer2, answer1);
            }
            return userScore;
        }
        private double Compare(Question question2, Question question1)
        {
            if (question2.Answer == question1.Answer) return 15d;
            else if (question2.Answer == "Maybe" || question1.Answer == "Maybe") return 5d;
            else return 1d;
        }
        private double CalculatePercentage(double firstValue, double secondValue)
        {
            return (firstValue / secondValue) * 100;
        }
    }
}
