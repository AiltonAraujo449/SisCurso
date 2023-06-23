using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O Email deve ser preenchido.")]
        [MinLength(10, ErrorMessage = "O Email deve ter no minimo 10 caracteres.")]
        [MaxLength(100, ErrorMessage = "O Email deve ter no máximo 100 caracteres.")]
        [EmailAddress(ErrorMessage = "O Email deve ser válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha deve ser preenchida.")]
        [MinLength(6, ErrorMessage = "A Senha deve ter no minimo 6 caracteres.")]
        [MaxLength(20, ErrorMessage = "A Senha deve ter no máximo 20 caracteres.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "A Confirmação de senha deve ser preenchida.")]
        [MinLength(6, ErrorMessage = "A Confirmação de Senha deve ter no minimo 6 caracteres.")]
        [MaxLength(20, ErrorMessage = "A Confirmação de Senha deve ter no máximo 20 caracteres.")]
        [Compare("Password", ErrorMessage = "A Confirmação de senha deve ser igual a Senha.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmação de Senha")]
        public string ConfirmPassword { get; set; }
    }
}