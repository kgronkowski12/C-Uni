using System.ComponentModel.DataAnnotations;

namespace EFCoreExample.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Podaj nazwe gatunku.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Nazwa musi mieć co najmiej 2 litery i co najwyżej 20 liter.")]
        public string Name { get; set; }

        public ICollection<Book> Movie { get; set; }
    }
}
