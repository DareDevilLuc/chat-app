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

    var userId = Convert.ToInt32(User.FindFirst("userId")?.Value);


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
}
