namespace WebColumnas.Models
{
    public class Analisis
    {
        public int Id { get; set; }
        public decimal Ph { get; set; }
        public decimal Presion { get; set; }
        public TimeOnly TiempoCorrida { get; set; }
        public decimal Flujo { get; set; }
        public decimal Temperatura { get; set; }
        public decimal PresionIni { get; set; }
        public decimal PresionFin { get; set; }
        public string? Comentario { get; set; }
        public List<PrincipiosActivos>? PrincipiosActivos { get; set; }
        public string LoteId { get; set; }
        public Lote Lote { get; set; }
        public String ColumnaId { get; set; }
        public Columna? Columnas { get; set; }
    }
}
