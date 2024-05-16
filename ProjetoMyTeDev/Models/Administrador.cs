using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTeDev.Models
{
    public class Administrador
    {
        public int AdministradorId { get; set; }

        [Display(Name = "Nome Administrador")]
        public string? NomeAdmin { get; set; }

        [Display(Name = "Nível de Acesso")]
        public int NivelAcessoId { get; set; }



    }
}
