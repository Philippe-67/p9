using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using p9.Data.Migrations;

namespace p9.Controllers
{

    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        // [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()

        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        //[Authorize(Roles = "Admin")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View(new IdentityRole());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
            return View();
        }
    }
}

