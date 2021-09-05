using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YNHM.WebApp.Models
{
    public class CreateRoomieVM
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int Age { get; set; }

        [DisplayName("Photo")]
        public string PhotoUrl { get; set; }

        //CONTACT DETAILS
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        public string Email { get; set; }

        [Display(Name = "Facebook Profile")]
        public string Facebook { get; set; }

        public bool IsMatched { get; set; }
        public bool HasHouse { get; set; }
    }
}