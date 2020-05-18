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
        private int? _minutesLate;
        private static int idcounter = 1;

        //checking out
        public UserLesson( int fkusers, int fklessons, bool checkedout)
        {
            Id = idcounter;
            idcounter++;
            Fkusers = fkusers;
            Fklessons = fklessons;
            Checkedout = checkedout;
            MinutesStayed = null;
            MinutesLate = null;
  
        }
        //checking in
        public UserLesson(int fkusers, int fklessons, int? minutesLate)
        {
            Id = idcounter;
            idcounter++;
            Fkusers = fkusers;
            Fklessons = fklessons;
            Checkedout = false;
            MinutesStayed = null;
            MinutesLate = minutesLate;
        }
        //checking in
        public UserLesson(int fkusers, int fklessons)
        {
            Id = idcounter;
            idcounter++;
            Fkusers = fkusers;
            Fklessons = fklessons;
            Checkedout = false;
            MinutesStayed = null;
            MinutesLate = null;
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
        public int? MinutesLate
        {
            get { return _minutesLate; }
            set { _minutesLate = value; }
        }


    }
}
