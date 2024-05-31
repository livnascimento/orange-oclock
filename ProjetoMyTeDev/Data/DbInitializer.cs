using ProjetoMyTeDev.Data;
using Microsoft.AspNetCore.Identity;
using ProjetoMyTeDev.Areas.Identity.Data;
using ProjetoMyTeDev.Models;

public class DbInitializer
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var context = serviceProvider
            .GetRequiredService<ApplicationDbContext>();

        context.Database.EnsureCreated();

        var roleManager = serviceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

        var userManager = serviceProvider
            .GetRequiredService<UserManager<ApplicationUser>>();

        var config = serviceProvider
            .GetRequiredService<IConfiguration>();

        var cargos = new List<Cargo>
        {
            new Cargo { CargoNome = "Assoc.", CargaHoraria = 6 },
            new Cargo { CargoNome = "Consultor", CargaHoraria = 8 },
            new Cargo { CargoNome = "Gerente", CargaHoraria = 8 },
            new Cargo { CargoNome = "Analista", CargaHoraria = 8 },
            new Cargo { CargoNome = "Diretor",  CargaHoraria = 8},
            new Cargo { CargoNome = "Especialista", CargaHoraria= 8},
            new Cargo { CargoNome = "Líder" , CargaHoraria = 8 }
        };

        var departamentos = new List<Departamento>
        {
            new Departamento { DepartamentoNome = "RH"},
            new Departamento { DepartamentoNome = "Tecnologia"},
            new Departamento { DepartamentoNome = "Marketing"},
            new Departamento { DepartamentoNome = "Financeiro"},
            new Departamento { DepartamentoNome = "Vendas"},
            new Departamento { DepartamentoNome = "Administrativo"}
        };

        var wbss = new List<Wbs>
        {
            new Wbs { WbsCodigo = "WBS7182711", WbsTipo = "Non-Chargeability", WbsDescricao = "Férias"},
            new Wbs { WbsCodigo = "WDO1025246", WbsTipo = "Chargeability", WbsDescricao = "Day-Off"},
            new Wbs { WbsCodigo = "WST3520872", WbsTipo = "Non-Chargeability", WbsDescricao = "Sem tarefa"},
            new Wbs { WbsCodigo = "WIP8918823", WbsTipo = "Chargeability", WbsDescricao = "Implementação"},
            new Wbs { WbsCodigo = "WDE0283714", WbsTipo = "Chargeability", WbsDescricao = "Desenvolvimento"},
        };

        var adminRole = "admin";
        var userRole = "user";

        foreach (var cargo in cargos)
        {
            if (! context.Cargo.Any(c => c.CargoNome == cargo.CargoNome))
                context.Cargo.Add(cargo);
        }
        
        foreach (var departamento in departamentos)
        {
            if (! context.Departamento.Any(d => d.DepartamentoNome == departamento.DepartamentoNome))
                context.Departamento.Add(departamento);
        }

        await context.SaveChangesAsync();

        if (!await roleManager.RoleExistsAsync(adminRole))
        {
            await roleManager.CreateAsync(new IdentityRole(adminRole));
        }

        if (!await roleManager.RoleExistsAsync(userRole))
        {
            await roleManager.CreateAsync(new IdentityRole(userRole));
        }

        var adminEmail = config["AdminCredentials:Email"];
        var adminPassword = config["AdminCredentials:Password"];
        var Nome = config["AdminCredentials:Nome"];

        var admin = await userManager.FindByEmailAsync(adminEmail);

        if (admin == null)
        {
            admin = new ApplicationUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true, Nome = Nome, CargoId = 2, DepartamentoId = 2, Localidade = "PE" };
            var result = await userManager.CreateAsync(admin, adminPassword);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, adminRole);
            }
        }
        else
        {
            if (!await userManager.IsInRoleAsync(admin, adminRole))
            {
                await userManager.AddToRoleAsync(admin, adminRole);
            }
        }

    }
}