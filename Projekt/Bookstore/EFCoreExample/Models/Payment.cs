using EFCoreExample.Utility;
using System.ComponentModel.DataAnnotations;

namespace EFCoreExample.Models
{
    public class Payment
    {
        public int Id { get; set; }

		[Required(ErrorMessage = "Podaj imię.")]
		[StringLength(20, MinimumLength = 2, ErrorMessage = "Imię musi mieć co najmiej 2 litery i co najwyżej 20 liter.")]
		public string Name { get; set; }
        [Required(ErrorMessage = "Podaj nazwisko.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Nazwisko musi mieć co najmiej 2 litery i co najwyżej 20 liter.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Podaj miasto.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Miasto musi mieć co najmiej 2 litery i co najwyżej 20 liter.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Podaj ulicę.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Ulica musi mieć co najmiej 2 litery i co najwyżej 20 liter.")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Podaj kod pocztowy.")]
        [PostalCodeAttribute]
        public string Postal { get; set; }
        [Required(ErrorMessage = "Podaj numer karty.")]
        [Credit]
        public string Card{ get; set; }
        [Required(ErrorMessage = "Podaj kod cvv")]
        [StringLength(3, ErrorMessage = "Kod cvv musi mieć 3 znaki")]
        [RegularExpression("[0-9]{3}",ErrorMessage = "Kod cvv może mieć tylko liczby")]
        public string Cvv { get; set; }
    }
}
