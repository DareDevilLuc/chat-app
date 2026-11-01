namespace server.Models;

public class User {
  public int Id { get; set; }
  public required string Name { get; set; }

  public ICollection<ChatParticipant> ChatParticipants { get; set; }
  public ICollection<Message> MessagesSent { get; set; }
}
