using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTeDev.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        [Display(Name = "Nome Funcionário")]
        public string? NomeFunc { get; set; }

        [Display(Name = "Nível de Acesso")]
        public int NivelAcesso { get; set; }

        [Display(Name = "Departamento")]
        public string? DeptoFunc { get; set; }

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
        public DateTime? DtContratacao { get; set; }

    }
}
