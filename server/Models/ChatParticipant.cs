namespace server.Models;

public class ChatParticipant {
  public int ChatId { get; set; }
  public int UserId { get; set; }

  public User User { get; set; }
  public Chat Chat { get; set; }
}
