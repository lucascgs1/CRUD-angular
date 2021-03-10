using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRUD.Model
{
    public class Cliente
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [Display(Name = "Nome Fantasia", Prompt = "Digite o {0}")]
        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Display(Name = "E-mail", Prompt = "Digite o {0}")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [EmailAddress]
        [Display(Name = "E-mail", Prompt = "Digite o {0}")]
        public string Email { get; set; }
        
        
        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [Phone]
        [Display(Name = "Telefone", Prompt = "Digite o {0}")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é Obrigatório")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data", Prompt = "Digite o {0}")]
        public DateTime DataCadastro { get; set; }
    }
}
