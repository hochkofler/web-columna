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
    public class ColumnasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColumnasController(ApplicationDbContext context)
        {
            _context = context;
        }

        private void PopulateMarcasDropDownList(object selectedMarca = null)
        {
            var marcasQuery = from d in _context.Marca
                                   orderby d.Nombre
                                   select d;
            ViewBag.MarcaId = new SelectList(marcasQuery.AsNoTracking(), "MarcaId", "Nombre", selectedMarca);
        }

        // GET: Columnas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Columna.Include(c => c.Marca).ThenInclude(c => c.Proveedor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Columnas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var columna = await _context.Columna
                .Include(c => c.Marca)
                .FirstOrDefaultAsync(m => m.ColumnaId == id);
            if (columna == null)
            {
                return NotFound();
            }

            return View(columna);
        }

        // GET: Columnas/Create
        public IActionResult Create()
        {
            ViewData["MarcaId"] = new SelectList(_context.Marca, "Id", "Nombre");
            return View();
        }

        // POST: Columnas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColumnaId,FechaIngreso,FechaEnMarcha,Dimension,FaseEstacionaria,Clase,PhMin,PhMax,PresionMax,MarcaId")] Columna columna)
        {
            if (ModelState.IsValid)
            {
                _context.Add(columna);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarcaId"] = new SelectList(_context.Marca, "Id", "Id", columna.MarcaId);
            return View(columna);
        }

        // GET: Columnas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var columna = await _context.Columna.FindAsync(id);
            if (columna == null)
            {
                return NotFound();
            }
            ViewData["MarcaId"] = new SelectList(_context.Marca, "Id", "Nombre", columna.MarcaId);
            return View(columna);
        }

        // POST: Columnas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ColumnaId,FechaIngreso,FechaEnMarcha,Dimension,FaseEstacionaria,Clase,PhMin,PhMax,PresionMax,MarcaId")] Columna columna)
        {
            if (id != columna.ColumnaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(columna);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColumnaExists(columna.ColumnaId))
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
            ViewData["MarcaId"] = new SelectList(_context.Marca, "Id", "Id", columna.MarcaId);
            return View(columna);
        }

        // GET: Columnas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var columna = await _context.Columna
                .Include(c => c.Marca)
                .FirstOrDefaultAsync(m => m.ColumnaId == id);
            if (columna == null)
            {
                return NotFound();
            }

            return View(columna);
        }

        // POST: Columnas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var columna = await _context.Columna.FindAsync(id);
            if (columna != null)
            {
                _context.Columna.Remove(columna);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColumnaExists(string id)
        {
            return _context.Columna.Any(e => e.ColumnaId == id);
        }
    }
}
