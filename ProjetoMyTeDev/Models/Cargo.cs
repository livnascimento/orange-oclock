using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTeDev.Models
{
    public class Cargo
    {
        public int CargoId { get; set; }

        [Required]
        [Display(Name = "Nome do Cargo")]
        public string CargoNome { get; set; }

        [Required]
        [Display(Name = "Carga Horária")]
        public int CargaHoraria { get; set; }
    }
}
