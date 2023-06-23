using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class TelefoneViewModel
    {
        public int Id { get; set; }
        public int ContatoId { get; set; }

        [Required(ErrorMessage = "O telefone deve ser preenchido.")]
        [MinLength(9, ErrorMessage = "O telefone deve ter no mínimo 9 caracteres.")]
        [MaxLength(100, ErrorMessage = "O telefone deve ter no máximo 100 caracteres.")]
        [DisplayName("Telefone")]
        public string Numero { get; set; }
    }
}