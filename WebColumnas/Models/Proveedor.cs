namespace WebColumnas.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public ICollection<Marca> Marcas { get; } = new List<Marca>();
    }
}
