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

        // GET: Analisis/Create
        public IActionResult Create()
        {
            ViewData["LoteId"] = new SelectList(_context.Lote, "LoteID", "LoteID");
            ViewData["Principios"] = new MultiSelectList(_context.Lote.Include(a => a.Producto).ThenInclude(a => a.PrincipiosActivos), "Id", "Id");

            return View();
        }

        public IActionResult GetPrincipios(string loteId) //id del producto
        {
            var lote = _context.Lote.Find(loteId);
            if (lote == null)
            {
                return NotFound();
            }
            else
                return Json(_context.ProductosPrincipios.Where(a => a.ProductoId == lote.ProductoId)
                                            .Select(a => new {
                                                a.PrincipiosActivos.Id,
                                                a.PrincipiosActivos.Nombre
                                            })
                                            .ToList());
        }

        // POST: Analisis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ph,Presion,TiempoCorrida,Flujo,Temperatura,PresionIni,PresionFin,Comentario,LoteId,ColumnaId")] Analisis analisis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(analisis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoteId"] = new SelectList(_context.Lote, "LoteID", "LoteID", analisis.LoteId);
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
    }
}
