using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudinAPI.Model
{
    public class UserLesson
    {
        private int _id;
        private int _fkusers;
        private int _fklessons;


        public UserLesson(int id, int fkusers, int fklessons)
        {
            Id = id;
            Fkusers = fkusers;
            Fklessons = fklessons;
        }

        public UserLesson() { }

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

        public int Fklessons
        {
            get { return _fklessons; }
            set { _fklessons = value; }
        }
    }
}
