namespace WebColumnas.Models
{
    public class FaseMovil
    {
        public int FaseMovilID { get; set; }
        public required string Nombre { get; set; }
        public List<Columna>? Columnas{ get; set; }
    }
}
