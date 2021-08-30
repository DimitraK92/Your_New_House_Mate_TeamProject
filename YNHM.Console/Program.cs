using System.Collections.Generic;
using YNHM.Entities.Models;
using YNHM.Entities.TestResources;
using YNHM.RepositoryServices;
using System;
using System.Linq;
using System.Timers;
using System.Diagnostics;

namespace YNHM.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int digit;
            DummyTests dt = new DummyTests();
            QuestionSet houseMateMatching = new QuestionSet()
            {
                Name = "Housemate Matching",
                Questions = new List<Question>()
                {
                    //Housework
                    new Question() { QuestionId = 1, Text = "How much does cleanliness matter in general?" },
                    new Question() { QuestionId = 2, Text = "How much are you bothered by a sink full with plates?" },
                    new Question() { QuestionId = 3, Text = "Do you mind the house being dusty?" },
                    new Question() { QuestionId = 4, Text = "Is cleaning the toilet every day important to you?" },
                    
                    //Noise
                    new Question() { QuestionId = 5, Text = "How much does noise matter in general?" },
                    new Question() { QuestionId = 6, Text = "Do you listen to music loud?" },
                    new Question() { QuestionId = 7, Text = "How much do you value quiet in the house" },
                    new Question() { QuestionId = 8, Text = "How bothered will you be with playing musical instruments?" },

                    //Food
                    new Question() { QuestionId = 9, Text = "Is a vegan or vegetarian diet important to you?" },
                    new Question() { QuestionId = 10, Text = "Do you cook every day?" },
                    new Question() { QuestionId = 11, Text = "How important is keeping your own groceries separate?" },
                    new Question() { QuestionId = 12, Text = "How important is eating with your housemates?" },

                    //Animals
                    new Question() { QuestionId = 13, Text = "Do you like animal companions?" },
                    new Question() { QuestionId = 14, Text = "How much do you mind caring for the housemate's animal companions, if they are absent?" },

                    //Friends
                    new Question() { QuestionId = 15, Text = "How much do you mind friends coming over?" },
                    new Question() { QuestionId = 16, Text = "Do you mind friends or significant others staying overnight?" },
                    new Question() { QuestionId = 17, Text = "How much does hanging out with your housemates matter?" },

                    //Smoking
                    new Question() { QuestionId = 18, Text = "Do you mind others smoking in the house?" },
                    new Question() { QuestionId = 19, Text = "Do you mind others smoking weed in the house?" }
                }
            };

            var tests = dt.CreateTests();
            #region success
            Test myTest = new Test()
            {
                Name = houseMateMatching.Name,
                Questions = houseMateMatching.Questions,
                PersonName = $"Vassilis",
                Answers = dt.BigTestAnswers[0]
            };
            Test yourTest = new Test()
            {
                Name = houseMateMatching.Name,
                Questions = houseMateMatching.Questions,
                PersonName = $"Tasos",
                Answers = dt.BigTestAnswers[1]
            };
            TestComparison tc = new TestComparison();
            int result = tc.CalculateMatchPercentageWithAcceptedAnswers(myTest, yourTest);
            //int result2 = tc.CalculateMatchPercentage(myTest, yourTest);

            System.Console.WriteLine($"Results for {myTest.PersonName} vs {yourTest.PersonName}:\n" +
                                     $"Accepted Answers:\t\t{result}\n" +
                                     $"Point system    :\t\t{0}");
            #endregion


            #region Populate Big Test and Print
            List<Test> bigTests = new List<Test>();

            while (true)
            {
                for (int i = 0; i < 500; i++)
                {

                    Test matchTest = new Test()
                    {
                        Name = houseMateMatching.Name,
                        Questions = houseMateMatching.Questions,
                        PersonName = $"Person {i}",
                        Answers = new List<Answer>()
                    };

                    foreach (var question in matchTest.Questions)
                    {

                        Answer answer = new Answer(question)
                        {
                            AcceptedAnswers = new List<AnswerType>()
                        };

                        digit = rnd.Next(1, 15);
                        answer.MyAnswer = Respond(digit);

                        digit = rnd.Next(0, 4);
                        for (int j = 0; j < digit; j++)
                        {
                            digit = rnd.Next(1, 15);
                            var response = Respond(digit);
                            if (!answer.AcceptedAnswers.Contains(response))
                            {
                                answer.AcceptedAnswers.Add(response);
                            }
                        }

                        digit = rnd.Next(1, 15);
                        answer.Significance = AddSignificance(digit);

                        matchTest.Answers.Add(answer);
                    };
                    bigTests.Add(matchTest);
                }

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                MatchWithAcceptedAnswers(bigTests);

                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                System.Console.WriteLine("\n\nRunTime: " + elapsedTime);

                System.Console.ReadKey();
                bigTests.Clear();
            }
            
            #endregion





            //foreach (var t in tests)
            //{
            //    System.Console.WriteLine(
            //        $"{t.PersonName}");
            //    PrintResults(t);
            //    System.Console.ReadKey();
            //    System.Console.Clear();
            //}

            //MatchWithMultiplierSystem(tests);


            //var matchResult = testComparison.CalculateMatchPercentage(test, test2);

            //System.Console.WriteLine("Your match percent is: {0}", matchResult);



            System.Console.ReadKey();


        }


        private static AnswerType Respond(int num)
        {
            switch (num)
            {
                case 1: case 6: case 11: return AnswerType.NotAtAll;
                case 2:case 7:case 12: return AnswerType.NotSoMuch;
                case 3:case 8:case 13: return AnswerType.Indifferrent;
                case 4:case 9:case 14: return AnswerType.Somewhat;
                case 5:case 10:case 15: return AnswerType.VeryMuch;
            }
            return AnswerType.Indifferrent;
        }
        private static Importance AddSignificance(int num)
        {
            switch (num)
            {
                case 1: case 6: case 11: return Importance.TotallyUnimportant;
                case 2: case 7: case 12: return Importance.SomewhatUnimportant;
                case 3: case 8: case 13: return Importance.Indifferent;
                case 4: case 9: case 14: return Importance.SomewhatImportant;
                case 5: case 10: case 15: return Importance.VeryImportant;
                default: return Importance.Indifferent;
            }
            
        }

        private static Importance InputSignificance()
        {
            System.Console.WriteLine("1 . Not at all\t2 . Not so much\t3 . Indifferent\t4 . Somewhat\t5 . Very Much");
            string choice = System.Console.ReadLine();
            switch (choice)
            {
                case "1": return Importance.TotallyUnimportant;
                case "2": return Importance.SomewhatUnimportant;
                case "3": return Importance.Indifferent;
                case "4": return Importance.SomewhatImportant;
                case "5": return Importance.VeryImportant;
                default: return Importance.Indifferent;
            }
        }

        private static void MatchWithMultiplierSystem(List<Test> tests)
        {
            TestComparison testComparison = new TestComparison();

            for (int i = 0; i < tests.Count; i++)
            {
                var currentTest = tests[i];
                var restTests = tests.Where(x => x != tests[i]).ToList();

                for (int j = 0; j < restTests.Count; j++)
                {
                    var result = testComparison.CalculateMatchPercentage(currentTest, restTests[j]);
                    System.Console.WriteLine($"Test {i} vs Test {j}: {result}");
                }
                System.Console.ReadKey();
                System.Console.Clear();
            }
        }

        private static void MatchWithAcceptedAnswers(List<Test> tests)
        {
            TestComparison testComparison = new TestComparison();

            for (int i = 0; i < tests.Count; i++)
            {
                var currentTest = tests[i];
                var restTests = tests.Where(x => x != tests[i]).ToList();
                var avg = 0;
                var counter = 0;
                for (int j = 0; j < restTests.Count; j++)
                {
                    var result = testComparison.CalculateMatchPercentageWithAcceptedAnswers(currentTest, restTests[j]);
                    System.Console.WriteLine($"Test {i} vs Test {j}: {result}");
                    if (result<=100)
                    {
                        avg += result;
                        counter++;
                    }
                }
                
                System.Console.WriteLine($"Average match percentage: {avg/counter}");
            }
        }

        private static void AnswerQuestions(Test test)
        {
            for (int i = 0; i < test.Questions.Count; i++)
            {
                var q = test.Questions[i];
                Answer answer = new Answer(q);
                System.Console.WriteLine(answer.Question.Text);
                answer.MyAnswer = MakeChoice();
                System.Console.WriteLine("Importance");
                answer.Importance = MakeChoice();
                System.Console.WriteLine("Prefered Answer");
                answer.PreferedAnswer = MakeChoice();
                test.Answers.Add(answer);
                System.Console.Clear();
            }
        }

        public static AnswerType MakeChoice()
        {
            System.Console.WriteLine("1 . Not at all\t2 . Not so much\t3 . Indifferent\t4 . Somewhat\t5 . Very Much");
            string choice = System.Console.ReadLine();
            switch (choice)
            {
                case "1": return AnswerType.NotAtAll;
                case "2": return AnswerType.NotSoMuch;
                case "3": return AnswerType.Indifferrent;
                case "4": return AnswerType.Somewhat;
                case "5": return AnswerType.VeryMuch;
                default: return AnswerType.Indifferrent;
            }
        }

        private static void PrintResults(Test test)
        {
            System.Console.WriteLine(test.PersonName);
            foreach (var answer in test.Answers)
            {
                System.Console.WriteLine($"{answer.Question.QuestionId} {answer.Question.Text}\n" +
                                         $"Answer:\t\t\t{answer.MyAnswer}\n" +
                                         $"Importance:\t\t{answer.Significance}\n"
                + $"Prefered:\t\t");
                foreach (var aa in answer.AcceptedAnswers)
                {
                    System.Console.WriteLine($"{"",9}\t\t{aa}");
                }
            }
        }
    }
}
