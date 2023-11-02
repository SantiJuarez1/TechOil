using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TechOil.Models
{
    public class Work
    {
        [Key]
        public int IdTrabajo { get; set; }
        public string Fecha { get; set; }
        public int IdProyecto { get; set; }
        public int IdServicio { get; set; }
        public int CantHoras { get; set; }
        public decimal ValorHora { get; set; }
        public decimal Costo { get; set; }

    }

}
