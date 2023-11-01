using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P1ProyectoAPI.Models
{
    public class PlatoOrden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPlatoOrden { get; set; }
        public int idOrden { get; set; }
        public int idPlato { get; set; }
        public int cantidad { get; set; }
    }
}
