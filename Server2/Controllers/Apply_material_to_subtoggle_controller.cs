using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server2.Models;
using System.Linq;

namespace Server2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplyMaterialController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ApplyMaterialController> _logger;

        public ApplyMaterialController(ApplicationDbContext context, ILogger <ApplyMaterialController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAudtypeid([FromQuery] string objectName, [FromQuery] int campusNum)
        {
            try
            {
                var audtypeid = _context.Audience
                .Where(a => a.aud_num == objectName && a.campus == campusNum)
                .Select(a => a.audtype_id)
                .FirstOrDefault();
                return Ok(audtypeid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Request Error");
                return BadRequest(ex);
            }
        }
    }
}
