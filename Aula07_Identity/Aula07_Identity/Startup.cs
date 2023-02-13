using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Aula07_Identity.Models;
using System.Linq.Expressions;
using System;
using Microsoft.Ajax.Utilities;

[assembly: OwinStartupAttribute(typeof(Aula07_Identity.Startup))]
namespace Aula07_Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CriarRolesUsuarios();
        }

        private void CriarRolesUsuarios()
        {
            //
            ApplicationDbContext context = new ApplicationDbContext();

            //Gerenciador de ROLE
            var roleManager =
                new RoleManager<IdentityRole>(new
                    RoleStore<IdentityRole>(context));

            //Gerenciador de USER
            var userManager =
                new UserManager<ApplicationUser>(new
                    UserStore<ApplicationUser>(context));

            //Criar Role Admin

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Criar primeiro ADM

                var store = new UserStore<ApplicationUser>(context);
                var manager = new ApplicationUserManager(store);
                var user = new ApplicationUser()
                {
                    Email = "Admin@tst.com",
                    UserName = "Admin@tst.com"
                };
                var incUsuario = manager.Create(user, "Teste@22");

                if (incUsuario.Succeeded)
                {
                    var resultado = userManager.AddToRole(user.Id, "Admin");
                }
            }

        }
    }
}
