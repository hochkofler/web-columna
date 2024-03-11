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
    public class FasesMovilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FasesMovilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FasesMoviles
        public async Task<IActionResult> Index()
        {
            return View(await _context.FaseMovil.ToListAsync());
        }

        // GET: FasesMoviles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faseMovil = await _context.FaseMovil
                .FirstOrDefaultAsync(m => m.FaseMovilID == id);
            if (faseMovil == null)
            {
                return NotFound();
            }

            return View(faseMovil);
        }

        // GET: FasesMoviles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FasesMoviles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FaseMovilID,Nombre")] FaseMovil faseMovil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faseMovil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faseMovil);
        }

        // GET: FasesMoviles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faseMovil = await _context.FaseMovil.FindAsync(id);
            if (faseMovil == null)
            {
                return NotFound();
            }
            return View(faseMovil);
        }

        // POST: FasesMoviles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FaseMovilID,Nombre")] FaseMovil faseMovil)
        {
            if (id != faseMovil.FaseMovilID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faseMovil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaseMovilExists(faseMovil.FaseMovilID))
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
            return View(faseMovil);
        }

        // GET: FasesMoviles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faseMovil = await _context.FaseMovil
                .FirstOrDefaultAsync(m => m.FaseMovilID == id);
            if (faseMovil == null)
            {
                return NotFound();
            }

            return View(faseMovil);
        }

        // POST: FasesMoviles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faseMovil = await _context.FaseMovil.FindAsync(id);
            if (faseMovil != null)
            {
                _context.FaseMovil.Remove(faseMovil);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaseMovilExists(int id)
        {
            return _context.FaseMovil.Any(e => e.FaseMovilID == id);
        }
    }
}
