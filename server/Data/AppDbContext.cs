using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<User> Users { get; set; }
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

  }
  #endregion
}
