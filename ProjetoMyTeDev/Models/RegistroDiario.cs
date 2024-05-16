namespace ProjetoMyTeDev.Models
{
    public class RegistroDiario
    {
        public int RegistroDiarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
        public Wbs Wbs { get; set; }
        public int WbsId {  get; set; }
        public DateTime Data {  get; set; }
        public int Horas {  get; set; }
    }
}
