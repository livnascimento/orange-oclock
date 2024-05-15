using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTeDev.Models
{
    public class CargaHoraria
    {
        public int CargaHorariaId { get; set; }

        [Required]
        [Display(Name = "Nível de Acesso")]
        public int NivelAcessoId { get; set; }

        [Required]
        public int Horas { get; set; }

    }
}
