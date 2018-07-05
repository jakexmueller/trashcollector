using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using trashcollector.Models;

[assembly: OwinStartupAttribute(typeof(trashcollector.Startup))]
namespace trashcollector
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        //Create default user roles ad Admin user for login
        private void CreateRolesandUsers()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            //Creating first admin Role and creating a default Admin User
            if (!roleManager.RoleExists("Admin"))
            {
                //creating admin role
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                roleManager.Create(role);

                //creating Admin super user who will maintain website
                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@trashcollector.com";

                string userPassword = "password";

                var checkUser = userManager.Create(user, userPassword);

                //Add default User to Role Admin   
                if (checkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }
        }
        }
    }
}
