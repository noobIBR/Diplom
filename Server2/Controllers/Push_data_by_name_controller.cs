using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Server2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PushDataByNameController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PushDataByNameController> _logger;

        public PushDataByNameController(ApplicationDbContext context, ILogger<PushDataByNameController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> PushDataByName([FromQuery] string get_aud_name, [FromQuery] string lang)
        {
            try
            {
                var result = await _context.Audience
                    .Where(a => a.aud_name.Contains(get_aud_name))
                    .Select(a => new
                    {
                        Aud_name = string.IsNullOrEmpty(a.aud_name) ? "N/A" : a.aud_name,
                        Audtype = lang == "ru" ? (a.audtype_ != null ? a.audtype_.type : "N/A") : (a.audtype_ != null ? a.audtype_.type_eng : "N/A"),
                        Campus = a.campus.ToString(),
                        Floor = a.floor.ToString(),
                        Aud_num = string.IsNullOrEmpty(a.aud_num) ? "N/A" : a.aud_num
                    })
                    .ToListAsync();

                string data = string.Join(",", result.Select(r => $"{r.Aud_name}, {r.Audtype}, {r.Campus}, {r.Floor}, {r.Aud_num}"));
                _logger.LogInformation("Data: {Data}", data);
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing request.");
                return $"Internal server error: {ex.Message}";
            }
        }
    }
}
