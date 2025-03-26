using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Data.Models;

namespace Server.Data;

public class ServerDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Message> Messages { get; set; }
    public DbSet<Conversation> Conversations { get; set; }

    public ServerDbContext(DbContextOptions<ServerDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany(u => u.SentMessages)
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Conversation>()
            .HasMany(c => c.Participants)
            .WithMany(u => u.Conversations);

        builder.Entity<Conversation>()
            .HasMany(c => c.Messages)
            .WithOne(m => m.Conversation);

    }
}
