using Microsoft.AspNetCore.Mvc;
using Balynor_DB.Data;
using Balynor_DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Balynor_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DataController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Data
        [HttpPost]
        public async Task<IActionResult> PostData([FromBody] DataModel data)
        {
            if (data == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                _context.DataModels.Add(data);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Data successfully saved.", data });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Data
        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            var data = await _context.DataModels.ToListAsync();
            return Ok(data);
        }
    }
}