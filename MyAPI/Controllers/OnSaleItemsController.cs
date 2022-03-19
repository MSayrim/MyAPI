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
    public class OnSaleItemsController : ControllerBase
    {
        private readonly DotaItemAuctionDB _context;

        public OnSaleItemsController(DotaItemAuctionDB context)
        {
            _context = context;
        }

        // GET: api/OnSaleItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OnSaleItem>>> GetOnSaleItems()
        {
            return await _context.OnSaleItems.ToListAsync();
        }

        // GET: api/OnSaleItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OnSaleItem>> GetOnSaleItem(int id)
        {
            var onSaleItem = await _context.OnSaleItems.FindAsync(id);

            if (onSaleItem == null)
            {
                return NotFound();
            }

            return onSaleItem;
        }

        // PUT: api/OnSaleItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOnSaleItem(int id, OnSaleItem onSaleItem)
        {
            if (id != onSaleItem.ID)
            {
                return BadRequest();
            }

            _context.Entry(onSaleItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OnSaleItemExists(id))
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

        // POST: api/OnSaleItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OnSaleItem>> PostOnSaleItem(OnSaleItem onSaleItem)
        {
            _context.OnSaleItems.Add(onSaleItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOnSaleItem", new { id = onSaleItem.ID }, onSaleItem);
        }

        // DELETE: api/OnSaleItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnSaleItem(int id)
        {
            var onSaleItem = await _context.OnSaleItems.FindAsync(id);
            if (onSaleItem == null)
            {
                return NotFound();
            }

            _context.OnSaleItems.Remove(onSaleItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OnSaleItemExists(int id)
        {
            return _context.OnSaleItems.Any(e => e.ID == id);
        }
    }
}
