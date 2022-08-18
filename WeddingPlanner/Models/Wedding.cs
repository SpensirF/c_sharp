// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;
using System.Collections.Generic;

public class Wedding
{
    [Key]
    public int WeddingId { get; set; }

    [Required]
    [MinLength(2)]
    [Display(Name = "Wedder One")]
    public string WedderOne { get; set; }

    [Required]
    [MinLength(2)]
    [Display(Name = "Wedder Two")]
    public string WedderTwo { get; set; }

    [Required]
    [FutureDate]
    public DateTime Date { get; set; }

    [Required]
    [Display(Name = "Wedding Address")]
    public string WeddingAddress { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int UserId {get; set; }
    public User? WeddingCreator {get; set; }

    public List<WeddingGuest> WeddGuest {get; set;} = new List<WeddingGuest>(); 









}