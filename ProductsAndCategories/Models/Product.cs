// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProductsAndCategories.Models;
using System.Collections.Generic;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    [MinLength(2)]
    public string Name { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]

    public double Price { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Association> item { get; set; } = new List<Association>();






}