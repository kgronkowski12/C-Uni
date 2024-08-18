using System.ComponentModel.DataAnnotations;

namespace EFCoreExample.Models
{
    public class Autor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Podaj imie autora.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Imie musi mieć co najmiej 2 litery i co najwyżej 30 liter.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Podaj nazwisko autora.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Nazwisko musi mieć co najmiej 2 litery i co najwyżej 30 liter.")]
        public string Surname { get; set; }

        public ICollection<Book> Movie { get; set; }
    }
}
