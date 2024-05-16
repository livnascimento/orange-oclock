using System.ComponentModel.DataAnnotations;

namespace ProjetoMyTeDev.Models
{
    public class CargaHoraria
    {
        public int CargaHorariaId { get; set; }

        public int CargoId { get; set; }

        public int Horas { get; set; }

        

    }
}
