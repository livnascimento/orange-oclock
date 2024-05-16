using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTeDev.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }

        [Display(Name = "Nome do Departamento")]
        public string? DepartamentoNome { get; set; }




    }
}
