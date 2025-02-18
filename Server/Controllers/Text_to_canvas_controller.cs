﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextToCanvasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TextToCanvasController> _logger;

        public TextToCanvasController(ApplicationDbContext context, ILogger<TextToCanvasController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> GetTextToCanvasData([FromQuery] string campus, [FromQuery] string aud_num, [FromQuery] string floor, [FromQuery] string lang)
        {
            try
            {
                int campus_num = int.Parse(campus);
                int floor_num = int.Parse(floor);

                var result = await _context.Audience
                    .Where(a => a.aud_num == aud_num && a.campus == campus_num && a.floor == floor_num)
                    .Select(a => new
                    {
                        a.aud_name,
                        Audtype = lang == "ru" ? a.audtype_.type : a.audtype_.type_eng,
                        a.campus,
                        a.floor,
                        a.aud_num,
                        Insts = lang == "ru" ? a.inst_.inst_name : a.inst_.inst_name_eng,
                        //Deps = lang == "ru" ? a.dep_.dep_name : a.dep_.dep_name_eng,
                        a.workplaces_num,
                        equipment = lang == "ru" ? a.equipment : a.equipment_eng
                    })
                    .ToListAsync();

                string data = string.Join("\n", result.Select(r => $"{r.aud_name}, {r.Audtype}, {r.campus}, {r.floor}, {r.aud_num}, {r.Insts}, {r.workplaces_num}, {r.equipment}"));
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
