namespace server.Models;

public class Chat {
  public int Id { get; set; }
  public string CreatedAt { get; set; } 

  public ICollection<ChatParticipant> ChatParticipants { get; set; }
  public ICollection<Message> Messages { get; set; }
}

