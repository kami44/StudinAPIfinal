using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudinAPI.Model
{
    public class UserCourse
    {
        private int _id;
        private int _fkusers;
        private int _fkcourses;

        public UserCourse(int id, int fkusers, int fkcourses)
        {
            Id = id;
            Fkusers = fkusers;
            Fkcourses = fkcourses;
        }

        public UserCourse() { }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Fkusers
        {
            get { return _fkusers; }
            set { _fkusers = value; }
        }

        public int Fkcourses
        {
            get { return _fkcourses; }
            set { _fkcourses = value; }
        }
    }
}
