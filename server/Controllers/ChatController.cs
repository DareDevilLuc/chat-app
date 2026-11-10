using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using server.Models;
using server.Data;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace server.Controllers{
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
        .ToListAsync();

      return Ok( new { chats });

    }
  }
}
