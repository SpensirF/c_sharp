// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HobbyHub.Models; 

public class HobbyEnthusiast
{
    [Key]
    public int HobbyEnthusiastId {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public int UserId {get; set;}
    public User? Obsession {get; set;}
    public int HobbyId {get; set;}
    public Hobby? Enthusiast {get; set; }



}