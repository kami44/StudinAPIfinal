using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudinAPI.Model
{
    public class Teacher
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private List<Course> _courses;
        private CurrentCourse _currentCourse;

        public Teacher(int id, string firstname, string lastname, CurrentCourse currentCourse)
        {
            _id = id;
            _firstName = firstname;
            _lastName = lastname;
            _courses = new List<Course>();
            _currentCourse = currentCourse;
        }
        public Teacher(){}

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public List<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }
        public CurrentCourse CurrentCourse
        {
            get { return _currentCourse; }
            set { _currentCourse = value; }
        }

    }
}
