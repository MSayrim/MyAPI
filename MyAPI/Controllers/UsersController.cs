#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Database;
using MyAPI.DTO;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DotaItemAuctionDB _context;

        public UsersController(DotaItemAuctionDB context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            user.Password = null;

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/Users/5
        [Produces("application/json")]
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<ReturnUser>> Login(LoginUser loginUser)
        {
            var user = await _context.Users.Where(c=> c.Mail == loginUser.Email && c.Password == loginUser.UserPass).FirstOrDefaultAsync();

            ReturnUser returnUser = new ReturnUser();

            returnUser.ID = user.ID; 
            returnUser.UserName = user.Nick;

            if (user == null)
            {
                return NotFound();
            }


            return returnUser;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_context.Users.Where(a=>a.Mail==user.Mail).FirstOrDefault() !=null)
            {
                return BadRequest();
            }

            user.CreateDate = DateTime.Now;
            user.UpdateDate = DateTime.Now;
            user.DeleteDate = DateTime.Now;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.ID }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
