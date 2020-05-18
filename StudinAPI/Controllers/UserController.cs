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
    public class UserController : ControllerBase
    {
        private readonly DBContext _context;

        public UserController(DBContext context)
        {
            _context = context;
            if (_context.User.Count() == 0)
            {

                /*      
                        _________________________________________________________________________
                        |Tid        |Man        |Tir        |Ons        |Tor        |Fre        |
                        |___________|___________|___________|___________|___________|___________|
                        |09:00-08:45|Sys        |Prog       |           |Prog       |Tek        |
                        |___________|___________|___________|___________|___________|___________|
                        |10:05-10:50|Sys        |Prog       |           |Prog       |Tek        |
                        |___________|___________|___________|___________|___________|___________|
                        |10:50-11:35|Sys        |Prog       |           |Prog       |Tek        |
                        |___________|___________|___________|___________|___________|___________|
                        |12:15-13:00|Sys        |Tek        |           |Sys        |Tek        |
                        |___________|___________|___________|___________|___________|___________|
                        |13:00-13:45|           |Tek        |           |Sys        |           |
                        |___________|___________|___________|___________|___________|___________|
                        |14:00-14:45|           |Tek        |           |Sys        |           |
                        |___________|___________|___________|___________|___________|___________|
                        




                */
                //teachers
                _context.User.Add(new User(0, "userteacher", "pass", "salt", "Anders", "Kristian Børjesson", "email", 22222222, 2));
                _context.User.Add(new User(0, "userteacher2", "pass", "salt", "Michael", "Hammel", "email", 22222222, 2));
                _context.User.Add(new User(0, "userteacher3", "pass", "salt", "Jamshid", "Eftekhari", "email", 22222222, 2));



                //students
                _context.User.Add(new User(1, "userstudent", "pass", "salt", "Lars", "Selvik", "email", 22222222, 3));
                _context.User.Add(new User(2, "userstudent1", "pass", "salt", "Patrick", "Poul Nielsen", "email", 22222222, 3));
                _context.User.Add(new User(3, "userstudent2", "pass", "salt", "Caspar", "Mortensen", "email", 22222222, 3));
                _context.User.Add(new User(4, "userstudent3", "pass", "salt", "Anders", "Hansen", "email", 22222222, 3));
                _context.User.Add(new User(5, "userstudent4", "pass", "salt", "Daniel", "Petersen", "email", 22222222, 3));
                _context.User.Add(new User(6, "userstudent5", "pass", "salt", "Jonas", "Andersen", "email", 22222222, 3));
                _context.User.Add(new User(7, "userstudent6", "pass", "salt", "Timm", "Nielsen", "email", 22222222, 3));
                _context.User.Add(new User(8, "userstudent7", "pass", "salt", "Carl", "Dreslet", "email", 22222222, 3));
                _context.User.Add(new User(9, "userstudent8", "pass", "salt", "Jacob", "Madvig", "email", 22222222, 3));
                _context.User.Add(new User(10, "userstudent9", "pass", "salt", "Nikolai", "Hedegaard", "email", 22222222, 3));



                //classrooms
                _context.Classrooms.Add(new Classroom("Lokale A"));
                _context.Classrooms.Add(new Classroom("Lokale B"));


                //courses
                _context.Course.Add(new Course("Programmering", 1));
                _context.Course.Add(new Course("Systemudvikling", 2));
                _context.Course.Add(new Course("Technology", 3));

                //user courses
                _context.UserCourse.Add(new UserCourse(4, 1));
                _context.UserCourse.Add(new UserCourse(4, 2));
                _context.UserCourse.Add(new UserCourse(4, 3));

                _context.UserCourse.Add(new UserCourse(5, 1));
                _context.UserCourse.Add(new UserCourse(5, 2));
                _context.UserCourse.Add(new UserCourse(5, 3));

                _context.UserCourse.Add(new UserCourse(6, 1));
                _context.UserCourse.Add(new UserCourse(6, 2));
                _context.UserCourse.Add(new UserCourse(6, 3));

                _context.UserCourse.Add(new UserCourse(7, 1));
                _context.UserCourse.Add(new UserCourse(7, 2));
                _context.UserCourse.Add(new UserCourse(7, 3));

                _context.UserCourse.Add(new UserCourse(8, 1));
                _context.UserCourse.Add(new UserCourse(8, 2));
                _context.UserCourse.Add(new UserCourse(8, 3));

                _context.UserCourse.Add(new UserCourse(9, 1));
                _context.UserCourse.Add(new UserCourse(9, 2));
                _context.UserCourse.Add(new UserCourse(9, 3));

                _context.UserCourse.Add(new UserCourse(10, 1));
                _context.UserCourse.Add(new UserCourse(10, 2));
                _context.UserCourse.Add(new UserCourse(10, 3));

                _context.UserCourse.Add(new UserCourse(11, 1));
                _context.UserCourse.Add(new UserCourse(11, 2));
                _context.UserCourse.Add(new UserCourse(11, 3));

                _context.UserCourse.Add(new UserCourse(12, 1));
                _context.UserCourse.Add(new UserCourse(12, 2));
                _context.UserCourse.Add(new UserCourse(12, 3));

                _context.UserCourse.Add(new UserCourse(13, 1));
                _context.UserCourse.Add(new UserCourse(13, 2));
                _context.UserCourse.Add(new UserCourse(13, 3));

                //lessons som i skema
                //mandag
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 18, 9, 0, 0), 2, 1));
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 18, 10, 5, 0), 2, 1));
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 18, 10, 50, 0), 2, 1));
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 18, 12, 15, 0), 2, 1));


                //tirsdag
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 19, 9, 0, 0), 1, 1));
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 19, 10, 5, 0), 1, 1));
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 19, 10, 50, 0), 1, 1));
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 19, 12, 15, 0), 3, 2));
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 19, 13, 0, 0), 3, 2));
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 19, 14, 0, 0), 3, 2));


                //onsdag
                //-------------------------

                //torsdag
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 21, 9, 0, 0), 1, 1));
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 21, 10, 5, 0), 1, 1));
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 21, 10, 50, 0), 1, 1));
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 21, 12, 15, 0), 2, 1));
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 21, 13, 0, 0), 2, 1));
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 21, 14, 0, 0), 2, 1));

                //fredag
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 22, 9, 0, 0), 3, 2));
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 22, 10, 5, 0), 3, 2));
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 22, 10, 50, 0), 3, 2));
                _context.Lesson.Add(new Lesson(new DateTime(2020, 5, 22, 12, 15, 0), 3, 2));



                _context.SaveChanges();
            }
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
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

        // POST: api/User
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUser", new { id = user.Id }, user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
