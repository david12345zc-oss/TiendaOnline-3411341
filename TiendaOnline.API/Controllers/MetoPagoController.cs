using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaOnline.API.Data;
using TiendaOnline.API.Models;

namespace TiendaOnline.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetodoPagoController : ControllerBase
    {
        private readonly TiendaOnlineDbContext _context;

        public MetodoPagoController(TiendaOnlineDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetodoPago>>> GetMetodoPago()
        {
            return await _context.MetodoPago.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MetodoPago>> GetMetodoPago(int id)
        {
            var metodoPago = await _context.MetodoPago.FindAsync(id);
            if (metodoPago == null) return NotFound();
            return metodoPago;
        }

        [HttpPost]
        public async Task<ActionResult<MetodoPago>> PostMetodoPago(MetodoPago metodoPago)
        {
            _context.MetodoPago.Add(metodoPago);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMetodoPago),
                new { id = metodoPago.IdMetodoPago }, metodoPago);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetodoPago(int id, MetodoPago metodoPago)
        {
            if (id != metodoPago.IdMetodoPago) return BadRequest();
            _context.Entry(metodoPago).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.MetodoPago.Any(m => m.IdMetodoPago == id))
                    return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetodoPago(int id)
        {
            var metodoPago = await _context.MetodoPago.FindAsync(id);
            if (metodoPago == null) return NotFound();
            _context.MetodoPago.Remove(metodoPago);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
