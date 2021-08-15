using System.ComponentModel.DataAnnotations;
using YNHM.Database.Models.Base;

namespace YNHM.Database.Models
{
    public class Person : BaseModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        public int Age { get; set; }

        [Display(Name = "Photograph URL")]
        public string PhotoUrl { get; set; }

        [Display(Name = "Match Percentage")]
        public int MatchPercent { get; set; }

        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        public string Email { get; set; }

        [Display(Name = "Facebook Profile")]
        public string Facebook { get; set; }

        public string Description { get; set; }
    }
}
