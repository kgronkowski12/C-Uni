using System.ComponentModel.DataAnnotations;

namespace EFCoreExample.Utility
{
    public class CreditAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            string card = value as string;
            if(card == null)
            {
				return new ValidationResult("Wpisz numer karty!");
			}
            if (card.Length > 19)
            {
                return new ValidationResult("Numer karty może mieć maksymalnie 19 znaków.");
            }
			if (card.Length < 9)
			{
				return new ValidationResult("Numer karty musi mieć przynajmniej 9 znaków.");
			}
			for (int i = 0; i < card.Length; i++)
            {
                if (!Char.IsDigit(card[i]))
                {
                    return new ValidationResult("Numer karty może zawierać tylko liczby!");
                }
            }
            return ValidationResult.Success;
        }
    }
}
