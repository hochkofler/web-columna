namespace WebColumnas.Models.ViewModels
{
    public class AnalisisViewModel
    { 
        public decimal Ph { get; set; }
        public decimal Presion { get; set; }
        public TimeOnly TiempoCorrida { get; set; }
        public decimal Flujo { get; set; }
        public decimal Temperatura { get; set; }
        public decimal PresionIni { get; set; }
        public decimal PresionFin { get; set; }
        public string? Comentario { get; set; }
        public List<int> PrincipiosIds { get; set; } // Lista de IDs de principios activos seleccionados
        public string LoteId { get; set; }
        public string ColumnaId { get; set; }
    }
}
