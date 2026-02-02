using BlogCochesSolution.AccesoDatos.Data;
using BlogCochesSolution.Models;
using BlogCochesSolution.Utilidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogCochesSolution.AccesoDatos.Inicializador
{
    public class InicializadorBD : IInicializadorBD
    {
        private readonly ApplicationDbContext _bd;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public InicializadorBD(ApplicationDbContext bd,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _bd = bd;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public void Inicializar()
        {
            try
            {
                if (_bd.Database.GetPendingMigrations().Count() > 0)
                {
                    _bd.Database.Migrate();
                }
            }
            catch (Exception)
            {                
            }

            if (_bd.Roles.Any(ro => ro.Name == CNT.Administrador)) return;

            //Creación de roles
            _roleManager.CreateAsync(new IdentityRole(CNT.Administrador)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CNT.Registrado)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CNT.Cliente)).GetAwaiter().GetResult();

            //Creación del usuario inicial
            var resultado = _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "rubendelanieta",
                Email = "rubendelanieta6@gmail.com",
                EmailConfirmed = true,
                Nombre = "Ruben",
                Direccion = "Calle X",
                Ciudad = "Yuncos",
                Pais = "España"
            }, "Admin1234#").GetAwaiter().GetResult();

            var usuario = _userManager.FindByEmailAsync("rubendelanieta6@gmail.com")
                .GetAwaiter().GetResult();

            if (!resultado.Succeeded)
            {
                // Aquí puedes lanzar excepción o loguear errores
                throw new Exception(
                    string.Join(" | ", resultado.Errors.Select(e => e.Description))
                );
            }

            if (usuario != null)
            {
                _userManager.AddToRoleAsync(usuario, CNT.Administrador)
                    .GetAwaiter().GetResult();
            }
        }
    }
}
