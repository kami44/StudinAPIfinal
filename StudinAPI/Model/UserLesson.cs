using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace StudinAPI.Model
{
    public class UserLesson
    {
        private int _id;
        private int _fkusers;
        private int _fklessons;
        private bool _checkedout;
        private int? _minutesStayed;
        private static int idcounter = 1;


        public UserLesson( int fkusers, int fklessons, bool checkedout)
        {
            Id = idcounter;
            idcounter++;
            Fkusers = fkusers;
            Fklessons = fklessons;
            Checkedout = checkedout;
            MinutesStayed = null;
        }
        public UserLesson(int fkusers, int fklessons)
        {
            Id = idcounter;
            idcounter++;
            Fkusers = fkusers;
            Fklessons = fklessons;
            Checkedout = false;
            MinutesStayed = null;
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

        public bool Checkedout
        {
            get { return _checkedout; }
            set { _checkedout = value; }
        }
        public int? MinutesStayed
        {
            get { return _minutesStayed; }
            set { _minutesStayed = value; }
        }


    }
}
