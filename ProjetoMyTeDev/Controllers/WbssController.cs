using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoMyTeDev.Data;
using ProjetoMyTeDev.Models;

namespace ProjetoMyTeDev.Controllers
{
    public class WbssController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WbssController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "RequerPerfilAdmin")]
        // GET: Wbss
        public async Task<IActionResult> Index()
        {
            return View(await _context.Wbs.ToListAsync());
        }

        // GET: Wbss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wbs = await _context.Wbs
                .FirstOrDefaultAsync(m => m.WbsId == id);
            if (wbs == null)
            {
                return NotFound();
            }

            return View(wbs);
        }

        [Authorize(Policy = "RequerPerfilAdmin")]
        // GET: Wbss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wbss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WbsId,WbsCodigo,WbsTipo,WbsDescricao")] Wbs wbs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wbs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wbs);
        }

        // GET: Wbss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wbs = await _context.Wbs.FindAsync(id);
            if (wbs == null)
            {
                return NotFound();
            }
            return View(wbs);
        }

        // POST: Wbss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WbsId,WbsCodigo,WbsTipo,WbsDescricao")] Wbs wbs)
        {
            if (id != wbs.WbsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wbs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WbsExists(wbs.WbsId))
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
            return View(wbs);
        }

        // GET: Wbss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wbs = await _context.Wbs
                .FirstOrDefaultAsync(m => m.WbsId == id);
            if (wbs == null)
            {
                return NotFound();
            }

            return View(wbs);
        }

        // POST: Wbss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wbs = await _context.Wbs.FindAsync(id);
            if (wbs != null)
            {
                _context.Wbs.Remove(wbs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WbsExists(int id)
        {
            return _context.Wbs.Any(e => e.WbsId == id);
        }
    }
}
