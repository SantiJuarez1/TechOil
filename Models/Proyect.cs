using System.Web;
using System.ComponentModel.DataAnnotations;


namespace TechOil.Models
{
    public class Proyect
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Estado { get; set; }

    }
    
}
