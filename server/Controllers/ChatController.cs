using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using server.Models;
using server.Data;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using server.DTO;


namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ChatController : ControllerBase {
  private readonly AppDbContext _context;

  public ChatController(AppDbContext context) { _context = context; }

  [Authorize]
  [HttpGet]
  public async Task<IActionResult> GetChats()
  {

    var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);


    var chats = await _context.Chats
      .Where(c => c.ChatParticipants.Any(cp => cp.UserId == userId))
      .Select(c => new ChatDto {
          Id = c.Id,
          Name = c.ChatParticipants
                .Where(cp => cp.UserId != userId)
                .Select(cp => cp.User.Name)
                .FirstOrDefault() ?? "Unknown"
          })
      .ToListAsync();

    return Ok(chats);

  }
  [Authorize]
  [HttpGet("{chatId}")]
  public async Task<IActionResult> GetMessages(int chatId) {


    int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

    var messages = await _context.Messages
      .Where(m => m.ChatId == chatId)
      .Select(m => new MessageDto{
          Id = m.Id,
          ChatId = m.ChatId,
          SenderId = m.SenderId,
          SenderName = m.Sender.Name,
          Text = m.Content,
          CreatedAt = m.CreatedAt,
          IsOwn = m.SenderId == userId
          })
      .ToListAsync();


    return Ok();
  }
}
