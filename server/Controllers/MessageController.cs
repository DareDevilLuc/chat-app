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

public class MessageController : ControllerBase {

  private readonly AppDbContext _context;

  public MessageController(AppDbContext context) { _context = context; }

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


    return Ok(messages);
  }
}
