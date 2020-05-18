using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudinAPI.Model
{
    public class StudentClass
    {
        private int _id;
        private string _name;
        private int _fkcourses;
        private static int idcounter;

        public StudentClass(string name, int fkcourses)
        {
            _id = idcounter;
            idcounter++;
            _name = name;
            _fkcourses = fkcourses;
        }
        public StudentClass(){}

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
        public int Fkcourses
        {
            get { return _fkcourses; }
            set { _fkcourses = value; }
        }
    }
}
