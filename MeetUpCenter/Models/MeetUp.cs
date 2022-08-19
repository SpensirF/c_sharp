// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MeetUpCenter.Models;
using System.Collections.Generic;

public class MeetUp
{
    [Key]
    public int MeetupId { get; set; }

    [Required]
    [MinLength(2)]
    public string Title { get; set; }


    [Required]
    [FutureDate]
    public DateTime Date { get; set; }

    [Required]
    public int Duration { get; set; }

    [Required]
    [MinLength(2)]
    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int UserId {get; set; }
    public User? MeetupCreator {get; set; }

    public List<MeetupParticipant> Occasion {get; set;} = new List<MeetupParticipant>();









}