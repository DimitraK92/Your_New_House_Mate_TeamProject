using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YNHM.Entities.Models
{
    public class Roomie
    {
        public int Id { get; set; }

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

        //REQUIREMENTS
        public bool IsSmoking { get; set; }
        public bool IsVegan { get; set; }
        public bool IsNoisy { get; set; }
        public bool LikesCleaning { get; set; }
        public bool IsCatPerson { get; set; }

        public Roomie()
        {
            IsMatched = false;
            HasHouse = false;
        }


        //Navigation properties
        public int? HouseId { get; set; }
        public virtual House House { get; set; }


    }
}
