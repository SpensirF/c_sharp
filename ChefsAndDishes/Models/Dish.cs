#pragma warning disable CS8618
/* 
Disabled Warning: "Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable."
We can disable this safely because we know the framework will assign non-null values when it constructs this class for us.
*/
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace ChefsAndDishes.Models;


public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(45)]
    public string Name { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(45)]
    public string Chef { get; set; }

    [Required]
    public int Tastiness { get; set; }

    [Required]
    public int Calories { get; set; }

    [Required]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}