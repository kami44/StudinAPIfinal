using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudinAPI.Model
{
    public class FrontendStudent
    {
        private int _id;
        private int _scannerkey;
        private string _firstName;
        private string _lastName;
        private CurrentCourse _currentCourse;
        private List<Course> _courses;

        public FrontendStudent(int id, int scannerkey, string firstname, string lastname, CurrentCourse currentCourse)
        {
            Id = id;
            Scannerkey = scannerkey;
            FirstName = firstname;
            LastName = lastname;
            CurrentCourse = currentCourse;
            Courses = new List<Course>();

        }
        public FrontendStudent(){}
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Scannerkey
        {
            get { return _scannerkey; }
            set { _scannerkey = value; }
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
        public CurrentCourse CurrentCourse
        {
            get { return _currentCourse; }
            set { _currentCourse = value; }
        }
        public List<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }
    }
}
