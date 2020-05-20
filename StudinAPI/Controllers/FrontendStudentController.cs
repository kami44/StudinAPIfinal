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
    public class FrontendStudentController : ControllerBase
    {
        private readonly DBContext _context;

        public FrontendStudentController(DBContext context)
        {
            _context = context;
        }

        // GET: api/FrontendStudent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FrontendStudent>>> GetFrontendStudent()
        {
            return await _context.FrontendStudent.ToListAsync();
        }

        // GET: api/FrontendStudent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FrontendStudent>> GetFrontendStudent(int id)
        {
            var frontendStudent = await _context.FrontendStudent.FindAsync(id);

            if (frontendStudent == null)
            {
                return NotFound();
            }

            return frontendStudent;
        }

        // PUT: api/FrontendStudent/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFrontendStudent(int id, FrontendStudent frontendStudent)
        {
            if (id != frontendStudent.Id)
            {
                return BadRequest();
            }

            _context.Entry(frontendStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FrontendStudentExists(id))
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

        // POST: api/FrontendStudent
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FrontendStudent>> PostFrontendStudent(lal xx)
        {


            var studentquery = _context.User.Where(x => x.Scannerkey == xx.Scannerkey).FirstOrDefault();
            
            int studentId = studentquery.Id;
            string firstName = studentquery.Firstname;
            string lastName = studentquery.Lastname;


            var query = _context.Course.
                Join(_context.UserCourse, c => c.Id, u => u.Fkcourses, (c, u) => new { course = c, userCourse = u }).
                Join(_context.Lesson, cu => cu.course.Id, l => l.Fkcourses, (cu, l) => new { cu, lesson = l }).
                Where(x => x.cu.userCourse.Fkusers == studentId).
                Where(k => k.lesson.Lessonstart.Year == xx.CurrentLessonTime.Year).
                Where(k => k.lesson.Lessonstart.Month == xx.CurrentLessonTime.Month).
                Where(k => k.lesson.Lessonstart.Date == xx.CurrentLessonTime.Date).
                Where(k => (k.lesson.Lessonstart.AddMinutes(45).Hour >= xx.CurrentLessonTime.Hour && k.lesson.Lessonstart.AddMinutes(45).Minute >= xx.CurrentLessonTime.Minute) || k.lesson.Lessonstart.AddMinutes(45).Hour > xx.CurrentLessonTime.Hour).
                ToList();

            var culesson = query.FirstOrDefault();
            string lessonstarttime = culesson.lesson.Lessonstart.Hour.ToString() + ":" + culesson.lesson.Lessonstart.Minute.ToString("00");
            string lessonendtime = culesson.lesson.Lessonstart.AddMinutes(45).Hour.ToString() + ":" + culesson.lesson.Lessonstart.AddMinutes(45).Minute.ToString("00");

            string classroomname = _context.Classrooms.Where(x => x.Id == culesson.lesson.Fkclassrooms).Select(o=>o.Name).FirstOrDefault();

            CurrentCourse currentCourse = new CurrentCourse(culesson.cu.course.Id, culesson.lesson.Id, lessonstarttime, lessonendtime, culesson.cu.course.Name,classroomname);

            List<Course> coursequery = _context.UserCourse.Join(_context.Course, u => u.Fkcourses, c => c.Id, (u, c) => new { usercourse = u, course = c }).Where(x => x.usercourse.Fkusers == studentId).Select(o=>o.course).ToList();

            FrontendStudent frontendStudent = new FrontendStudent(studentId, xx.Scannerkey, firstName, lastName, currentCourse);

            foreach (Course course in coursequery)
            {
                frontendStudent.Courses.Add(course);
            }

            

            return frontendStudent;
            //_context.FrontendStudent.Add(frontendStudent);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetFrontendStudent", new { id = frontendStudent.Id }, frontendStudent);


        }

        // DELETE: api/FrontendStudent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FrontendStudent>> DeleteFrontendStudent(int id)
        {
            var frontendStudent = await _context.FrontendStudent.FindAsync(id);
            if (frontendStudent == null)
            {
                return NotFound();
            }

            _context.FrontendStudent.Remove(frontendStudent);
            await _context.SaveChangesAsync();

            return frontendStudent;
        }

        private bool FrontendStudentExists(int id)
        {
            return _context.FrontendStudent.Any(e => e.Id == id);
        }
    }
}
