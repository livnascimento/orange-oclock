using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoMyTeDev.Data;
using ProjetoMyTeDev.Models;

namespace ProjetoMyTeDev.Controllers
{
    public class CargaHorariasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CargaHorariasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CargaHorarias
        public async Task<IActionResult> Index()
        {
            return View(await _context.CargaHoraria.ToListAsync());
        }

        // GET: CargaHorarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargaHoraria = await _context.CargaHoraria
                .FirstOrDefaultAsync(m => m.CargaHorariaId == id);
            if (cargaHoraria == null)
            {
                return NotFound();
            }

            return View(cargaHoraria);
        }

        // GET: CargaHorarias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CargaHorarias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CargaHorariaId,NivelAcessoId,Horas")] CargaHoraria cargaHoraria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cargaHoraria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cargaHoraria);
        }

        // GET: CargaHorarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargaHoraria = await _context.CargaHoraria.FindAsync(id);
            if (cargaHoraria == null)
            {
                return NotFound();
            }
            return View(cargaHoraria);
        }

        // POST: CargaHorarias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CargaHorariaId,NivelAcessoId,Horas")] CargaHoraria cargaHoraria)
        {
            if (id != cargaHoraria.CargaHorariaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargaHoraria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargaHorariaExists(cargaHoraria.CargaHorariaId))
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
            return View(cargaHoraria);
        }

        // GET: CargaHorarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargaHoraria = await _context.CargaHoraria
                .FirstOrDefaultAsync(m => m.CargaHorariaId == id);
            if (cargaHoraria == null)
            {
                return NotFound();
            }

            return View(cargaHoraria);
        }

        // POST: CargaHorarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargaHoraria = await _context.CargaHoraria.FindAsync(id);
            if (cargaHoraria != null)
            {
                _context.CargaHoraria.Remove(cargaHoraria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CargaHorariaExists(int id)
        {
            return _context.CargaHoraria.Any(e => e.CargaHorariaId == id);
        }
    }
}
