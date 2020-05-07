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
    public class UserCourseController : ControllerBase
    {
        private readonly DBContext _context;

        public UserCourseController(DBContext context)
        {
            _context = context;
        }

        // GET: api/UserCourse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCourse>>> GetUserCourse()
        {
            return await _context.UserCourse.ToListAsync();
        }

        // GET: api/UserCourse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCourse>> GetUserCourse(int id)
        {
            var userCourse = await _context.UserCourse.FindAsync(id);

            if (userCourse == null)
            {
                return NotFound();
            }

            return userCourse;
        }

        // PUT: api/UserCourse/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCourse(int id, UserCourse userCourse)
        {
            if (id != userCourse.Id)
            {
                return BadRequest();
            }

            _context.Entry(userCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCourseExists(id))
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

        // POST: api/UserCourse
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserCourse>> PostUserCourse(UserCourse userCourse)
        {
            _context.UserCourse.Add(userCourse);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUserCourse", new { id = userCourse.Id }, userCourse);
            return CreatedAtAction(nameof(GetUserCourse), new { id = userCourse.Id }, userCourse);
        }

        // DELETE: api/UserCourse/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserCourse>> DeleteUserCourse(int id)
        {
            var userCourse = await _context.UserCourse.FindAsync(id);
            if (userCourse == null)
            {
                return NotFound();
            }

            _context.UserCourse.Remove(userCourse);
            await _context.SaveChangesAsync();

            return userCourse;
        }

        private bool UserCourseExists(int id)
        {
            return _context.UserCourse.Any(e => e.Id == id);
        }
    }
}
