using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebColumnas.Models
{
    public class Lote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Numero de Lote")]
        public string? LoteID { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaEmision { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaVcto { get; set; }
        public int TamanoObjetivo { get; set; }

        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
    }
}
