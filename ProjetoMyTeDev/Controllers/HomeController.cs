using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoMyTeDev.Data;
using ProjetoMyTeDev.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProjetoMyTeDev.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        //[Authorize(Policy = "RequerPerfilAdmin")]
        //public async Task<IActionResult> Funcionario()
        //{

        //    var funcionarios = await _context.ApplicationUser.Include(f => f.Departamento).Include(f => f.Cargo).ToListAsync();

        //    return View(funcionarios);
        //}

        public async Task<IActionResult> Funcionario(string nome, string localidade, string cargo, string departamento)
        {
            var query = _context.ApplicationUser.Include(f => f.Departamento).Include(f => f.Cargo).AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(f => f.Nome.Contains(nome));
            }

            if (!string.IsNullOrEmpty(localidade))
            {
                query = query.Where(f => f.Localidade.Contains(localidade));
            }

            if (!string.IsNullOrEmpty(cargo))
            {
                query = query.Where(f => f.Cargo.CargoNome.Contains(cargo));
            }

            if (!string.IsNullOrEmpty(departamento))
            {
                query = query.Where(f => f.Departamento.DepartamentoNome.Contains(departamento));
            }

            ViewBag.Nome = nome;
            ViewBag.Localidade = localidade;
            ViewBag.Cargo = cargo;
            ViewBag.Departamento = departamento;

            var funcionarios = await query.ToListAsync();

            return View(funcionarios);
        }

        public IActionResult ContateNos()
        {
            return View();
        }

        public async Task <IActionResult> EditFuncionario(string? Id)
        {
            
            if (Id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.ApplicationUser.FindAsync(Id);

            if (funcionario == null)
            {
                return NotFound();
            }
            ViewBag.Departamentos = new SelectList(_context.Departamento, "DepartamentoId", "DepartamentoNome", funcionario.DepartamentoId);
            ViewBag.Cargos = new SelectList(_context.Cargo, "CargoId", "CargoNome", funcionario.CargoId);
            return View(funcionario);
        }

        public async Task<IActionResult> DetailsFuncionario(string? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.ApplicationUser.Include(User => User.Departamento).Include(User => User.Cargo).FirstOrDefaultAsync(user => user.Id == Id);

            if (funcionario == null)
            {
                return NotFound();
            }
           
            return View(funcionario);
        }
    }
}
