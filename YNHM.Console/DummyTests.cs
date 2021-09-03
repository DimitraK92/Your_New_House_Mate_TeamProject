//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using YNHM.Entities.TestResources;

//namespace YNHM.Console
//{
//    public class DummyTests
//    {
//        public static QuestionSet HouseMateMatching = new QuestionSet()
//        {
//            Name = "Housemate matching",
//            Questions = new List<Question>()
//                {
//                    //Housework
//                    new Question() { QuestionId = 1, Text = "How much does cleanliness matter in general?" },
//                    new Question() { QuestionId = 2, Text = "How much are you bothered by a sink full with plates?" },
//                    new Question() { QuestionId = 3, Text = "Do you mind the house being dusty?" },
//                    new Question() { QuestionId = 4, Text = "Is cleaning the toilet every day important to you?" },
                    
//                    //Noise
//                    new Question() { QuestionId = 5, Text = "How much does noise matter in general?" },
//                    new Question() { QuestionId = 6, Text = "Do you listen to music loud?" },
//                    new Question() { QuestionId = 7, Text = "How much do you value quiet in the house" },
//                    new Question() { QuestionId = 8, Text = "How bothered will you be with playing musical instruments?" },

//                    //Food
//                    new Question() { QuestionId = 9, Text = "Is a vegan or vegetarian diet important to you?" },
//                    new Question() { QuestionId = 10, Text = "Do you cook every day?" },
//                    new Question() { QuestionId = 11, Text = "How important is keeping your own groceries separate?" },
//                    new Question() { QuestionId = 12, Text = "How important is eating with your housemates?" },

//                    //Animals
//                    new Question() { QuestionId = 13, Text = "Do you like animal companions?" },
//                    new Question() { QuestionId = 14, Text = "How much do you mind caring for the housemate's animal companions, if they are absent?" },

//                    //Friends
//                    new Question() { QuestionId = 15, Text = "How much do you mind friends coming over?" },
//                    new Question() { QuestionId = 16, Text = "Do you mind friends or significant others staying overnight?" },
//                    new Question() { QuestionId = 17, Text = "How much does hanging out with your housemates matter?" },

//                    //Smoking
//                    new Question() { QuestionId = 18, Text = "Do you mind others smoking in the house?" },
//                    new Question() { QuestionId = 19, Text = "Do you mind others smoking weed in the house?" }
//                }
//        };

//        public List<List<Answer>> AnswersList = new List<List<Answer>>() 
//        {
//            new List<Answer>()
//                {
//                     new Answer(HouseMateMatching.Questions[0])
//                     {
//                        MyAnswer = AnswerType.NotSoMuch,
//                        Importance = AnswerType.VeryMuch,
//                        PreferedAnswer = AnswerType.NotSoMuch,
//                        AcceptedAnswers = new List<AnswerType>{AnswerType.Indifferrent,AnswerType.NotSoMuch,AnswerType.Somewhat},
//                        Significance = Importance.VeryImportant
//                     },
//                     new Answer(HouseMateMatching.Questions[1])
//                     {
//                        MyAnswer = AnswerType.Somewhat,
//                        Importance = AnswerType.Indifferrent,
//                        PreferedAnswer = AnswerType.Somewhat,
//                        AcceptedAnswers = new List<AnswerType>{AnswerType.NotAtAll,AnswerType.NotSoMuch,AnswerType.Indifferrent},
//                        Significance = Importance.Indifferent
//                     },
//                     new Answer(HouseMateMatching.Questions[2])
//                     {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Importance = AnswerType.VeryMuch,
//                        PreferedAnswer = AnswerType.VeryMuch,
//                        AcceptedAnswers = new List<AnswerType>{AnswerType.Somewhat,AnswerType.VeryMuch},
//                        Significance = Importance.VeryImportant
//                     },
//                },
//            new List<Answer>()
//            {
//                 new Answer(HouseMateMatching.Questions[0])
//                 {
//                    MyAnswer = AnswerType.Somewhat,
//                    Importance = AnswerType.Somewhat,
//                    PreferedAnswer = AnswerType.Somewhat,
//                    AcceptedAnswers = new List<AnswerType>{AnswerType.Indifferrent,AnswerType.Somewhat},
//                    Significance = Importance.SomewhatImportant
//                 },
//                 new Answer(HouseMateMatching.Questions[1])
//                 {
//                    MyAnswer = AnswerType.NotAtAll,
//                    Importance = AnswerType.Indifferrent,
//                    PreferedAnswer = AnswerType.NotAtAll,
//                    AcceptedAnswers = new List<AnswerType>{},
//                    Significance = Importance.Indifferent
//                 },
//                 new Answer(HouseMateMatching.Questions[2])
//                 {
//                    MyAnswer = AnswerType.VeryMuch,
//                    Importance = AnswerType.VeryMuch,
//                    PreferedAnswer = AnswerType.VeryMuch,
//                    AcceptedAnswers = new List<AnswerType>{AnswerType.VeryMuch,AnswerType.Somewhat},
//                    Significance = Importance.VeryImportant
//                 },
//            },
//            new List<Answer>()
//            {
//                 new Answer(HouseMateMatching.Questions[0])
//                 {
//                    MyAnswer = AnswerType.Somewhat,
//                    Importance = AnswerType.NotSoMuch,
//                    PreferedAnswer = AnswerType.Somewhat,
//                    AcceptedAnswers = new List<AnswerType>{AnswerType.Indifferrent,AnswerType.NotSoMuch,AnswerType.Somewhat},
//                    Significance = Importance.SomewhatUnimportant
//                 },
//                 new Answer(HouseMateMatching.Questions[1])
//                 {
//                    MyAnswer = AnswerType.NotAtAll,
//                    Importance = AnswerType.NotSoMuch,
//                    PreferedAnswer = AnswerType.NotSoMuch,
//                    AcceptedAnswers = new List<AnswerType>{AnswerType.Indifferrent,AnswerType.NotSoMuch,AnswerType.NotAtAll},
//                    Significance = Importance.SomewhatUnimportant
//                 },
//                 new Answer(HouseMateMatching.Questions[2])
//                 {
//                    MyAnswer = AnswerType.VeryMuch,
//                    Importance = AnswerType.Somewhat,
//                    PreferedAnswer = AnswerType.Indifferrent,
//                        AcceptedAnswers = new List<AnswerType>{AnswerType.Indifferrent,AnswerType.Somewhat},
//                        Significance = Importance.SomewhatImportant
//                 },
//            },
//            new List<Answer>()
//            {
//                 new Answer(HouseMateMatching.Questions[0])
//                 {
//                    MyAnswer = AnswerType.Somewhat,
//                    Importance = AnswerType.Somewhat,
//                    PreferedAnswer = AnswerType.NotAtAll,
//                    AcceptedAnswers = new List<AnswerType>{AnswerType.Somewhat},
//                    Significance = Importance.SomewhatImportant
//                 },
//                 new Answer(HouseMateMatching.Questions[1])
//                 {
//                    MyAnswer = AnswerType.VeryMuch,
//                    Importance = AnswerType.Indifferrent,
//                    PreferedAnswer = AnswerType.Somewhat,
//                    AcceptedAnswers = new List<AnswerType>{AnswerType.Somewhat,AnswerType.VeryMuch},
//                    Significance = Importance.Indifferent
//                 },
//                 new Answer(HouseMateMatching.Questions[2])
//                 {
//                    MyAnswer = AnswerType.NotAtAll,
//                    Importance = AnswerType.NotSoMuch,
//                    PreferedAnswer = AnswerType.Indifferrent,
//                    AcceptedAnswers = new List<AnswerType>{AnswerType.Indifferrent,AnswerType.NotSoMuch,AnswerType.Somewhat},
//                    Significance = Importance.SomewhatUnimportant
//                 },
//            },
//            new List<Answer>()
//            {
//                 new Answer(HouseMateMatching.Questions[0])
//                 {
//                    MyAnswer = AnswerType.VeryMuch,
//                    Importance = AnswerType.VeryMuch,
//                    PreferedAnswer = AnswerType.Somewhat,
//                    AcceptedAnswers = new List<AnswerType>{AnswerType.VeryMuch},
//                    Significance = Importance.VeryImportant
//                 },
//                 new Answer(HouseMateMatching.Questions[1])
//                 {
//                    MyAnswer = AnswerType.NotAtAll,
//                    Importance = AnswerType.VeryMuch,
//                    PreferedAnswer = AnswerType.Somewhat,
//                    AcceptedAnswers = new List<AnswerType>{AnswerType.Indifferrent,AnswerType.NotSoMuch,AnswerType.Somewhat},
//                    Significance = Importance.VeryImportant
//                 },
//                 new Answer(HouseMateMatching.Questions[2])
//                 {
//                    MyAnswer = AnswerType.NotAtAll,
//                    Importance = AnswerType.VeryMuch,
//                    PreferedAnswer = AnswerType.Somewhat,
//                    AcceptedAnswers = new List<AnswerType>{AnswerType.Somewhat,AnswerType.VeryMuch},
//                    Significance = Importance.VeryImportant
//                 },
//            },
//            new List<Answer>()
//            {
//                 new Answer(HouseMateMatching.Questions[0])
//                 {
//                    MyAnswer = AnswerType.Somewhat,
//                    Importance = AnswerType.Somewhat,
//                    PreferedAnswer = AnswerType.Somewhat,
//                    AcceptedAnswers = new List<AnswerType>{AnswerType.Somewhat},
//                    Significance = Importance.SomewhatImportant
//                 },
//                 new Answer(HouseMateMatching.Questions[1])
//                 {
//                    MyAnswer = AnswerType.VeryMuch,
//                    Importance = AnswerType.NotAtAll,
//                    PreferedAnswer = AnswerType.NotSoMuch,
//                    AcceptedAnswers = new List<AnswerType>{AnswerType.Indifferrent,AnswerType.NotSoMuch},
//                    Significance = Importance.TotallyUnimportant
//                 },
//                 new Answer(HouseMateMatching.Questions[2])
//                 {
//                    MyAnswer = AnswerType.VeryMuch,
//                    Importance = AnswerType.VeryMuch,
//                    PreferedAnswer = AnswerType.VeryMuch,
//                    AcceptedAnswers = new List<AnswerType>{AnswerType.VeryMuch,AnswerType.Somewhat},
//                    Significance = Importance.VeryImportant
//                 },
//            },
//            new List<Answer>()
//            {
//                 new Answer(HouseMateMatching.Questions[0])
//                 {
//                    MyAnswer = AnswerType.Somewhat,
//                    Importance = AnswerType.Somewhat,
//                    PreferedAnswer = AnswerType.Somewhat,
//                    AcceptedAnswers = new List<AnswerType>{AnswerType.Indifferrent,AnswerType.NotSoMuch,AnswerType.Somewhat},
//                    Significance = Importance.TotallyUnimportant
//                 },
//                new Answer(HouseMateMatching.Questions[1])
//                 {
//                    MyAnswer = AnswerType.VeryMuch,
//                    Importance = AnswerType.Indifferrent,
//                    PreferedAnswer = AnswerType.NotAtAll,
//                    AcceptedAnswers = new List<AnswerType>{AnswerType.NotAtAll},
//                    Significance = Importance.Indifferent
//                 },
//                 new Answer(HouseMateMatching.Questions[2])
//                 {
//                    MyAnswer = AnswerType.Somewhat,
//                    Importance = AnswerType.Somewhat,
//                    PreferedAnswer = AnswerType.Somewhat,
//                    AcceptedAnswers = new List<AnswerType>{AnswerType.Indifferrent,AnswerType.Somewhat},
//                    Significance = Importance.SomewhatImportant
//                 },
//            }
//        };

//        public List<Test> CreateTests()
//        {
//            List<Test> tests = new List<Test>() { };
//            for (int i = 0; i < AnswersList.Count; i++)
//            {
//                for (int j = 0; j < AnswersList[j].Count; j++)
//                {
//                    Test myTest = new Test()
//                    {
//                        Answers = AnswersList[j],
//                        Questions = HouseMateMatching.Questions
//                    };
//                    tests.Add(myTest);
//                }
//            }

//            return tests;
//        }


//        public List<List<Answer>> BigTestAnswers = new List<List<Answer>>()
//        {
//                new List<Answer>()
//                {

//                    #region One
//                    new Answer(HouseMateMatching.Questions[0])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[1])
//                    {
//                        MyAnswer = AnswerType.Somewhat,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.Indifferrent,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[2])
//                    {
//                        MyAnswer = AnswerType.Indifferrent,
//                        Significance = Importance.Indifferent,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {

//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[3])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatUnimportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    }
//                    #endregion
//                    #region two
//                    ,
//                    new Answer(HouseMateMatching.Questions[4])
//                    {
//                        MyAnswer = AnswerType.NotAtAll,
//                        Significance = Importance.SomewhatUnimportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.NotAtAll,
//                            AnswerType.NotSoMuch,
//                            AnswerType.Indifferrent
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[5])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[6])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatUnimportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[7])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    }
//                    #endregion
//                    #region three
//                    ,
//                    new Answer(HouseMateMatching.Questions[8])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[9])
//                    {
//                        MyAnswer = AnswerType.Indifferrent,
//                        Significance = Importance.Indifferent,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {

//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[10])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[11])
//                    {
//                        MyAnswer = AnswerType.NotAtAll,
//                        Significance = Importance.SomewhatUnimportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.NotAtAll,
//                            AnswerType.NotSoMuch,
//                            AnswerType.Indifferrent
//                        }
//                    }
//                    #endregion
//                    #region four
//                    ,
//                    new Answer(HouseMateMatching.Questions[12])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatUnimportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[13])
//                    {
//                        MyAnswer = AnswerType.Indifferrent,
//                        Significance = Importance.Indifferent,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {

//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[14])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[15])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatUnimportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },

//                    new Answer(HouseMateMatching.Questions[16])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[17])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[18])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    }
//                    #endregion

//                    //,
//                    //new Answer(HouseMateMatching.Questions[19])
//                    //{
//                    //    MyAnswer = AnswerType.Indifferrent,
//                    //    Significance = Importance.Indifferent,
//                    //    AcceptedAnswers = new List<AnswerType>()
//                    //    {

//                    //    }
//                    //}
//                },
//                                new List<Answer>()
//                {
//                #region one
//                    new Answer(HouseMateMatching.Questions[0])
//                    {
//                        MyAnswer = AnswerType.Somewhat,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.Indifferrent,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[1])
//                    {
//                        MyAnswer = AnswerType.NotAtAll,
//                        Significance = Importance.SomewhatUnimportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.NotAtAll,
//                            AnswerType.NotSoMuch,
//                            AnswerType.Indifferrent
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[2])
//                    {
//                        MyAnswer = AnswerType.Indifferrent,
//                        Significance = Importance.Indifferent,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {

//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[3])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    }
//                #endregion
//                #region two
//                    ,
//                    new Answer(HouseMateMatching.Questions[4])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[5])
//                    {
//                        MyAnswer = AnswerType.Indifferrent,
//                        Significance = Importance.Indifferent,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {

//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[6])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatUnimportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[7])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[8])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatUnimportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    }
//                #endregion
//                #region three
//                    ,
//                    new Answer(HouseMateMatching.Questions[9])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatUnimportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[10])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[11])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[12])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatUnimportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    }
//                #endregion
//                #region four
//                    ,
//                    new Answer(HouseMateMatching.Questions[13])
//                    {
//                        MyAnswer = AnswerType.Indifferrent,
//                        Significance = Importance.Indifferent,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {

//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[14])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[15])
//                    {
//                        MyAnswer = AnswerType.Indifferrent,
//                        Significance = Importance.Indifferent,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {

//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[16])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[17])
//                    {
//                        MyAnswer = AnswerType.VeryMuch,
//                        Significance = Importance.SomewhatImportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.VeryMuch,
//                            AnswerType.Somewhat
//                        }
//                    },
//                    new Answer(HouseMateMatching.Questions[18])
//                    {
//                        MyAnswer = AnswerType.NotAtAll,
//                        Significance = Importance.SomewhatUnimportant,
//                        AcceptedAnswers = new List<AnswerType>()
//                        {
//                            AnswerType.NotAtAll,
//                            AnswerType.NotSoMuch,
//                            AnswerType.Indifferrent
//                        }
//                    }
//                #endregion
                    
                    
                    
//                    //,
//                    //new Answer(HouseMateMatching.Questions[19])
//                    //{
//                    //    MyAnswer = AnswerType.VeryMuch,
//                    //    Significance = Importance.SomewhatImportant,
//                    //    AcceptedAnswers = new List<AnswerType>()
//                    //    {
//                    //        AnswerType.VeryMuch,
//                    //        AnswerType.Somewhat
//                    //    }
//                    //},
//                },
//            };



//    }
//}
