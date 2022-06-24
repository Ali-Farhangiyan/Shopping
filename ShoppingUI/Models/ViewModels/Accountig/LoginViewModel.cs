using System.ComponentModel.DataAnnotations;

namespace ShoppingUI.Models.ViewModels.Accountig
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public bool IsRememberMe { get; set; } = false;

        public string? ReturnUrl { get; set; }


    }
}
