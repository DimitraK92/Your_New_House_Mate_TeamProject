using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YNHM.Entities.TestResources;

namespace YNHM.WebApp.Models
{
    public class AnswerQuestionsVM
    {
        public List<Question> Questions = new List<Question>()
        {
            //Housework
            new Question() { Text = "Does cleanliness matter in general?" },
            new Question() { Text = "Are you bothered by a sink full with plates?" },
            new Question() { Text = "Do you mind the house being dusty?" },
            new Question() { Text = "Is cleaning the toilet every day important to you?" },

            //Noise
            new Question() { Text = "Does noise matter in general?" },
            new Question() { Text = "Do you listen to music loud?" },
            new Question() { Text = "Do you value quiet in the house" },
            new Question() { Text = "Will you be with playing musical instruments?" },

            //Food
            new Question() { Text = "Is a vegan or vegetarian diet important to you?" },
            new Question() { Text = "Do you cook every day?" },
            new Question() { Text = "Is keeping your own groceries separate important?" },
            new Question() { Text = "Is eating with your housemates important?" },

            //Animals
            new Question() { Text = "Do you like animal companions?" },
            new Question() { Text = "Will you mind caring for the housemate's animal companions, if they are absent?" },

            //Friends
            new Question() { Text = "Doo you mind friends coming over?" },
            new Question() { Text = "Do you mind friends or significant others staying overnight?" },
            new Question() { Text = "Does hanging out with your housemates matter?" },

            //Smoking
            new Question() { Text = "Do you mind others smoking in the house?" },
            new Question() { Text = "Do you mind others smoking weed in the house?" }
        };

        [Required]
        public string Answer { get; set; }


    }
}