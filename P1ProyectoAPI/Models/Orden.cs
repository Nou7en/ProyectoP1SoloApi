using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P1ProyectoAPI.Models
{
    public class Orden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idOrden { get; set; }
        public int idMesa { get; set; }
        public bool estado { get; set; }
    }
}
