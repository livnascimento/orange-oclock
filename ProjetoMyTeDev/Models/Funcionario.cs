using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMyTeDev.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        [Display(Name = "Nome Funcionário")]
        [Required]
        public string? FuncionarioNome { get; set; }
        [EmailAddress(ErrorMessage = "O campo E-mail não é um endereço válido.")]
        [Display(Name = "E-mail")]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }

        [Display(Name = "Departamento")]
        [Required]
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        [Display(Name = "Nível de Acesso")]
        [Required]
        public int NivelAcessoId { get; set; }
        public NivelAcesso NivelAcesso { get; set; }

        [Required]
        public string? FuncionarioNome { get; set; }

        [EmailAddress(ErrorMessage = "O campo E-mail não é um endereço válido.")]
        [Display(Name = "E-mail")]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Display(Name = "Departamento")]
        [Required]
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

        [Display(Name = "Nível de Acesso")]
        [Required]
        public int NivelAcessoId { get; set; }

        [Display(Name = "Data de Contratação")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataContratacao { get; set; }

        public string? Localidade { get; set; }

        public Cargo Cargo { get; set; }

        [Display(Name = "Cargo")]
        public int CargoId { get; set; }
        

    }
}
