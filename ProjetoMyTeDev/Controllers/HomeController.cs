using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoMyTeDev.Data;
using ProjetoMyTeDev.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProjetoMyTeDev.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;



namespace ProjetoMyTeDev.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager <ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
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
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var usuario = await _userManager.FindByIdAsync(id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(usuario);
        //}

        [HttpPost]
        public async Task<IActionResult> DeleteFuncionario(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var funcionario = await _context.ApplicationUser.FindAsync(Id);

            var result = await _userManager.DeleteAsync(funcionario);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Funcionario));
            }
            else
            {
                return RedirectToAction("Error");
            }
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

      


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFuncionario(string? id, [Bind("Id,Nome,Email,DepartamentoId,DataContratacao,Localidade,CargoId,PhoneNumber")] ApplicationUser applicationUser)
        {
            

            var user = await _userManager.FindByIdAsync(applicationUser.Id);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            user.Nome = applicationUser.Nome;
            user.Email = applicationUser.Email;
            user.DepartamentoId = applicationUser.DepartamentoId;
            user.DataContratacao = applicationUser.DataContratacao;
            user.Localidade = applicationUser.Localidade;
            user.CargoId = applicationUser.CargoId;
            user.PhoneNumber = applicationUser.PhoneNumber;

            if (ModelState.IsValid)
            {


                try
                {
                    await _userManager.UpdateAsync(user);
                    //await _signIManager.RefreshSignInAsync(user);

                }
                catch (DbUpdateConcurrencyException)

                {

                    if (await _context.ApplicationUser.FindAsync(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Funcionario));
            }
            var funcionario = await _context.ApplicationUser.FindAsync(id);
            ViewBag.Departamentos = new SelectList(_context.Departamento, "DepartamentoId", "DepartamentoNome", funcionario.DepartamentoId);
            ViewBag.Cargos = new SelectList(_context.Cargo, "CargoId", "CargoNome", funcionario.CargoId);


            return View (funcionario);
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
