namespace WebColumnas.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Tipo { get; set; }
        public required string Registro { get; set; }

        public List<PrincipiosActivos> PrincipiosActivos { get; set; } = [];
        public List<ProductosPrincipios> ProductosPrincipios { get; } = [];
        public ICollection<Lote> Lotes { get; } = new List<Lote>();

    }

    

}
