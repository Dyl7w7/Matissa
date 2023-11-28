using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Matissa.Models;

namespace Matissa.Controllers
{
    public class CitumsController : Controller
    {
        private readonly dbMatissaNETContext _context;

        public CitumsController(dbMatissaNETContext context)
        {
            _context = context;
        }

        // GET: Citums
        public async Task<IActionResult> Index()
        {
            var dbMatissaNETContext = _context.Cita.Include(c => c.IdClienteNavigation);
            return View(await dbMatissaNETContext.ToListAsync());
        }

        // GET: Citums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cita == null)
            {
                return NotFound();
            }

            var citum = await _context.Cita
                .Include(c => c.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (citum == null)
            {
                return NotFound();
            }

            return View(citum);
        }

        // GET: Citums/Create
        public IActionResult Create()
        {
            ViewData["Clientes"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            return View();
        }




        // POST: Citums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCita,FechaRegistro,CostoTotal,Estado,IdCliente")] Citum citum, int[] servicios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citum);
                await _context.SaveChangesAsync();

                // Guardar detalles de servicios seleccionados en la tabla DetalleCita
                if (servicios != null && servicios.Length > 0)
                {
                    foreach (var servicioId in servicios)
                    {
                        var detalleCita = new DetalleCitum
                        {
                            IdCita = citum.IdCita,
                            IdServicio = servicioId

                            // Otros campos si es necesario
                        };
                        _context.Add(detalleCita);
                    }
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            // Obtener la lista de clientes para la vista
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", citum.IdCliente);

            // Obtener la lista de servicios para la vista
            ViewBag.Servicios = _context.Servicios.ToList();

            return View(citum);

        }

        // GET: Citums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cita == null)
            {
                return NotFound();
            }

            var citum = await _context.Cita.FindAsync(id);
            if (citum == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", citum.IdCliente);
            return View(citum);
        }

        // POST: Citums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCita,FechaRegistro,CostoTotal,Estado,IdCliente")] Citum citum)
        {
            if (id != citum.IdCita)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitumExists(citum.IdCita))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", citum.IdCliente);
            return View(citum);
        }

        // GET: Citums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cita == null)
            {
                return NotFound();
            }

            var citum = await _context.Cita
                .Include(c => c.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdCita == id);
            if (citum == null)
            {
                return NotFound();
            }

            return View(citum);
        }

        // POST: Citums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cita == null)
            {
                return Problem("Entity set 'dbMatissaNETContext.Cita'  is null.");
            }
            var citum = await _context.Cita.FindAsync(id);
            if (citum != null)
            {
                _context.Cita.Remove(citum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitumExists(int id)
        {
          return (_context.Cita?.Any(e => e.IdCita == id)).GetValueOrDefault();
        }
    }
}
