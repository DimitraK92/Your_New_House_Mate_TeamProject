using System;
using System.Collections.Generic;
using System.Linq;
using YNHM.Entities.TestResources;

namespace YNHM.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            List<int> Over90 = new List<int>();
            List<int> Over80 = new List<int>();
            List<int> Over70 = new List<int>();
            List<int> Over60 = new List<int>();
            List<int> Over50 = new List<int>();

            int a = 1000000;
            int b = a;
            while (a!=0)
            {
                Test test1 = new Test();
                test1.Questions = new List<Question>()
            {
                //Housework
                new Question() { Text = "How much does cleanliness matter in general?" },
                new Question() { Text = "How much are you bothered by a sink full with plates?" },
                new Question() { Text = "Do you mind the house being dusty?" },
                new Question() { Text = "Is cleaning the toilet every day important to you?" },

                //Noise
                new Question() { Text = "How much does noise matter in general?" },
                new Question() { Text = "Do you listen to music loud?" },
                new Question() { Text = "How much do you value quiet in the house" },
                new Question() { Text = "How bothered will you be with playing musical instruments?" },

                //Food
                new Question() { Text = "Is a vegan or vegetarian diet important to you?" },
                new Question() { Text = "Do you cook every day?" },
                new Question() { Text = "How important is keeping your own groceries separate?" },
                new Question() { Text = "How important is eating with your housemates?" },

                //Animals
                new Question() { Text = "Do you like animal companions?" },
                new Question() { Text = "How much do you mind caring for the housemate's animal companions, if they are absent?" },

                //Friends
                new Question() { Text = "How much do you mind friends coming over?" },
                new Question() { Text = "Do you mind friends or significant others staying overnight?" },
                new Question() { Text = "How much does hanging out with your housemates matter?" },

                //Smoking
                new Question() { Text = "Do you mind others smoking in the house?" },
                new Question() { Text = "Do you mind others smoking weed in the house?" }
            };

                Test test2 = new Test();
                test2.Questions = new List<Question>()
            {
                //Housework
                new Question() { Text = "How much does cleanliness matter in general?" },
                new Question() { Text = "How much are you bothered by a sink full with plates?" },
                new Question() { Text = "Do you mind the house being dusty?" },
                new Question() { Text = "Is cleaning the toilet every day important to you?" },

                //Noise
                new Question() { Text = "How much does noise matter in general?" },
                new Question() { Text = "Do you listen to music loud?" },
                new Question() { Text = "How much do you value quiet in the house" },
                new Question() { Text = "How bothered will you be with playing musical instruments?" },

                //Food
                new Question() { Text = "Is a vegan or vegetarian diet important to you?" },
                new Question() { Text = "Do you cook every day?" },
                new Question() { Text = "How important is keeping your own groceries separate?" },
                new Question() { Text = "How important is eating with your housemates?" },

                //Animals
                new Question() { Text = "Do you like animal companions?" },
                new Question() { Text = "How much do you mind caring for the housemate's animal companions, if they are absent?" },

                //Friends
                new Question() { Text = "How much do you mind friends coming over?" },
                new Question() { Text = "Do you mind friends or significant others staying overnight?" },
                new Question() { Text = "How much does hanging out with your housemates matter?" },

                //Smoking
                new Question() { Text = "Do you mind others smoking in the house?" },
                new Question() { Text = "Do you mind others smoking weed in the house?" }
            };

                var questions1 = test1.Questions.ToList();
                var questions2 = test2.Questions.ToList();
                int count = questions1.Count;

                for (int i = 0; i < count; i++)
                {
                    int n = rnd.Next(0, 2);
                    if (n == 2) questions1[i].Answer = "Yes";
                    else if (n == 1) questions1[i].Answer = "Maybe";
                    if (n == 0) questions1[i].Answer = "No";
                }

                for (int i = 0; i < count; i++)
                {
                    int n = rnd.Next(0, 2);
                    if (n == 2) questions2[i].Answer = "Yes";
                    else if (n == 1) questions2[i].Answer = "Maybe";
                    if (n == 0) questions2[i].Answer = "No";
                }


                Comparison comp = new Comparison();
                var outcome = comp.CalculateMatchPercentage(test1, test2);
                if (outcome >= 90) Over90.Add(outcome);
                if (outcome < 90&&outcome>=80) Over80.Add(outcome);
                if (outcome < 80 && outcome >= 70) Over70.Add(outcome);
                if (outcome < 70 && outcome >= 60) Over60.Add(outcome);
                if (outcome < 60 && outcome >= 50) Over50.Add(outcome);
                
                a--;
            }
        }
    }
}
