using System.ComponentModel.DataAnnotations;

namespace EFCoreExample.Utility
{
    public class PostalCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            string code = value as string;
			if (code == null)
			{
				return new ValidationResult("Wpisz kod pocztowy!");
			}
			if (code.Length != 6)
            {
                return new ValidationResult("Kod pocztowy musi mieć format xx-xxx.");
            }
            if (code[2] != '-')
            {
                return new ValidationResult("Kod pocztowy musi mieć format xx-xxx.");
            }
            for (int i = 0; i < 6; i++)
            {
                if (!Char.IsDigit(code[i]) && i!=2)
                {
                    return new ValidationResult("Kod pocztowy może się składać tylko z liczb i myślnika!");
                }
            }
            return ValidationResult.Success;
        }
    }
}
