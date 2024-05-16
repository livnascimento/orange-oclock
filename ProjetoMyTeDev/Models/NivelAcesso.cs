using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTeDev.Models
{
    public class NivelAcesso
    {
        public int NivelAcessoId { get; set; }


        [Display(Name = "Nível de Acesso")]
        public string? NivelAcessoNome { get; set; }
    }
}
