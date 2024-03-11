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
    public class PrincipiosActivosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrincipiosActivosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PrincipiosActivos
        public async Task<IActionResult> Index()
        {
            return View(await _context.PrincipiosActivos.ToListAsync());
        }

        // GET: PrincipiosActivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var principiosActivos = await _context.PrincipiosActivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (principiosActivos == null)
            {
                return NotFound();
            }

            return View(principiosActivos);
        }

        // GET: PrincipiosActivos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrincipiosActivos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] PrincipiosActivos principiosActivos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(principiosActivos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(principiosActivos);
        }

        // GET: PrincipiosActivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var principiosActivos = await _context.PrincipiosActivos.FindAsync(id);
            if (principiosActivos == null)
            {
                return NotFound();
            }
            return View(principiosActivos);
        }

        // POST: PrincipiosActivos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] PrincipiosActivos principiosActivos)
        {
            if (id != principiosActivos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(principiosActivos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrincipiosActivosExists(principiosActivos.Id))
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
            return View(principiosActivos);
        }

        // GET: PrincipiosActivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var principiosActivos = await _context.PrincipiosActivos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (principiosActivos == null)
            {
                return NotFound();
            }

            return View(principiosActivos);
        }

        // POST: PrincipiosActivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var principiosActivos = await _context.PrincipiosActivos.FindAsync(id);
            if (principiosActivos != null)
            {
                _context.PrincipiosActivos.Remove(principiosActivos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrincipiosActivosExists(int id)
        {
            return _context.PrincipiosActivos.Any(e => e.Id == id);
        }
    }
}
