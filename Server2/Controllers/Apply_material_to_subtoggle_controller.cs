using Microsoft.AspNetCore.Mvc;
using Server2.Models;
using System.Linq;

namespace Server2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplyMaterialController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApplyMaterialController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAudtypeid([FromQuery] string objectName, [FromQuery] int campusNum)
        {
            var audtypeid = _context.Audience
                .Where(a => a.aud_num == objectName && a.campus == campusNum)
                .Select(a => a.audtype_id)
                .FirstOrDefault();

            return Ok(audtypeid);
        }
    }
}
