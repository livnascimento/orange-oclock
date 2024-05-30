using ProjetoMyTeDev.Areas.Identity.Data;

namespace ProjetoMyTeDev.Models
{
    public class RegistroDiario
    {
        public int RegistroDiarioId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public string? ApplicationUserId { get; set; }
        public Wbs? Wbs { get; set; }
        public int WbsId {  get; set; }
        public DateOnly Data {  get; set; }
        public int Horas {  get; set; }
    }
}
