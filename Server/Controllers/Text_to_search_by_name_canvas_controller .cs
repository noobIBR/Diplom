using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextToSearchByNameCanvasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TextToSearchByNameCanvasController> _logger;

        public TextToSearchByNameCanvasController(ApplicationDbContext context, ILogger<TextToSearchByNameCanvasController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAudData([FromQuery] string aud_name)
        {
            try
            {
                var result = await _context.Audience
                .Where(a => EF.Functions.Like(a.aud_name, $"%{aud_name}%"))
                .Select(a => new
                {
                    a.aud_name,
                    a.campus,
                    a.floor,
                    a.aud_num
                })
                .ToListAsync();
                string data = string.Join(" ", result.Select(r => $"{r.aud_name}, {r.campus}, {r.floor}, {r.aud_num}"));
                if (result.Any())
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing request.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
