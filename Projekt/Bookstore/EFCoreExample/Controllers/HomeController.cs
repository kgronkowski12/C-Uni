using EFCoreExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web;

namespace EFCoreExample.Controllers
{
    public class HomeController : Controller
    {
        private CompanyContext context;
        public HomeController(CompanyContext cc)
        {
            context = cc;
        }

        public IActionResult Index()
        { 
            var connectedAutor = context.Book.Include(s => s.Autor).ToList();
            var connectedGenre = context.Book.Include(s => s.Genre).ToList();
            ViewBag.text = "Wszystkie książki";
            List<connectedBook> conMov = new List<connectedBook>();
            for (int i = 0; i < connectedAutor.Count; i++)
            {
                connectedBook conMov2 = new connectedBook();
                conMov2.autorName = connectedAutor[i].Autor.Name + " " + connectedAutor[i].Autor.Surname;
                conMov2.genre = connectedAutor[i].Genre;
                conMov2.book = connectedAutor[i];
                conMov.Add(conMov2);
            }
            return View(conMov);
        }

        [HttpGet]
        public async Task<IActionResult> SearchGenre(int id)
        {
            // Linq
            var gen =
                    (from genre in context.Genre
                     where genre.Id == id
                     select genre).Take(1).ToList();
            ViewBag.text = "Książki z gatunku " + gen[0].Name;

            // Linq
            List<Book> bookQuery =
                (from book in context.Book
                 where book.GenreId == id
                 select book).ToList();

            List<connectedBook> conMov = new List<connectedBook>();
            for (int i = 0; i < bookQuery.Count; i++)
            {
                connectedBook conMov2 = new connectedBook();
                conMov2.genre = bookQuery[i].Genre;
                conMov2.book = bookQuery[i];
                // Linq
                var autr =
                    (from autor in context.Autor
                        where autor.Id == bookQuery[i].AutorId
                        select autor).Take(1).ToList();
                conMov2.autorName = autr[0].Name + " " + autr[0].Surname;
                conMov.Add(conMov2);
            }
            return View("Index",conMov);
        }

        [HttpGet]
        public async Task<IActionResult> SearchAutor(int id)
        {
            // Linq
            var aut =
                    (from autor in context.Autor
                     where autor.Id == id
                     select autor).Take(1).ToList();
            ViewBag.text = "Książki autorstwa " + aut[0].Name+" " + aut[0].Surname;

            // Linq
            List<Book> bookQuery =
                (from book in context.Book
                 where book.AutorId == id
                 select book).ToList();

            List<connectedBook> conMov = new List<connectedBook>();
            for (int i = 0; i < bookQuery.Count; i++)
            {
                connectedBook conMov2 = new connectedBook();
                // Linq
                var gen =
                    (from genre in context.Genre
                     where genre.Id == bookQuery[i].GenreId
                     select genre).Take(1).ToList();
                conMov2.genre = gen[0];
                conMov2.book = bookQuery[i];
                conMov2.autorName = aut[0].Name + " " + aut[0].Surname;
                conMov.Add(conMov2);
            }
            return View("Index", conMov);
        }

        public IActionResult CreateGenre()
        {
            var dept = new Genre()
            {
                Name = "Designing"
            };
            context.Entry(dept).State = EntityState.Added;
            context.SaveChanges();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Buy(int id)
        {
            var bookDet =
                (from book in context.Book
                 where book.Id == id
                 select book).Take(1).ToList();
            ViewBag.book = bookDet[0];
            Payment pay = new Payment();
            return View(pay);
        }
		[HttpPost]
		[ActionName("Buy")]
		public async Task<IActionResult> BuyPost(int id)
		{
			var empty = new Payment();

			if (await TryUpdateModelAsync<Payment>(empty, "", s => s.Name, s => s.Surname, s => s.City, s => s.Street, s => s.Postal, s => s.Card, s => s.Cvv))
			{
				return View("Thanks");
			}
			var bookDet =
				(from book in context.Book
				 where book.Id == id
				 select book).Take(1).ToList();
			ViewBag.book = bookDet[0];
			Payment pay = new Payment();
			return View(pay);
		}
	}
}