using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudinAPI.Model
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
           : base(options)
        {
           
        }

        public DbSet<User> User { get; set; }

        public DbSet<Lesson> Lesson { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<Classroom> Classrooms{ get; set; }

        public DbSet<UserCourse> UserCourse { get; set; }

        public DbSet<UserLesson> UserLesson { get; set; }

        public DbSet<Checkin> Checkin { get; set; }

        public DbSet<Dummy> Dummy { get; set; }
    }
}
