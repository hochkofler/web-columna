﻿namespace WebColumnas.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }

        public required int ProveedorId { get; set; }
        public Proveedor? Proveedor { get; set; }
        public ICollection<Columna> Columnas { get; } = new List<Columna>();
    }
}
