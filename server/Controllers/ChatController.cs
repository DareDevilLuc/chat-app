using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using server.Models;
using server.Data;
using Microsoft.AspNetCore.SignalR;


namespace server.Controllers{
  [ApiController]
  [Route("api/[controller]")]

  public class ChatController : ControllerBase {
    private readonly AppDbContext _context;

    public ChatController(AppDbContext context) { _context = context; }

    [HttpGet("{id}")]
    public IActionResult GetChat (int id)
    {
      if(id <= 0)
        return BadRequest("Invalid Chat ID");

      return Ok($"Chat ID: {id}");

    }
  }
}
