using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;

namespace CRUD.Model
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Display(Name = "Titulo", Prompt = "Digite o {0}")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Display(Name = "Logradouro", Prompt = "Digite o {0}")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Display(Name = "Numero", Prompt = "Digite o {0}")]
        public int Numero { get; set; }

        [Display(Name = "Complemento", Prompt = "Digite o {0}")]
        public string Complemento { get; set; }

        [Display(Name = "Bairro", Prompt = "Digite o {0}")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade", Prompt = "Digite o {0}")]
        public string Cidade { get; set; }

        [Display(Name = "Estado", Prompt = "Digite o {0}")]
        public string Estado { get; set; }

        [Display(Name = "Endereço principal", Prompt = "Digite o {0}")]
        public bool EnderecoPrincipal { get; set; }
    }
}
