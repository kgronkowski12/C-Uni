using EFCoreExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Controllers
{
	[Authorize(Roles = "Admin")]
	public class GenreController : Controller
    {
        private CompanyContext context;
        public GenreController(CompanyContext cc)
        {
            context = cc;
        }

        public IActionResult Index()
        {
            return View(context.Genre.AsNoTracking());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Genre dept)
        {
            context.Add(dept);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Genre dept = await context.Genre.Where(e => e.Id == id).FirstOrDefaultAsync();
            return View(dept);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Genre dept)
        {
            context.Update(dept);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var dept = new Genre() { Id = id };
            context.Remove(dept);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
