using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTeDev.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }

        [Display(Name = "Nome Departamento")]
        public string? NomeDepto { get; set; }

        [Display(Name = "Código WBS")]
        public string? CodigoAtividade { get; set; }


    }
}
