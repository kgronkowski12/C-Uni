using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using EFCoreExample.Models;

namespace EFCoreExample.Controllers
{
    [Authorize(Roles="Admin")]
    public class AppRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AppRolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }

		public async Task<IActionResult> Update(string id)
		{
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            return View(role);
		}

		[HttpPost]
		public async Task<IActionResult> Update(IdentityRole dept)
		{
			IdentityRole roleToEdit = await _roleManager.FindByIdAsync(dept.Id);
			if (roleToEdit.Name != dept.Name)
			{
				roleToEdit.Name = dept.Name;
			}

			await _roleManager.UpdateAsync(roleToEdit);

			return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
            IdentityRole roleToDelete = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(roleToDelete);

			return RedirectToAction("Index");
		}
	}
}
