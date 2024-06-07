using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using ProjetoMyTeDev.Data;
using ProjetoMyTeDev.Models;
using System.Diagnostics;
using ProjetoMyTeDev.Areas.Identity.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetoMyTeDev.Controllers
{
    public class RegistroDiariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistroDiariosController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        List<RegistroDiario> registros = new List<RegistroDiario>();

        // GET: RegistroDiarios
        public async Task<IActionResult> Index(DateTime? diaInicial = null, DateTime? diaFinal = null)
        {
            DateTime data = DateTime.Now;

            string dataFormatada = DateTime.Today.ToString("dddd", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR")) + ", " + data.ToString("dd/MM/yyyy");

            List<DateTime> QuinzenaAtual = new List<DateTime>();

            ViewBag.usuario = _userManager.GetUserAsync(User).Result;

            if (diaInicial == null || diaFinal == null)
            {
                diaInicial = new DateTime(data.Year, data.Month, (data.Day <= 15) ? 1 : 16);
                diaFinal = (data.Day <= 15) ? new DateTime(data.Year, data.Month, 15) : new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));

            }

            diaInicial = (DateTime)diaInicial;
            diaFinal = (DateTime)diaFinal;

            for (DateTime dia = (DateTime)diaInicial; dia <= diaFinal; dia = dia.AddDays(1))
            {
                QuinzenaAtual.Add(dia);
            }

            ViewBag.Quinzena = QuinzenaAtual;
            ViewBag.DataFormatada = dataFormatada;


            var context = _context.RegistroDiario.Include(r => r.Wbs).Where(r => r.Data >= diaInicial && r.Data <= diaFinal).Where(r => r.ApplicationUserId == _userManager.GetUserId(User));
            ViewBag.Wbs = await context.GroupBy(r => r.Wbs).Select(g => g.First().Wbs).ToListAsync();

            return View(await context.ToListAsync());
        }

        // GET: RegistroDiarios/Details/5
        [HttpGet]
        public async Task<List<RegistroDiario>> Details(string? id)
        {

            var registrosDiarios = await _context.RegistroDiario
                .Include(r => r.Wbs)
                .Where(m => m.ApplicationUserId == id)
                .ToListAsync();

            return registrosDiarios;
        }

        // GET: RegistroDiarios/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.usuario = _userManager.GetUserAsync(User).Result;
            ViewData["Wbs"] = _context.Wbs.ToList();
            return View();
        }

        // POST: RegistroDiarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] List<RegistroDiario> registrosDiarios)
        {
            if (ModelState.IsValid)
            {
                foreach (var registro in registrosDiarios)
                {
                    _context.Add(registro);
                }
            }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: RegistroDiarios/Edit/5
        public async Task<IActionResult> Edit(DateTime? diaInicial, DateTime? diaFinal)
        {
            DateTime data = DateTime.Now;

            string dataFormatada = DateTime.Today.ToString("dddd", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR")) + ", " + data.ToString("dd/MM/yyyy");

            ViewBag.DataFormatada = dataFormatada;

            ViewBag.usuario = _userManager.GetUserAsync(User).Result;

            if (diaInicial == null || diaFinal == null)
            {
                diaInicial = new DateTime(data.Year, data.Month, (data.Day <= 15) ? 1 : 16);
                diaFinal = (data.Day <= 15) ? new DateTime(data.Year, data.Month, 15) : new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
            }

            diaInicial = (DateTime)diaInicial;
            diaFinal = (DateTime)diaFinal;

            List<DateTime> QuinzenaAtual = new List<DateTime>();


            for (DateTime dia = (DateTime)diaInicial; dia <= diaFinal; dia = dia.AddDays(1))
            {
                QuinzenaAtual.Add(dia);
            }

            ViewBag.Quinzena = QuinzenaAtual;
            var context = _context.RegistroDiario.Include(r => r.Wbs).Where(r => r.Data >= diaInicial && r.Data <= diaFinal).Where(r => r.ApplicationUserId == _userManager.GetUserId(User));
            ViewBag.Wbs = await context.GroupBy(r => r.Wbs).Select(g => g.First().Wbs).ToListAsync();
            ViewBag.Registros = await context.ToListAsync();

            return View();
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

        public IActionResult RelatorioRegistro()
        {
            var registros = _context.RegistroDiario.Include(r => r.Wbs)
            .OrderByDescending(r => r.Horas) //ordernando decrescente as horas lançadas
            .ToList();

            return View(registros);

        }

        public IActionResult RelatorioRegistroFunc()
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user != null)
            {
                var registros = _context.RegistroDiario.Include(r => r.Wbs)
                    .Where(r => r.ApplicationUserId == user.Id)
                    .OrderByDescending(r => r.Horas)
                    .ToList();

                return View(registros);
            }
            return Content("Usuário não autenticado.");
        }

        public IActionResult RelatorioRegistroFuncParaAdmin()
        {
            // Busca os registros do banco de dados
            var registros = _context.RegistroDiario.Include(r => r.ApplicationUser).Include(r => r.Wbs).ToList();

            // Agrupa os registros por usuário e WBS e calcula a soma das horas para cada combinação
            var dadosProcessados = registros.GroupBy(
                r => new { Usuario = r.ApplicationUser.UserName, WbsCodigo = r.Wbs.WbsCodigo, WbsDescricao = r.Wbs.WbsDescricao },
                (key, group) => new
                {
                    NomeUsuario = key.Usuario,
                    WbsCodigo = key.WbsCodigo,
                    WbsDescricao = key.WbsDescricao,
                    TotalHoras = group.Sum(r => r.Horas)
                }
            )
            // Agrupa os registros por usuário
            .GroupBy(r => r.NomeUsuario)
            // Ordena os grupos de usuários em ordem decrescente pelo total de horas
            .OrderByDescending(group => group.Sum(r => r.TotalHoras))
            // Converte os resultados em uma lista e mantém a ordem de horas decrescente dentro de cada grupo de usuário
            .SelectMany(group => group.OrderByDescending(item => item.TotalHoras))
            .ToList();

            ViewBag.DadosProcessados = dadosProcessados;

            return View();

        }
    }
}
