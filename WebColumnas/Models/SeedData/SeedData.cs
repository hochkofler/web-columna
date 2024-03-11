using Microsoft.EntityFrameworkCore;
using WebColumnas.Data;
using WebColumnas.Models;

public static class SeedData
{
    public static List<Columna> GenerateColumnaSeedData(List<FaseMovil> fasesMovilesSeedData)
    {
        List<Columna> seedData = new List<Columna>();
        //fasesMovilesSeedData = GenerateFasesMovilesSeedData();

        // Ejemplos de fases estacionarias típicas de HPLC
        string[] fasesEstacionarias = { "C18", "C8", "C4", "Phenyl", "Cyano", "Amino", "Diol" };

        // Datos de ejemplo para inicializar las columnas
        string[] ids = { "1", "1A", "2", "2B", "3", "3A", "4", "4B", "5", "5A", "6", "6B", "7", "7A", "8" };
        string[] dimensiones = { "50x4.6x3.5", "100x4.6x3.5", "150x4.6x3.5", "250x4.6x3.5", "50x3.0x3.5", "100x3.0x3.5", "150x3.0x3.5", "250x3.0x3.5" };
        decimal[] phMin = { 2.5m, 2.8m, 3.0m, 3.2m, 3.5m, 3.7m, 4.0m, 4.2m, 4.5m, 4.8m, 5.0m, 5.2m, 5.5m, 5.7m, 6.0m };
        decimal[] phMax = { 6.0m, 6.2m, 6.5m, 6.7m, 7.0m, 7.2m, 7.5m, 7.7m, 8.0m, 8.2m, 8.5m, 8.7m, 9.0m, 9.2m, 9.5m };

        Random rnd = new Random();

        // Generar 15 columnas con datos aleatorios
        for (int i = 0; i < 15; i++)
        {
            DateTime fechaIngreso = DateTime.Now.AddDays(-rnd.Next(1, 365)); // Fecha aleatoria en el último año
            DateTime fechaEnMarcha = fechaIngreso.AddDays(rnd.Next(1, (DateTime.Now - fechaIngreso).Days)); // Fecha aleatoria entre FechaIngreso y hoy

            // Seleccionar una o más fases móviles aleatorias
            int numFasesMoviles = rnd.Next(1, 4); // Seleccionar entre 1 y 3 fases móviles
            List<FaseMovil> fasesMoviles = new List<FaseMovil>();
            for (int j = 0; j < numFasesMoviles; j++)
            {
                fasesMoviles.Add(fasesMovilesSeedData[rnd.Next(fasesMovilesSeedData.Count)]);
            }

            Columna columna = new Columna
            {
                ColumnaId = ids[i],
                FechaIngreso = fechaIngreso,
                FechaEnMarcha = fechaEnMarcha,
                Dimension = dimensiones[rnd.Next(dimensiones.Length)],
                FaseEstacionaria = fasesEstacionarias[rnd.Next(fasesEstacionarias.Length)],
                Clase = "Clase Ejemplo",
                PhMin = phMin[rnd.Next(phMin.Length)],
                PhMax = phMax[rnd.Next(phMax.Length)],
                PresionMax = rnd.Next(0, 2000),
                MarcaId = rnd.Next(1, 17), // Considerando que hay 17 marcas disponibles
                FasesMoviles = fasesMoviles
            };

            seedData.Add(columna);
        }

        return seedData;
    }
    public static List<FaseMovil> GenerateFasesMovilesSeedData()
    {
        List<FaseMovil> fasesMovilesSeedData = new List<FaseMovil>();

        // Ejemplos de fases móviles típicas de HPLC
        string[] fasesMovilesNombres = { "Acetonitrilo", "Metanol", "Agua", "Ácido Fosfórico", "Tetrahidrofurano" };

        // Generar datos para las fases móviles
        for (int i = 0; i < fasesMovilesNombres.Length; i++)
        {
            FaseMovil faseMovil = new FaseMovil
            {
                Nombre = fasesMovilesNombres[i],
            };

            fasesMovilesSeedData.Add(faseMovil);
        }

        return fasesMovilesSeedData;
    }

    public static void Initialize(IServiceProvider serviceProvider, Task<List<FaseMovil>> fasesMoviles1)
    {
        using (var context = new ApplicationDbContext(
           serviceProvider.GetRequiredService<
               DbContextOptions<ApplicationDbContext>>()))
        {
            if (!context.Proveedor.Any())
            {
                var proveedores = new Proveedor[]
                {
                new Proveedor { Nombre = "Agilent Technologies" },
                new Proveedor { Nombre = "Waters Corporation" },
                new Proveedor { Nombre = "Shimadzu Corporation" },
                new Proveedor { Nombre = "Thermo Fisher Scientific" },
                new Proveedor { Nombre = "PerkinElmer" },
                new Proveedor { Nombre = "Hitachi High-Tech" }
                // Agrega más proveedores si es necesario
                };
                context.Proveedor.AddRange(proveedores);
                context.SaveChanges();
            }

            if (!context.Marca.Any())
            {
                var marcas = new Marca[]
                {
                new Marca { Nombre = "InfinityLab LC Series", ProveedorId = 1 }, // Agilent Technologies
                new Marca { Nombre = "ACQUITY UPLC", ProveedorId = 2 }, // Waters Corporation
                new Marca { Nombre = "Nexera", ProveedorId = 3 }, // Shimadzu Corporation
                new Marca { Nombre = "Vanquish", ProveedorId = 4 }, // Thermo Fisher Scientific
                new Marca { Nombre = "Flexar", ProveedorId = 5 }, // PerkinElmer
                new Marca { Nombre = "Chromaster", ProveedorId = 6 }, // Hitachi High-Tech
                new Marca { Nombre = "1290 Infinity II LC", ProveedorId = 1 }, // Agilent Technologies
                new Marca { Nombre = "ACQUITY Arc", ProveedorId = 2 }, // Waters Corporation
                new Marca { Nombre = "Prominence", ProveedorId = 3 }, // Shimadzu Corporation
                new Marca { Nombre = "UltiMate 3000", ProveedorId = 4 }, // Thermo Fisher Scientific
                new Marca { Nombre = "Flexar FX-15", ProveedorId = 5 }, // PerkinElmer
                new Marca { Nombre = "Chiralpak", ProveedorId = 6 }, // Hitachi High-Tech
                new Marca { Nombre = "Alliance HPLC", ProveedorId = 2 }, // Waters Corporation
                new Marca { Nombre = "1260 Infinity II LC", ProveedorId = 1 }, // Agilent Technologies
                new Marca { Nombre = "Nexera X2", ProveedorId = 3 }, // Shimadzu Corporation
                new Marca { Nombre = "Vanquish Flex", ProveedorId = 4 }, // Thermo Fisher Scientific
                new Marca { Nombre = "Altus HPLC", ProveedorId = 5 }, // PerkinElmer
                new Marca { Nombre = "Primaide HPLC", ProveedorId = 6 } // Hitachi High-Tech
                                                                        // Agrega más marcas si es necesario
                };
                context.Marca.AddRange(marcas);
                context.SaveChanges();
            }

            if (!context.FaseMovil.Any())
            {
                var fasesMoviles = GenerateFasesMovilesSeedData();
                context.FaseMovil.AddRange(fasesMoviles);
                context.SaveChanges();
            }

            if (!context.Columna.Any())
            {
                var fasesMoviles = context.FaseMovil.ToList();
                var columnas = GenerateColumnaSeedData(fasesMoviles);
                context.Columna.AddRange(columnas);
                context.SaveChanges();
            }
        }
            
    }
    
}

