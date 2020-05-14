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
    public class CheckinController : ControllerBase
    {
        private readonly DBContext _context;

        public CheckinController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Checkin
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Checkin>>> GetCheckin()
        {
            return await _context.Checkin.ToListAsync();
        }

        // GET: api/Checkin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Checkin>> GetCheckin(int id)
        {
            var checkin = await _context.Checkin.FindAsync(id);

            if (checkin == null)
            {
                return NotFound();
            }

            return checkin;
        }

        // PUT: api/Checkin/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheckin(int id, Checkin checkin)
        {
            if (id != checkin.Id)
            {
                return BadRequest();
            }

            _context.Entry(checkin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckinExists(id))
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

        // POST: api/Checkin
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Checkin>> PostCheckin(Checkin checkin)
        {
            //Checking In
            if (checkin.CheckingIn)
            {
                var student = _context.User.FromSqlRaw<User>("SELECT * FROM User WHERE Scannerkey = '"+checkin.Scannerkey+"'");
                User flamingo = new User(11,11,student.ToString(),"","","","","",11,11);


                if (student != null)
                {
                    _context.User.Add(flamingo);
                    _context.Checkin.Add(checkin);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetCheckin", new { id = checkin.Id }, checkin);

                    //var lesson = _context.Lesson.FromSqlRaw<Lesson>("SELECT l.Id AS lessonid, l.Lessonstart AS lessonstarttime, c.Id AS courseid " +
                    //    "FROM Lesson l " +
                    //    "INNER JOIN Course c "+
                    //    "ON l.Fkcourses = c.Id "+
                    //    "INNER JOIN Usercourse u "+
                    //    "ON c.Id = u.Fkcourses "+
                    //    "WHERE u.Fkusers = '&student.id'"+
                    //    "AND l.Fkclassrooms = '&checkin.Classroom'"+
                    //    "");
                }
                else
                {

                    return CreatedAtAction("GetCheckin", new { id = checkin.Id }, null);
                }
            }
            //Checking Out
            else
            {

                return CreatedAtAction("GetCheckin", new { id = checkin.Id }, null);
            }









            



        }

        // DELETE: api/Checkin/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Checkin>> DeleteCheckin(int id)
        {
            var checkin = await _context.Checkin.FindAsync(id);
            if (checkin == null)
            {
                return NotFound();
            }

            _context.Checkin.Remove(checkin);
            await _context.SaveChangesAsync();

            return checkin;
        }

        private bool CheckinExists(int id)
        {
            return _context.Checkin.Any(e => e.Id == id);
        }
    }
}
