using Microsoft.AspNetCore.Mvc;
using KeretaApiBackend.Models;
using KeretaApiBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace KeretaApiBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class KeretaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KeretaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/kereta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kereta>>> GetKeretas()
        {
            return await _context.Keretas.ToListAsync();
        }

        // POST: api/kereta
        [HttpPost]
        public async Task<ActionResult<Kereta>> CreateKereta(Kereta kereta)
        {
            _context.Keretas.Add(kereta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetKeretas), new { id = kereta.Id }, kereta);
        }
    }
}
