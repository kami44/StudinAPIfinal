using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudinAPI.Model;

namespace StudinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly DBContext _context;

        public TeacherController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Teacher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeacher()
        {
 
            return await _context.Teacher.ToListAsync();
        
        }

        // GET: api/Teacher/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        // PUT: api/Teacher/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
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

        // POST: api/Teacher
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher(lol xx)
        {
            User userTeacher = _context.User.Find(xx.TeacherId);

            

            var query = _context.Course.
                Join(_context.Lesson, x => x.Id, y => y.Fkcourses, (x, y) => new { queryCourse = x, queryLesson = y }).
                Where(k => k.queryCourse.Fkusers == xx.TeacherId).
                Where(k => k.queryLesson.Lessonstart.Year == xx.CurrentLessonTime.Year).
                Where(k => k.queryLesson.Lessonstart.Month == xx.CurrentLessonTime.Month).
                Where(k => k.queryLesson.Lessonstart.Date == xx.CurrentLessonTime.Date).
                Where(k => (k.queryLesson.Lessonstart.AddMinutes(45).Hour >= xx.CurrentLessonTime.Hour && k.queryLesson.Lessonstart.AddMinutes(45).Minute >= xx.CurrentLessonTime.Minute) || k.queryLesson.Lessonstart.AddMinutes(45).Hour > xx.CurrentLessonTime.Hour).
                Select(o => o).ToList();

            var courseLesson = query.FirstOrDefault();
            string lessonstarttime = courseLesson.queryLesson.Lessonstart.Hour.ToString() + ":" + courseLesson.queryLesson.Lessonstart.Minute.ToString();
            string lessonendtime = courseLesson.queryLesson.Lessonstart.AddMinutes(45).Hour.ToString() + ":" + courseLesson.queryLesson.Lessonstart.AddMinutes(45).Minute.ToString();


            CurrentCourse course = new CurrentCourse(courseLesson.queryCourse.Id, courseLesson.queryLesson.Id, lessonstarttime, lessonendtime, courseLesson.queryCourse.Name);
            Teacher teacher = new Teacher(xx.TeacherId, userTeacher.Firstname, userTeacher.Lastname, course);

            List<User> queryStudentList = _context.UserCourse.
                Join(_context.User, k => k.Fkusers, j => j.Id, (k, j)=> new {k,j }).
                Where(x => x.k.Fkcourses == courseLesson.queryCourse.Id).
                Select(x=>x.j).ToList();
            var queryStudentAttendancy = _context.UserLesson.Where(x => x.Fklessons == courseLesson.queryLesson.Id);
            
            foreach(var student in queryStudentList)
            {
                var lolquery = queryStudentAttendancy.Where(x => x.Fkusers == student.Id).FirstOrDefault();
                bool attendancy = lolquery!=null ? true : false;
                teacher.CurrentCourse.Students.Add(new Student(student.Id, student.Firstname, student.Lastname, attendancy));
            }
            List<Course> courseList = _context.Course.Where(x => x.Fkusers == userTeacher.Id).ToList();
            teacher.Courses = courseList;
            
            return teacher;


            //_context.Teacher.Add(teacher);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTeacher", new { id = teacher.Id }, teacher);
        }

        // DELETE: api/Teacher/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher>> DeleteTeacher(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teacher.Remove(teacher);
            await _context.SaveChangesAsync();

            return teacher;
        }

        private bool TeacherExists(int id)
        {
            return _context.Teacher.Any(e => e.Id == id);
        }
    }
}
