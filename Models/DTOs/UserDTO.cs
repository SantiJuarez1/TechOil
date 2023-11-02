using System.ComponentModel.DataAnnotations;

namespace TechOil.Models.DTOs
{
    public class UserDTO
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public int Categoria { get; set; }
    }
}
