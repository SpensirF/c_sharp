using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models;

public class FutureDate : ValidationAttribute 
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            //pass our vbalidator so that it continues to the next one 
            //b/c we cant check an empty date 
            return ValidationResult.Success;
        }

        DateTime date = (DateTime)value; 

        if(date <= DateTime.Now)
        {
            return new ValidationResult("Must be future date");
        }

        return ValidationResult.Success;
    }
}