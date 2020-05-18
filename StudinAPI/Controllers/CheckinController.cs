using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
            var studentQuery = _context.User.Where(u => u.Scannerkey == checkin.Scannerkey);

            if (studentQuery.Count() >= 0)
            {
                int studentId = studentQuery.Select(u => u.Id).FirstOrDefault();
                var query = _context.Course
                .Join(_context.UserCourse, x => x.Id, y => y.Fkcourses, (x, y) => new { course = x, usercourse = y })
                .Join(_context.Lesson, xy => xy.course.Id, z => z.Fkcourses, (xy, z) => new { xy, lesson = z })
                .Where(k => k.lesson.Fkclassrooms == checkin.Classroom && k.xy.usercourse.Fkusers == studentId)
                .Select(i=> i.lesson);


                List<Lesson> lessonlist = new List<Lesson>();

                int graceperiod = 10;
                int lessonlength = 45;

                int lateToLessonId = 0;
                int lateToLessonMinutes = 0;

                int earlyCheckoutLessonId = 0;
                int minutesStayed = 0;
                foreach(Lesson obj in query)
                {
                    //check if lesson is same date month and year as checkin
                    if (obj.Lessonstart.Date == checkin.CheckinTime.Date && obj.Lessonstart.Year == checkin.CheckinTime.Year && obj.Lessonstart.Month==checkin.CheckinTime.Month)
                    {
                        
                        if (checkin.CheckingIn)
                        {
                            DateTime comparetime = obj.Lessonstart.AddMinutes(lessonlength);
                            if ((comparetime.Hour >= checkin.CheckinTime.Hour && comparetime.Minute >= checkin.CheckinTime.Minute) || comparetime.Hour > checkin.CheckinTime.Hour) 
                            { 
                                //check if lesson is same or greater hour and minute than checkin
                                if ((obj.Lessonstart.Hour >= checkin.CheckinTime.Hour && obj.Lessonstart.Minute >= checkin.CheckinTime.Minute) || obj.Lessonstart.Hour > checkin.CheckinTime.Hour)
                                {
                                    lessonlist.Add(obj);
                                }
                                else
                                {
                                    lessonlist.Add(obj);
                                    lateToLessonId = obj.Id;
                                    lateToLessonMinutes = new DateTime(checkin.CheckinTime.Ticks - obj.Lessonstart.Ticks).Minute;

                                }
                            }
                        }
                        else
                        {
                            
                            
                            DateTime comparetime = obj.Lessonstart.AddMinutes((lessonlength-graceperiod));

                            if((obj.Lessonstart.Hour <= checkin.CheckinTime.Hour && obj.Lessonstart.Minute <= checkin.CheckinTime.Minute)||obj.Lessonstart.Hour<checkin.CheckinTime.Hour)
                            {
                                lessonlist.Add(obj);
                                if ((comparetime.Hour >= checkin.CheckinTime.Hour && comparetime.Minute >= checkin.CheckinTime.Minute)||comparetime.Hour>checkin.CheckinTime.Hour)
                                {
                                    earlyCheckoutLessonId = obj.Id;
                                    minutesStayed = new DateTime(checkin.CheckinTime.Ticks- obj.Lessonstart.Ticks).Minute;
                                }

                            }
                            
                        }

                    }
                }

                //checking in
                if (checkin.CheckingIn)
                {
                    lessonlist.OrderBy(x => x.Lessonstart.Ticks);

                    foreach (Lesson lesson in lessonlist)
                    {
                        if (lesson.Fkcourses == lessonlist[0].Fkcourses)
                        {
                            var userlessonquery = _context.UserLesson.Where(x => x.Fkusers == studentId).Where(y => y.Fklessons == lesson.Id).FirstOrDefault();
                            if (userlessonquery == null)
                            {
                                if (lateToLessonId == lesson.Id) _context.UserLesson.Add(new UserLesson(studentId, lesson.Id, lateToLessonMinutes));
                                else _context.UserLesson.Add(new UserLesson(studentId, lesson.Id));
                            }
                        }
                    }
                }
                //checking out
                else
                {
                    foreach (Lesson lesson in lessonlist)
                    {
                        var userlessonquery = _context.UserLesson.Where(x => x.Fkusers == studentId).Where(x => x.Fklessons == lesson.Id).Where(x => x.Checkedout == false).FirstOrDefault();
                        if (userlessonquery != null)
                        {
                            UserLesson dalesson = _context.UserLesson.Find(userlessonquery.Id);
                            dalesson.Checkedout = true;
                            if (earlyCheckoutLessonId == userlessonquery.Id) dalesson.MinutesStayed = minutesStayed;
                        }   
                    }
                }

                    


                

                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCheckin", new { id = checkin.Id }, checkin);


            }
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
