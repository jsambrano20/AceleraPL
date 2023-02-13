using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using Projeto03_Identity.Models;

[assembly: OwinStartupAttribute(typeof(Projeto03_Identity.Startup))]
namespace Projeto03_Identity
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
                    Email = "Admin@admin.com",
                    UserName = "Admin@admin.com"
                };
                var incUsuario = manager.Create(user, "Teste@22");

                if (incUsuario.Succeeded)
                {
                    var resultado = userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

                //Criar primeiro ADM

                var store = new UserStore<ApplicationUser>(context);
                var manager = new ApplicationUserManager(store);
                var user = new ApplicationUser()
                {
                    Email = "User@user.com",
                    UserName = "User@user.com"
                };
                var incUsuario = manager.Create(user, "Teste@22");

                if (incUsuario.Succeeded)
                {
                    var resultado = userManager.AddToRole(user.Id, "User");
                }
            }

            if (!roleManager.RoleExists("Visual"))
            {
                var role = new IdentityRole();
                role.Name = "Visual";
                roleManager.Create(role);

                //Criar primeiro ADM

                var store = new UserStore<ApplicationUser>(context);
                var manager = new ApplicationUserManager(store);
                var user = new ApplicationUser()
                {
                    Email = "Visual@visual.com",
                    UserName = "Visual@visual.com"
                };
                var incUsuario = manager.Create(user, "Teste@22");

                if (incUsuario.Succeeded)
                {
                    var resultado = userManager.AddToRole(user.Id, "Visual");
                }
            }

        }
    }
}
