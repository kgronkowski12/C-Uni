using EFCoreExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AutorController : Controller
    {
        private CompanyContext context;
        public AutorController(CompanyContext cc)
        {
            context = cc;
        }

        public IActionResult Index()
        {
            return View(context.Autor.AsNoTracking());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Autor dept)
        {
            context.Add(dept);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Autor dept = await context.Autor.Where(e => e.Id == id).FirstOrDefaultAsync();
            return View(dept);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Autor dept)
        {
            context.Update(dept);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var dept = new Autor() { Id = id };
            context.Remove(dept);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
