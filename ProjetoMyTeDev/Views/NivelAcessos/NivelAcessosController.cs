using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoMyTeDev.Data;
using ProjetoMyTeDev.Models;

namespace ProjetoMyTeDev.Views.NivelAcessos
{
    public class NivelAcessosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NivelAcessosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NivelAcessos
        public async Task<IActionResult> Index()
        {
            return View(await _context.NivelAcesso.ToListAsync());
        }

        // GET: NivelAcessos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelAcesso = await _context.NivelAcesso
                .FirstOrDefaultAsync(m => m.NivelAcessoId == id);
            if (nivelAcesso == null)
            {
                return NotFound();
            }

            return View(nivelAcesso);
        }

        // GET: NivelAcessos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NivelAcessos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NivelAcessoId,NivelAcessoNome")] NivelAcesso nivelAcesso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nivelAcesso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nivelAcesso);
        }

        // GET: NivelAcessos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelAcesso = await _context.NivelAcesso.FindAsync(id);
            if (nivelAcesso == null)
            {
                return NotFound();
            }
            return View(nivelAcesso);
        }

        // POST: NivelAcessos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NivelAcessoId,NivelAcessoNome")] NivelAcesso nivelAcesso)
        {
            if (id != nivelAcesso.NivelAcessoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nivelAcesso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NivelAcessoExists(nivelAcesso.NivelAcessoId))
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
            return View(nivelAcesso);
        }

        // GET: NivelAcessos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nivelAcesso = await _context.NivelAcesso
                .FirstOrDefaultAsync(m => m.NivelAcessoId == id);
            if (nivelAcesso == null)
            {
                return NotFound();
            }

            return View(nivelAcesso);
        }

        // POST: NivelAcessos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nivelAcesso = await _context.NivelAcesso.FindAsync(id);
            if (nivelAcesso != null)
            {
                _context.NivelAcesso.Remove(nivelAcesso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NivelAcessoExists(int id)
        {
            return _context.NivelAcesso.Any(e => e.NivelAcessoId == id);
        }
    }
}
