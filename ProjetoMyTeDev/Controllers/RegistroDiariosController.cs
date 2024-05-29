using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoMyTeDev.Data;
using ProjetoMyTeDev.Models;
using ProjetoMyTeDev.Areas.Identity.Data;

namespace ProjetoMyTeDev.Controllers
{
    public class RegistroDiariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroDiariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistroDiarios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RegistroDiario.Include(r => r.Wbs);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RegistroDiarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDiario = await _context.RegistroDiario
                .Include(r => r.Wbs)
                .FirstOrDefaultAsync(m => m.RegistroDiarioId == id);
            if (registroDiario == null)
            {
                return NotFound();
            }

            return View(registroDiario);
        }

        // GET: RegistroDiarios/Create
        public IActionResult Create()
        {
            ViewData["Wbs"] = new SelectList(_context.Wbs, "WbsId", "WbsCodigo");
            return View();
        }

        // POST: RegistroDiarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("RegistroDiarioId,ApplicationUserId,WbsId,Data,Horas")] RegistroDiario registroDiario)
        public async Task<IActionResult> Create(RegistroDiario registroDiario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroDiario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Wbs"] = new SelectList(_context.Wbs, "WbsId", "WbsCodigo", registroDiario.WbsId);
            return View(registroDiario);
        }

        // GET: RegistroDiarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDiario = await _context.RegistroDiario.FindAsync(id);
            if (registroDiario == null)
            {
                return NotFound();
            }
            ViewData["WbsId"] = new SelectList(_context.Wbs, "WbsId", "WbsCodigo", registroDiario.WbsId);
            return View(registroDiario);
        }

        // POST: RegistroDiarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegistroDiarioId,ApplicationUserId,WbsId,Data,Horas")] RegistroDiario registroDiario)
        {
            if (id != registroDiario.RegistroDiarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroDiario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroDiarioExists(registroDiario.RegistroDiarioId))
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
            ViewData["WbsId"] = new SelectList(_context.Wbs, "WbsId", "WbsCodigo", registroDiario.WbsId);
            return View(registroDiario);
        }

        // GET: RegistroDiarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDiario = await _context.RegistroDiario
                .Include(r => r.Wbs)
                .FirstOrDefaultAsync(m => m.RegistroDiarioId == id);
            if (registroDiario == null)
            {
                return NotFound();
            }

            return View(registroDiario);
        }

        // POST: RegistroDiarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroDiario = await _context.RegistroDiario.FindAsync(id);
            if (registroDiario != null)
            {
                _context.RegistroDiario.Remove(registroDiario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroDiarioExists(int id)
        {
            return _context.RegistroDiario.Any(e => e.RegistroDiarioId == id);
        }
    }
}
