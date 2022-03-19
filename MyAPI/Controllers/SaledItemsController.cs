#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Database;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaledItemsController : ControllerBase
    {
        private readonly DotaItemAuctionDB _context;

        public SaledItemsController(DotaItemAuctionDB context)
        {
            _context = context;
        }

        // GET: api/SaledItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaledItem>>> GetSaledItems()
        {
            return await _context.SaledItems.ToListAsync();
        }

        // GET: api/SaledItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaledItem>> GetSaledItem(int id)
        {
            var saledItem = await _context.SaledItems.FindAsync(id);

            if (saledItem == null)
            {
                return NotFound();
            }

            return saledItem;
        }

        // PUT: api/SaledItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaledItem(int id, SaledItem saledItem)
        {
            if (id != saledItem.ID)
            {
                return BadRequest();
            }

            _context.Entry(saledItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaledItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SaledItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SaledItem>> PostSaledItem(SaledItem saledItem)
        {
            _context.SaledItems.Add(saledItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaledItem", new { id = saledItem.ID }, saledItem);
        }

        // DELETE: api/SaledItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaledItem(int id)
        {
            var saledItem = await _context.SaledItems.FindAsync(id);
            if (saledItem == null)
            {
                return NotFound();
            }

            _context.SaledItems.Remove(saledItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaledItemExists(int id)
        {
            return _context.SaledItems.Any(e => e.ID == id);
        }
    }
}
