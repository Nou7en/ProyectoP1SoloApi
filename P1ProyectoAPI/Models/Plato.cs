using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P1ProyectoAPI.Models
{
    public class Plato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPlato { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
    }
}
