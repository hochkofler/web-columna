using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebColumnas.Data;
using WebColumnas.Models;

namespace WebColumnas.Controllers
{
    public class AnalisisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnalisisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Analisis
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Analisis.Include(a => a.Lote);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Analisis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analisis = await _context.Analisis
                .Include(a => a.Lote)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (analisis == null)
            {
                return NotFound();
            }

            return View(analisis);
        }

        // GET: Analisis/ElegirLote
        public IActionResult ElegirLote()
        {
            var lotes = _context.Lote.ToList();
            return View(lotes);
        }

        // POST: Analisis/ElegirLote
        [HttpPost]
        public IActionResult ElegirLote(string idLote)
        {
            return RedirectToAction("Create", "Analisis", new { id = idLote });
        }

        // GET: Analisis/Create/5
        public IActionResult Create(string id)
        {
            var lote = _context.Lote.FirstOrDefault(l => l.LoteID == id);
            if (lote == null)
            {
                return NotFound();
            }
            var analisis = new Analisis { LoteId = id };
            ViewData["Principios"] = new MultiSelectList(ObtenerPrincipiosPorLote(id), "Id", "Nombre");
            return View(analisis);
        }

        // POST: Analisis1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Ph,Presion,TiempoCorrida,Flujo,Temperatura,PresionIni,PresionFin,Comentario,LoteId,ColumnaId")] Analisis analisis)
        {
            Console.WriteLine(analisis.LoteId);
            Console.WriteLine(analisis.PrincipiosActivos);
            if (ModelState.IsValid)
            {
                _context.Add(analisis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColumnaId"] = new SelectList(_context.Columna, "ColumnaId", "ColumnaId", analisis.ColumnaId);
            ViewData["LoteId"] = new SelectList(_context.Lote, "LoteID", "LoteID", analisis.LoteId);
            ViewData["Principios"] = new MultiSelectList(ObtenerPrincipiosPorLote(analisis.LoteId), "Id", "Nombre",analisis.PrincipiosActivos);
            return View(analisis);
        }

        // GET: Analisis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analisis = await _context.Analisis.FindAsync(id);
            if (analisis == null)
            {
                return NotFound();
            }
            ViewData["LoteId"] = new SelectList(_context.Lote, "LoteID", "LoteID", analisis.LoteId);
            return View(analisis);
        }

        // POST: Analisis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ph,Presion,TiempoCorrida,Flujo,Temperatura,PresionIni,PresionFin,Comentario,LoteId,ColumnaId")] Analisis analisis)
        {
            if (id != analisis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analisis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnalisisExists(analisis.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoteId"] = new SelectList(_context.Lote, "LoteID", "LoteID", analisis.LoteId);
            return View(analisis);
        }

        // GET: Analisis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analisis = await _context.Analisis
                .Include(a => a.Lote)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (analisis == null)
            {
                return NotFound();
            }

            return View(analisis);
        }

        // POST: Analisis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var analisis = await _context.Analisis.FindAsync(id);
            if (analisis != null)
            {
                _context.Analisis.Remove(analisis);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnalisisExists(int id)
        {
            return _context.Analisis.Any(e => e.Id == id);
        }

        
        public List<PrincipiosActivos> ObtenerPrincipiosPorLote(string loteId) //id del producto
        {
            var lote = _context.Lote.Include(l => l.Producto).FirstOrDefault(l => l.LoteID == loteId);

            if (lote == null || lote.Producto == null)
            {
                return new List<PrincipiosActivos>();
                //return Json(new List<PrincipiosActivos>());
            }
            return _context.PrincipiosActivos.Where(p => p.Productos.Any(p => p.Id == lote.ProductoId)).ToList();
            
        }
    }
}
