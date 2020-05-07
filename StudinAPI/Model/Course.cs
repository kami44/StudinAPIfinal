using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudinAPI.Model
{
    public class Course
    {
        private int _id;
        private string _name;
        private int _fkusers;

        public Course(int id, string name, int fkusers)
        {
            Id = id;
            Name = name;
            Fkusers = fkusers;
        }

        public Course() { }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Fkusers
        {
            get { return _fkusers; }
            set { _fkusers = value; }
        }
    }
}
