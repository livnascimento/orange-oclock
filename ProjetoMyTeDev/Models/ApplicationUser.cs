using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTeDev.Models
{
    public class ApplicationUser : IdentityUser
    { 
        [Display(Name = "Nome do Funcionário")]
        [Required]
        public string? Nome { get; set; }
        [Display(Name = "Departamento")]
        [Required]
        public int DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }

        [Display(Name = "Data de Contratação")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateOnly? DataContratacao { get; set; }

        public string? Localidade { get; set; }

        public Cargo? Cargo { get; set; }

        [Display(Name = "Cargo")]
        [Required]
        public int CargoId { get; set; }
    }
}
