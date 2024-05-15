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

        [Display(Name = "Data de Contratação")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DtContratacao { get; set; }

    }
}
