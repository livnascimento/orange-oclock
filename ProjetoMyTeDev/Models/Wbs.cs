using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ProjetoMyTeDev.Models
{
    public class Wbs
    {
        public int WbsId { get; set; }

        [Required]
        [Display(Name = "Código WBS")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Máximo de 10, mínimo de 4 caracteres")]
        public string? WbsCodigo { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public string? WbsTipo { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string? WbsDescricao { get; set; }

        

    }
}
