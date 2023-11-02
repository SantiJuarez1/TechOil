using System.Web;
using System.ComponentModel.DataAnnotations;


namespace TechOil.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public decimal valorHora { get; set; }
    }
   
}
