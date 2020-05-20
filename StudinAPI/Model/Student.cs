using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudinAPI.Model
{
    public class Student
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private bool _attendancy;

        public Student(int id, string firstName, string lastName, bool attendancy)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Attendancy = attendancy;
        }
        public Student(){}
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
        public bool Attendancy 
        {
            get { return _attendancy; }
            set { _attendancy = value; }
        }
    }
}
