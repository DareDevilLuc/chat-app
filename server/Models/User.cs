using Microsoft.AspNetCore.Identity;
namespace server.Models;

public class User : IdentityUser<int> {
  public required string Name { get; set; }

  public ICollection<ChatParticipant> ChatParticipants { get; set; } = [];
  public ICollection<Message> MessagesSent { get; set; } = [];
}
