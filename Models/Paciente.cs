using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; }
    }
}
