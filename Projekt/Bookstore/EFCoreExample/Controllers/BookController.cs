using EFCoreExample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace EFCoreExample.Controllers {

	[Authorize(Roles = "Admin")]
	public class BookController : Controller
    {
        private CompanyContext context;
        public BookController(CompanyContext cc)
        {
            context = cc;
        }

        public IActionResult Index()
        {
            var connectedAutor = context.Book.Include(s => s.Autor).ToList();
			var connectedGenre = context.Book.Include(s => s.Genre).ToList();
            List<connectedBook> conMov = new List<connectedBook>();
            for (int i = 0; i < connectedAutor.Count; i++)
            {
				connectedBook conMov2 = new connectedBook();
                conMov2.autorName = connectedAutor[i].Autor.Name+" "+ connectedAutor[i].Autor.Surname;
				conMov2.genre = connectedAutor[i].Genre;
                conMov2.book = connectedAutor[i];
                conMov.Add(conMov2);
			}
			return View(conMov);
        }

        public IActionResult Create()
        {
            List<SelectListItem> dept = new List<SelectListItem>();
            dept = context.Genre.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.Genre = dept;
			dept = context.Autor.Select(x => new SelectListItem { Text = x.Name + " " + x.Surname, Value = x.Id.ToString() }).ToList();
			ViewBag.Autor = dept;

			return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create_Post()
        {
            /*context.Add(emp);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");*/

            var emptyEmployee = new Book();

            if (await TryUpdateModelAsync<Book>(emptyEmployee, "", s => s.Name, s => s.GenreId, s => s.AutorId, s => s.Description, s => s.Price))
            {
                context.Book.Add(emptyEmployee);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
			List<SelectListItem> dept = new List<SelectListItem>();
			dept = context.Genre.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
			ViewBag.Genre = dept;
			dept = context.Autor.Select(x => new SelectListItem { Text = x.Name + " " + x.Surname, Value = x.Id.ToString() }).ToList();
			ViewBag.Autor = dept;
			return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            Book emp = await context.Book.Where(e => e.Id == id).FirstOrDefaultAsync();

            List<SelectListItem> dept = new List<SelectListItem>();
            dept = context.Genre.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.Genre = dept;
			dept = context.Autor.Select(x => new SelectListItem { Text = x.Name+" "+x.Surname, Value = x.Id.ToString() }).ToList();
			ViewBag.Autor = dept;


			return View(emp);
        }

        /*[HttpPost]
        public async Task<IActionResult> Update(Employee emp)
        {
            context.Update(emp);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }*/

        [HttpPost]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employeeToUpdate = await context.Book.FirstOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync<Book>(
                employeeToUpdate,
                "",
                s => s.Name, s => s.GenreId, s => s.AutorId, s => s.Description, s => s.Price))
            {
                try
                {
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
			List<SelectListItem> dept = new List<SelectListItem>();
			dept = context.Genre.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
			ViewBag.Genre = dept;
			dept = context.Autor.Select(x => new SelectListItem { Text = x.Name + " " + x.Surname, Value = x.Id.ToString() }).ToList();
			ViewBag.Autor = dept;
			return View(employeeToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var emp = new Book() { Id = id };
            context.Remove(emp);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            // Linq
            var bookDet =
                (from book in context.Book
                 where book.Id == id
                 select book).Take(1).ToList();
            connectedBook conMov = new connectedBook();
            conMov.book = bookDet[0];
            // Linq
            var aut =
                (from autor in context.Autor
                 where autor.Id == bookDet[0].AutorId
                 select autor).Take(1).ToList();
            // Linq
            var gen =
                (from genre in context.Genre
                 where genre.Id == bookDet[0].GenreId
                 select genre).Take(1).ToList();
            conMov.genre = gen[0];
            conMov.autorName = aut[0].Name + " " + aut[0].Surname;

            List<Book> inne =
                    (from book in context.Book
                        where book.AutorId == aut[0].Id
                        select book).ToList();
            ViewBag.inne = inne;
            return View(conMov);
        }
    }
}
