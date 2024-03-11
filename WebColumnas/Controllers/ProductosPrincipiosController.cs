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
    public class ProductosPrincipiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosPrincipiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductosPrincipios
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductosPrincipios.ToListAsync());
        }

        // GET: ProductosPrincipios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productosPrincipios = await _context.ProductosPrincipios
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (productosPrincipios == null)
            {
                return NotFound();
            }

            return View(productosPrincipios);
        }

        // GET: ProductosPrincipios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductosPrincipios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,PrincipiosActivosId,Concentracion")] ProductosPrincipios productosPrincipios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productosPrincipios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productosPrincipios);
        }

        // GET: ProductosPrincipios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productosPrincipios = await _context.ProductosPrincipios.FindAsync(id);
            if (productosPrincipios == null)
            {
                return NotFound();
            }
            return View(productosPrincipios);
        }

        // POST: ProductosPrincipios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoId,PrincipiosActivosId,Concentracion")] ProductosPrincipios productosPrincipios)
        {
            if (id != productosPrincipios.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productosPrincipios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductosPrincipiosExists(productosPrincipios.ProductoId))
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
            return View(productosPrincipios);
        }

        // GET: ProductosPrincipios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productosPrincipios = await _context.ProductosPrincipios
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (productosPrincipios == null)
            {
                return NotFound();
            }

            return View(productosPrincipios);
        }

        // POST: ProductosPrincipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productosPrincipios = await _context.ProductosPrincipios.FindAsync(id);
            if (productosPrincipios != null)
            {
                _context.ProductosPrincipios.Remove(productosPrincipios);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosPrincipiosExists(int id)
        {
            return _context.ProductosPrincipios.Any(e => e.ProductoId == id);
        }
    }
}
