// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsAndDishes.Models;
using System.Collections.Generic;

public class Chef
{
    [Key]
    public int ChefId { get; set; }

    [Required]
    [MinLength(2)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [Display(Name = "Date of Birth")]
    public DateTime DateofBirth { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> CreatedDishes { get; set; } = new List<Dish>();
    
    public string FullName()
    {
        return FirstName + " " + LastName;
    }

    // public class CheckChefAge : ValidationAttribute
    //     {
    //         protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
    //         {
    //             int age = CalculateAge((DateTime)value);
    //             if (age < 18)
    //             {
    //                 return new ValidationResult("Chefs must be at least 18 years old!");
    //             }
    //             return ValidationResult.Success;
    //         }
    //     }

    //     public static int CalculateAge(DateTime dob)
    //     {
    //         int age = 0;
    //         age = DateTime.Now.Year - dob.Year;
    //         if (DateTime.Now.DayOfYear < dob.DayOfYear)
    //         {
    //             age--;
    //         }
    //         return age;
    //     }
}

