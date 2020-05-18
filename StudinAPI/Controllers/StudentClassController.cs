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
    public class StudentClassController : ControllerBase
    {
        private readonly DBContext _context;

        public StudentClassController(DBContext context)
        {
            _context = context;
        }

        // GET: api/StudentClass
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentClass>>> GetStudentClass()
        {
            return await _context.StudentClass.ToListAsync();
        }

        // GET: api/StudentClass/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentClass>> GetStudentClass(int id)
        {
            var studentClass = await _context.StudentClass.FindAsync(id);

            if (studentClass == null)
            {
                return NotFound();
            }

            return studentClass;
        }

        // PUT: api/StudentClass/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentClass(int id, StudentClass studentClass)
        {
            if (id != studentClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentClassExists(id))
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

        // POST: api/StudentClass
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudentClass>> PostStudentClass(StudentClass studentClass)
        {
            _context.StudentClass.Add(studentClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentClass", new { id = studentClass.Id }, studentClass);
        }

        // DELETE: api/StudentClass/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentClass>> DeleteStudentClass(int id)
        {
            var studentClass = await _context.StudentClass.FindAsync(id);
            if (studentClass == null)
            {
                return NotFound();
            }

            _context.StudentClass.Remove(studentClass);
            await _context.SaveChangesAsync();

            return studentClass;
        }

        private bool StudentClassExists(int id)
        {
            return _context.StudentClass.Any(e => e.Id == id);
        }
    }
}
