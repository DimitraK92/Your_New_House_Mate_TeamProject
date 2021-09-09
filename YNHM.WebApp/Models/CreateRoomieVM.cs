using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YNHM.WebApp.Models
{
    public class CreateRoomieVM
    {
        [Display(Name = "First Name")]
        [Required]
        [MinLength(2,ErrorMessage = "First name should be 2 or more characters.")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [MinLength(2, ErrorMessage = "Last name should be 2 or more characters.")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }

        [DisplayName("Photo")]
        public string PhotoUrl { get; set; }

        //CONTACT DETAILS
        [Display(Name = "Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        //[Phone(ErrorMessage = "Must be a valid 10 digit phone number.")]
        [StringLength(10, ErrorMessage = "Please enter a 10 digit phone number.", ErrorMessageResourceName = null, ErrorMessageResourceType = null, MinimumLength = 10)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Must be a valid e-mail address.")]
        public string Email { get; set; }

        [Display(Name = "Facebook Profile")]
        [DataType(DataType.Url)]
        public string Facebook { get; set; }

        public bool IsMatched { get; set; }
        public bool HasHouse { get; set; }
    }
}