using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models;

public class Conversation
{
    public int Id { get; set; }

    public ICollection<ApplicationUser> Participants { get; set; }
    public ICollection<Message> Messages { get; set; }
}