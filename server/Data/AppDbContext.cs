using Microsoft.EntityFrameworkCore;
using server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace server.Data;

public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<Chat> Chats { get; set; }
  public DbSet<ChatParticipant> ChatParticipants { get; set; }
  public DbSet<Message> Messages { get; set; }

  #region Required
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<ChatParticipant>()
      .HasOne(cp => cp.User)
      .WithMany(u => u.ChatParticipants)
      .HasForeignKey(cp => cp.UserId);

    modelBuilder.Entity<ChatParticipant>()
      .HasOne(cp => cp.Chat)
      .WithMany(c => c.ChatParticipants)
      .HasForeignKey(cp => cp.ChatId);

    modelBuilder.Entity<Message>()
      .HasOne(m => m.Sender)
      .WithMany(s => s.MessagesSent)
      .HasForeignKey(m => m.SenderId);

    modelBuilder.Entity<Message>()
      .HasOne(m => m.Chat)
      .WithMany(c => c.Messages)
      .HasForeignKey(m => m.ChatId);

    modelBuilder.Entity<ChatParticipant>()
      .HasKey(cp => new { cp.UserId, cp.ChatId });

        // USERS
    modelBuilder.Entity<User>().HasData(
        new User { Id = 1, Name = "You", UserName = "You", NormalizedUserName = "YOU",
        ConcurrencyStamp = "seed-user-1"},
        new User { Id = 2, Name = "Bryan", UserName = "Bryan", NormalizedUserName = "BRYAN", 
        ConcurrencyStamp = "seed-user-2"},
        new User { Id = 3, Name = "Alex", UserName = "Alex", NormalizedUserName = "ALEX" , 
        ConcurrencyStamp = "seed-user-3"}
    );

    // CHATS
    modelBuilder.Entity<Chat>().HasData(
        new Chat
        {
            Id = 1,
            CreatedAt = new DateTime(2026, 10, 30, 18, 0, 0, DateTimeKind.Utc)
        }
    );

    modelBuilder.Entity<Message>().HasData(
    new Message
    {
        Id = 1,
        ChatId = 1,
        SenderId = 2,
        Content = "Hey, you coming to the thing tonight?",
        CreatedAt = new DateTime(2026, 10, 30, 18, 30, 0, DateTimeKind.Utc)
    },
    new Message
    {
        Id = 2,
        ChatId = 1,
        SenderId = 1,
        Content = "Yeah! What time are we meeting?",
        CreatedAt = new DateTime(2026, 10, 30, 18, 32, 0, DateTimeKind.Utc)
    },
    new Message
    {
        Id = 3,
        ChatId = 1,
        SenderId = 2,
        Content = "Around 7:30 PM. We're meeting at the usual spot.",
        CreatedAt = new DateTime(2026, 10, 30, 18, 33, 0, DateTimeKind.Utc)
    },
    new Message
    {
        Id = 4,
        ChatId = 1,
        SenderId = 1,
        Content = "Got it. I'll be there!",
        CreatedAt = new DateTime(2026, 10, 30, 18, 35, 0, DateTimeKind.Utc)
    },
    new Message
    {
        Id = 5,
        ChatId = 1,
        SenderId = 3,
        Content = "Don't forget to bring the documents tomorrow.",
        CreatedAt = new DateTime(2026, 10, 30, 18, 40, 0, DateTimeKind.Utc)
    },
    new Message
    {
        Id = 6,
        ChatId = 1,
        SenderId = 1,
        Content = "Thanks for reminding me. I almost forgot 😂",
        CreatedAt = new DateTime(2026, 10, 30, 18, 42, 0, DateTimeKind.Utc)
    },
    new Message
    {
        Id = 7,
        ChatId = 1,
        SenderId = 2,
        Content = "Also, did you finish the project?",
        CreatedAt = new DateTime(2026, 10, 30, 18, 45, 0, DateTimeKind.Utc)
    },
    new Message
    {
        Id = 8,
        ChatId = 1,
        SenderId = 1,
        Content = "Almost done. Just fixing a few bugs.",
        CreatedAt = new DateTime(2026, 10, 30, 18, 47, 0, DateTimeKind.Utc)
    },
    new Message
    {
        Id = 9,
        ChatId = 1,
        SenderId = 2,
        Content = "Nice! Let me know when it's ready.",
        CreatedAt = new DateTime(2026, 10, 30, 18, 50, 0, DateTimeKind.Utc)
    },
    new Message
    {
        Id = 10,
        ChatId = 1,
        SenderId = 1,
        Content = "Will do. See you later!",
        CreatedAt = new DateTime(2026, 10, 30, 18, 52, 0, DateTimeKind.Utc)
    }
);


  }
  #endregion
}
