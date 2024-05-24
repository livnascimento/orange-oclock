using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoMyTeDev.Data;
using ProjetoMyTeDev.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace ProjetoMyTeDev.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.RegistrosRecentes = await _context.RegistroDiario.OrderByDescending(t => t.Data).Take(10).ToListAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Policy = "RequerPerfilAdmin")]
        public IActionResult SomenteAdmin()
        {
            ViewBag.Funcionario = _context.Funcionario.Count();
            ViewBag.Departamento = _context.Departamento.Count();
            ViewBag.RegistroDiario = _context.RegistroDiario.Count();

            return View();
        }

        public IActionResult ContateNos()
        {
            return View();
        }
    }
}
