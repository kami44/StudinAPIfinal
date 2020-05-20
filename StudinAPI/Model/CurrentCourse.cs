using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudinAPI.Model
{
    public class CurrentCourse
    {
        private int _id;
        private int _lessonId;
        private string _lessonStart;
        private string _lessonEnd;
        private string _courseName;

        public CurrentCourse(int id, int lessonid, string lessonStart, string lessonEnd, string coursename)
        {
            Id = id;
            LessonId = lessonid;
            LessonStart = lessonStart;
            LessonEnd = lessonEnd;
            CourseName = coursename;
            Students = new List<Student>();
        }
        public CurrentCourse(){}

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int LessonId 
        {
            get { return _lessonId; }
            set { _lessonId = value; }

        }
        public string LessonStart
        {
            get { return _lessonStart; }
            set { _lessonStart = value; }
        }
        public string LessonEnd
        {
            get { return _lessonEnd; }
            set { _lessonEnd = value; }
        }
        public string CourseName 
        {
            get { return _courseName; }
            set { _courseName = value; }
        }
        public List<Student> Students { get; set; }
    }
}
