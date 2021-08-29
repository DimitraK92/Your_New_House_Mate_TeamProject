using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNHM.Entities.TestResources
{
    public class TestComparison
    {
        #region POINT SYSTEM WITH PREFERENCE MULTIPLIER
        //Much tweaking needed, results not good
        public int CalculateMatchPercentage(Test test1, Test test2)
        {
            double userOneScore = Compare(test2.Answers, test1.Answers);
            double possibleUserOneScore = Compare(test1.Answers, test1.Answers);

            double userTwoScore = Compare(test1.Answers, test2.Answers);
            double possibleUserTwoScore = Compare(test2.Answers, test2.Answers);

            double userOnePercentage = CalculatePercentage(userOneScore, possibleUserTwoScore);
            double userTwoPercentage = CalculatePercentage(userTwoScore, possibleUserOneScore);

            return (int)Math.Round(Math.Sqrt(userOnePercentage * userTwoPercentage));
        }

        private double Compare(List<Answer>answersTestOne, List<Answer> answersTestTwo)
        {            
            double userScore = 0;

            for (int i = 0; i < answersTestOne.Count; i++)
            {
                var answer1 = answersTestOne[i];
                var answer2 = answersTestTwo[i];


                userScore += CalculateScoreWithPreferenceMultiplier(answer2, answer1);
            }

            return userScore;
        }

        private double CalculateScoreWithPreferenceMultiplier(Answer preferedAnswer, Answer userAnswer)
        {
            int questionDifference = Math.Abs((int)preferedAnswer.PreferedAnswer - (int)userAnswer.MyAnswer);
            double tempScore = 0;

            switch (questionDifference)
            {
                case 0: tempScore = 50; break;
                case 1: tempScore = 20; break;
                case 2: tempScore = 10; break;
                case 3: tempScore = 5; break;
                case 4: tempScore = 1; break;
            }

            switch ((int)preferedAnswer.Importance)
            {
                case 5: tempScore *= 250; break;
                case 4: tempScore *= 50; break;
                case 3: tempScore *= 10; break;
                case 2: tempScore *= 1; break;
                case 1: tempScore *= 0; break;
            }
            return tempScore;
        }
        #endregion

        #region Preference with accepted answers list
        private double CalculateScoreWithAcceptedAnswers(List<AnswerType> acceptedAnswers, AnswerType comparedAnswer, Importance importance, AnswerType userAnswer)
        {
            //if ((acceptedAnswers.Count == 0 || acceptedAnswers.Count == 5) || acceptedAnswers == null)
            //{
            //    return (double)Importance.Indifferent;
            //}
            //else if (acceptedAnswers.Contains(userAnswer))
            //{
            //    if (userAnswer == comparedAnswer)
            //    {
            //        return (double)importance + 50;
            //    }
            //    else
            //    {
            //        return (double)importance;
            //    }
            //}
            //else return (double)Importance.Indifferent;

            if ((acceptedAnswers.Count == 0 || acceptedAnswers.Count == 5) || acceptedAnswers == null)
            {
                return (double)Importance.Indifferent;
            }
            else if (acceptedAnswers.Contains(userAnswer))
            {
                if (userAnswer == comparedAnswer) return (double)importance;
                //else if (importance != Importance.TotallyUnimportant)
                //{
                //    var difference = (int)Math.Abs(comparedAnswer - userAnswer);
                //    var answerImportance = (int)importance - difference;
                //    return answerImportance;
                //}
                else return 1;
            }
            else return 1;
                



        }

        private double CompareWithAcceptedAnswers(List<Answer> toBeCompared, List<Answer> comparedToThis)
        {
            double userScore = 0;

            for (int i = 0; i < toBeCompared.Count; i++)
            {
                var answer1 = toBeCompared[i].MyAnswer;
                var comparedToAnswer = comparedToThis[i].AcceptedAnswers;
                var compareToSelectedAnswer = comparedToThis[i].MyAnswer;
                var preference = comparedToThis[i].Significance;

                userScore += CalculateScoreWithAcceptedAnswers(comparedToAnswer, compareToSelectedAnswer,preference, answer1);
            }
            return userScore;
        }

        public int CalculateMatchPercentageWithAcceptedAnswers(Test test1, Test test2)
        {
            
            double userOneScore = CompareWithAcceptedAnswers(test1.Answers, test2.Answers);
            double possibleUserOneScore = CompareWithAcceptedAnswers(test1.Answers, test1.Answers);

            double userTwoScore = CompareWithAcceptedAnswers(test2.Answers, test1.Answers);
            double possibleUserTwoScore = CompareWithAcceptedAnswers(test2.Answers, test2.Answers);

            double userOnePercentage = CalculatePercentage(userOneScore, possibleUserTwoScore);
            double userTwoPercentage = CalculatePercentage(userTwoScore, possibleUserOneScore);

            if (userOnePercentage > 100 || userTwoPercentage > 100)
            {
                Console.WriteLine($"\n\t\t\t\t\tProblem:\n" +
                                  $"\t\t\t\t\tUser 1: Percentage {userOnePercentage}\n" +
                                  $"\t\t\t\t\t        Score: {userOneScore} vs {possibleUserTwoScore}\n" +
                                  $"\t\t\t\t\tUser 2  Percentage {userTwoPercentage}\n" +
                                  $"\t\t\t\t\t        Score: {userTwoScore} vs {possibleUserOneScore}\n");
            }


            double percentageMultiplication = userOnePercentage * userTwoPercentage;
            double multiplicationSqrt = Math.Sqrt(percentageMultiplication);
            return (int)Math.Round(multiplicationSqrt);
        }

        #endregion

        private double CalculatePercentage(double firstValue, double secondValue)
        {
            return (firstValue / secondValue) * 100;
        }



    }
}
