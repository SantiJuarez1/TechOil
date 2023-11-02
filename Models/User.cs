using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TechOil.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public int Categoria { get; set; }
        private string Contraseña { get; set; }
    }
   
}
