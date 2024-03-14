namespace WebColumnas.Models
{
    public class PrincipiosActivos
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }

        public List<Producto> Productos { get; } = [];
        public List<ProductosPrincipios> ProductosPrincipios { get; } = [];
        public List<Analisis> Analisis { get; set; } = [];
    }
}
