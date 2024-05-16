using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTeDev.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }

        [Display(Name = "Nome do Departamento")]
        [Required]
        public string? DepartamentoNome { get; set; }
    }
}
