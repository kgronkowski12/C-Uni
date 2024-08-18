using System.ComponentModel.DataAnnotations;

namespace EFCoreExample.Models
{
    public class Book
    {
        public int Id { get; set; }

		[Required(ErrorMessage = "Podaj nazwę książki.")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Tytuł musi mieć co najmiej 2 litery i co najwyżej 50 liter.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Podaj gatunek książki.")]
		public int GenreId { get; set; }
		[Required(ErrorMessage = "Podaj autora książki.")]
		public int AutorId { get; set; }
		[Required(ErrorMessage = "Podaj opis książki.")]
		[StringLength(400, MinimumLength = 10, ErrorMessage = "Opis musi mieć co najmiej 10 liter i co najwyżej 400.")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Podaj cenę.")]
		[Range(0, int.MaxValue,ErrorMessage = "Cena musi być dodatnia.")]
		public float Price { get; set; }
		public Autor Autor { get; set; }
		public Genre Genre { get; set; }
    }

	public class connectedBook
	{
		public String autorName { get; set; }
		public Genre genre { get; set; }
		public Book book { get; set; }
	}
}
