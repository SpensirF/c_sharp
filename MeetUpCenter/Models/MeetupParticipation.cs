// Disabled because we know the framework will assign non-null values when it
// constructs this class for us.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MeetUpCenter.Models; 

public class MeetupParticipant
{
    [Key]
    public int MeetupParticipantId {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    public int UserId {get; set;}
    public User? Participant {get; set;}
    public int MeetUpId {get; set;}
    public MeetUp? Occasion {get; set; }



}