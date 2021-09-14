using System.ComponentModel.DataAnnotations;

namespace YNHM.WebApp.Areas.Administration.ViewModels
{
    public class AdminLoginVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}