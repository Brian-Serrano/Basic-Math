using System.ComponentModel.DataAnnotations;

namespace Advance_Web_Programming_Project.Models.Others
{
    public class RegisterUser
    {
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Username should have valid range.")]
        [Required(ErrorMessage = "Username should not be empty.")]
        public string Username { get; set; }
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [StringLength(40, MinimumLength = 10, ErrorMessage = "Email should have valid range.")]
        [Required(ErrorMessage = "Email should not be empty.")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password should have valid range.")]
        [Required(ErrorMessage = "Password should not be empty.")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password should be same.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}