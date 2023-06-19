using System.ComponentModel.DataAnnotations;

namespace Advance_Web_Programming_Project.Models.Others
{
    public class LoginUser
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username should not be empty.")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password should not be empty.")]
        public string Password { get; set; }
    }
}