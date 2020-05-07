using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudinAPI.Model
{
    public class Lesson
    {
        private int _id;
        private DateTime _lessonstart;
        private int _fkcourses;
        private int _fkclassrooms;

        public Lesson(int id, DateTime lessonstart, int fkcourses, int fkclassrooms)
        {
            Id = id;
            Lessonstart = lessonstart;
            Fkcourses = fkcourses;
            Fkclassrooms = fkclassrooms;
        }
        public Lesson() { }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime Lessonstart
        {
            get { return _lessonstart; }
            set { _lessonstart = value; }
        }

        public int Fkcourses
        {
            get { return _fkcourses; }
            set { _fkcourses = value; }
        }

        public int Fkclassrooms
        {
            get { return _fkclassrooms; }
            set { _fkclassrooms = value; }
        }
    }
}
