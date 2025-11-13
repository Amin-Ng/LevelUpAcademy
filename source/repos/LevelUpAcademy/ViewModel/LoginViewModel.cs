using System.ComponentModel.DataAnnotations;

namespace LevelUpAcademy.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name ="Ricorda Password")]
        public bool RememberMe { get; set; }
    }
}
