using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTeDev.Models
{
    public class Wbs
    {
        public int WbsId { get; set; }

        [Display(Name = "WBS código")]
        public string? WbsCodigo { get; set; }

        [Display(Name = "WBS Tipo")]
        public string? WbsTipo { get; set; }

        [Display(Name = "WBS Descrição")]
        public string? WbsDescricao { get; set; }

        

    }
}
