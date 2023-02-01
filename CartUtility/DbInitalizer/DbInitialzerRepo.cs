using CartModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReviewCart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartUtility.DbInitalizer
{
    
    public class DbInitialzerRepo : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        public DbInitialzerRepo(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _userManager= userManager;
            _roleManager= roleManager;
            _context= context;
        }
        public void Initializer()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count()>0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;

            }
            if (!_roleManager.RoleExistsAsync(WebSiteRole.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Role_Admin))
                    .GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Role_User))
                    .GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Role_Employee))
                    .GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    Name = "Admin",
                    PhoneNumber = "01155072626",
                    Address = "xyz",
                    City = "xyz",
                    State = "xyz",
                    PinCode ="xyz"

                },"Admin@123").GetAwaiter().GetResult();
                ApplicationUser user = _context.ApplicationUsers
                    .FirstOrDefault(x => x.Email== "admin@gmail.com");
                _userManager.AddToRoleAsync(user,WebSiteRole.Role_Admin).GetAwaiter().GetResult() ;
            }
            return;
        }
    }
}
