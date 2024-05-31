using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoMyTeDev.Data;
using ProjetoMyTeDev.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProjetoMyTeDev.Areas.Identity.Data;

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
        public async Task<IActionResult> Funcionario()
        {

            var funcionarios = await _context.ApplicationUser.Include(f => f.Departamento).Include(f => f.Cargo).ToListAsync();

            return View(funcionarios);
        }

        public IActionResult ContateNos()
        {
            return View();
        }
    }
}
