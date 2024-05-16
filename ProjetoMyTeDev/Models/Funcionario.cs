using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTeDev.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        [Display(Name = "Nome Funcionário")]
        public string? FuncionarioNome { get; set; }

        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }

        [Display(Name = "Nível de Acesso")]
        public int NivelAcessoId { get; set; }

        [Display(Name = "Data de Contratação")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataContratacao { get; set; }

        public string? Localidade { get; set; }

        public Cargo Cargo { get; set; }
        public int CargoId { get; set; }
        

    }
}
