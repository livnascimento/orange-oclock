using ProjetoMyTeDev.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTeDev.Models
{
    public class RegistroDiario
    {
        [Display(Name = "ID Registro")]
        public int RegistroDiarioId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public string? ApplicationUserId { get; set; }
        public Wbs? Wbs { get; set; }
        public int WbsId {  get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data {  get; set; }
        public int Horas {  get; set; }
    }
}
