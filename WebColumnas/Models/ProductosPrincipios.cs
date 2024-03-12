using Microsoft.EntityFrameworkCore;

namespace WebColumnas.Models
{
    [PrimaryKey(nameof(ProductoId), nameof(PrincipiosActivosId))]
    public class ProductosPrincipios
    {        
        public int ProductoId { get; set; }        
        public int PrincipiosActivosId { get; set; }
        public decimal Concentracion { get; set; }    
        public PrincipiosActivos PrincipiosActivos { get; set; }
        //public ICollection<Analisis> Analisis { get; } = new List<Analisis>();
    }
}
