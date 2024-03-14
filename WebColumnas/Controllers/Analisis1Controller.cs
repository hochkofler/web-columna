using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebColumnas.Data;
using WebColumnas.Models;

namespace WebColumnas.Controllers
{
    public class Analisis1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Analisis1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Analisis1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Analisis.Include(a => a.Columnas).Include(a => a.Lote);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Analisis1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analisis = await _context.Analisis
                .Include(a => a.Columnas)
                .Include(a => a.Lote)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (analisis == null)
            {
                return NotFound();
            }

            return View(analisis);
        }

        // GET: Analisis1/Create
        public IActionResult Create()
        {
            ViewData["ColumnaId"] = new SelectList(_context.Columna, "ColumnaId", "ColumnaId");
            ViewData["LoteId"] = new SelectList(_context.Lote, "LoteID", "LoteID");
            return View();
        }

        // POST: Analisis1/Create
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
            ViewData["ColumnaId"] = new SelectList(_context.Columna, "ColumnaId", "ColumnaId", analisis.ColumnaId);
            ViewData["LoteId"] = new SelectList(_context.Lote, "LoteID", "LoteID", analisis.LoteId);
            return View(analisis);
        }

        // GET: Analisis1/Edit/5
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
            ViewData["ColumnaId"] = new SelectList(_context.Columna, "ColumnaId", "ColumnaId", analisis.ColumnaId);
            ViewData["LoteId"] = new SelectList(_context.Lote, "LoteID", "LoteID", analisis.LoteId);
            return View(analisis);
        }

        // POST: Analisis1/Edit/5
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
            ViewData["ColumnaId"] = new SelectList(_context.Columna, "ColumnaId", "ColumnaId", analisis.ColumnaId);
            ViewData["LoteId"] = new SelectList(_context.Lote, "LoteID", "LoteID", analisis.LoteId);
            return View(analisis);
        }

        // GET: Analisis1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analisis = await _context.Analisis
                .Include(a => a.Columnas)
                .Include(a => a.Lote)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (analisis == null)
            {
                return NotFound();
            }

            return View(analisis);
        }

        // POST: Analisis1/Delete/5
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
