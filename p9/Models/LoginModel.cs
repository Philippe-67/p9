using System.ComponentModel.DataAnnotations;

namespace p9.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Veuillez saisir votre adresse e-mail.")]
        [EmailAddress(ErrorMessage = "Veuillez saisir une adresse e-mail valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Veuillez saisir votre mot de passe.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool ShowInvalidCredentialsMessage { get; set; }
    }
}
