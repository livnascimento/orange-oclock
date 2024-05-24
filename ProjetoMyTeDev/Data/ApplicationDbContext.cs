using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoMyTeDev.Models;

namespace ProjetoMyTeDev.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProjetoMyTeDev.Models.ApplicationUser> ApplicationUser { get; set; } = default!;
        public DbSet<ProjetoMyTeDev.Models.Departamento> Departamento { get; set; } = default!;
        public DbSet<ProjetoMyTeDev.Models.RegistroDiario> RegistroDiario { get; set; } = default!;
        public DbSet<ProjetoMyTeDev.Models.Wbs> Wbs { get; set; } = default!;
        public DbSet<ProjetoMyTeDev.Models.NivelAcesso> NivelAcesso { get; set; } = default!;
        public DbSet<ProjetoMyTeDev.Models.Cargo> Cargo { get; set; } = default!;
    }
}
