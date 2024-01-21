using System.ComponentModel.DataAnnotations;

namespace FinalExamApp.ViewModels.Account
{
    public class LoginVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailOrUsername { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
