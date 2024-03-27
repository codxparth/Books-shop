using System.ComponentModel.DataAnnotations;

namespace Book.Models
{
    public class LRmodel
    {

        [Key]
        public int UserID { get; set; }

        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password length must be at least {2} characters", MinimumLength = 6)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
