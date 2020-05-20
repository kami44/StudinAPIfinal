using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudinAPI.Model;

namespace StudinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLessonController : ControllerBase
    {
        private readonly DBContext _context;

        public UserLessonController(DBContext context)
        {
            _context = context;
        }

        // GET: api/UserLesson
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLesson>>> GetUserLesson()
        {
            return await _context.UserLesson.ToListAsync();
        }

        // GET: api/UserLesson/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserLesson>> GetUserLesson(int id)
        {
            var userLesson = await _context.UserLesson.FindAsync(id);

            if (userLesson == null)
            {
                return NotFound();
            }

            return userLesson;
        }

        // PUT: api/UserLesson/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLesson(int id, UserLesson userLesson)
        {
            if (id != userLesson.Id)
            {
                return BadRequest();
            }

            _context.Entry(userLesson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLessonExists(id))
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

        // POST: api/UserLesson
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserLesson>> PostUserLesson(UserLesson userLesson)
        {
            UserLesson userlessontoadd = new UserLesson(userLesson.Fkusers, userLesson.Fklessons, userLesson.Checkedout);
            UserLesson query = _context.UserLesson.
                Where(x => x.Fkusers == userlessontoadd.Fkusers).
                Where(x => x.Fklessons == userlessontoadd.Fklessons)
                .FirstOrDefault();
            if (query == null) 
            { 
                _context.UserLesson.Add(userlessontoadd);
            }
            else
            {
                _context.Remove(query);
            }
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUserLesson", new { id = userLesson.Id }, userLesson);
            return CreatedAtAction(nameof(GetUserLesson), new { id = userLesson.Id }, userLesson);
        }

        // DELETE: api/UserLesson/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserLesson>> DeleteUserLesson(int id)
        {
            var userLesson = await _context.UserLesson.FindAsync(id);
            if (userLesson == null)
            {
                return NotFound();
            }

            _context.UserLesson.Remove(userLesson);
            await _context.SaveChangesAsync();

            return userLesson;
        }

        private bool UserLessonExists(int id)
        {
            return _context.UserLesson.Any(e => e.Id == id);
        }
    }
}
