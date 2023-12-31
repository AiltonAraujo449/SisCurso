using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ContatoViewModel
    {
        public List<TelefoneViewModel> LstTelefoneViewModel { get; } = new List<TelefoneViewModel>();
        public int Id { get; set; }

        [Required(ErrorMessage = "O 'Nome' deve ser preenchido!")]
        [MinLength(3, ErrorMessage = "O Nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O 'Sobrenome' deve ser preenchido!")]
        [MinLength(3, ErrorMessage = "O Sobrenome deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O Sobrenome deve ter no máximo 100 caracteres.")]
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O 'Email' deve ser preenchido!")]
        [MinLength(10, ErrorMessage = "O Email deve ter no mínimo 10 caracteres.")]
        [MaxLength(100, ErrorMessage = "O Email deve ter no máximo 100 caracteres.")]
        [DisplayName("Email")]
        public string Email { get; set; }
    }
}