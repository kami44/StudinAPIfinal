using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudinAPI.Model
{
    public class Classroom
    {
        private int _id;
        private string _name;

        public Classroom(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Classroom() { }

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
    }
}
