using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Server.Data.Models;
public class Message
{
    public int Id { get; set; }

    [Required]
    public string Content { get; set; }

    [System.ComponentModel.DataAnnotations.DataType(DataType.DateTime)]
    public DateTime SentAt { get; set; } = DateTime.UtcNow;

    [Required]
    public string SenderId { get; set; }

    public ApplicationUser Sender { get; set; }
    public Conversation Conversation { get; set; }
}