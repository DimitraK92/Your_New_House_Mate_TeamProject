using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YNHM.Database.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int Age { get; set; }

        [Display(Name = "Match Percentage")]
        public int? MatchPercent { get; set; }

        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        public string Email { get; set; }

        [Display(Name = "Facebook Profile")]
        public string Facebook { get; set; }

        public string Description { get; set; }

        [DisplayName("Photo")]
        public string PhotoUrl { get; set; }
        public virtual ICollection<House> OwnsHouses { get; set; }

        /// <summary>
        /// Used when the Description property of a Person object is too long.
        /// </summary>
        /// <returns>The first maxSize characters of the Description property, or less, if they are less than maxSize.</returns>
        public string TrimDescription(int maxSize)
        {
            if (Description == "" || Description.Length <= maxSize)
            {
                return Description;
            }
            return Description.Substring(0, maxSize);
        }

    }
}
