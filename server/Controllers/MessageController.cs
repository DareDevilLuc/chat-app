using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SignalRChatMVC.Hubs;
using server.Models;
using server.Data;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using server.DTO;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MessageController : ControllerBase
{

  private readonly AppDbContext _context;
  private readonly IHubContext<ChatHub> _hubContext;

  public MessageController(AppDbContext context, IHubContext<ChatHub> hubContext) { _context = context; _hubContext = hubContext; }

  [Authorize]
  [HttpGet("{chatId}")]
  public async Task<IActionResult> GetMessages(int chatId)
  {


    int userId = Convert.ToInt32(User.FindFirst("userId")!.Value);

    var messages = await _context.Messages
      .Where(m => m.ChatId == chatId)
      .Select(m => new MessageDto
      {
        Id = m.Id,
        ChatId = m.ChatId,
        SenderId = m.SenderId,
        SenderName = m.Sender.Name,
        Text = m.Content,
        CreatedAt = m.CreatedAt,
        IsOwn = m.SenderId == userId
      })
      .ToListAsync();


    return Ok(messages);
  }

  [Authorize]
  [HttpPost]
  public async Task<IActionResult> SendMessage(CreateMessageDto dto)
  {
    var senderId = Convert.ToInt32(User.FindFirst("userId")!.Value);

    var user = await _context.Users.FindAsync(senderId);

    if (user == null) return Unauthorized();

    var message = new Message
    {
      ChatId = dto.ChatId,
      SenderId = senderId,
      Content = dto.content,
      CreatedAt = DateTime.UtcNow
    };

    _context.Messages.Add(message);

    await _context.SaveChangesAsync();

    var messageDto = new MessageDto
    {
      Id = message.Id,
      ChatId = message.ChatId,
      SenderId = message.SenderId,
      SenderName = user.Name,
      Text = message.Content,
      CreatedAt = message.CreatedAt,
      IsOwn = message.SenderId == user.Id 
    };

    await _hubContext.Clients
      .Group(message.ChatId.ToString())
      .SendAsync("ReceiveMessage", messageDto);

    return Ok(messageDto);
  }
}
