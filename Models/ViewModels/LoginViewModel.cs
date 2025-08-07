using System.ComponentModel.DataAnnotations;
namespace DotNet_mvcBlog.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-mail required...")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password required...")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        // Hata almamak için bunu ekleyelim
        public bool RememberMe { get; set; } = false;
    }
}