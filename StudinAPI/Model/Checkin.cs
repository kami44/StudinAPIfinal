using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudinAPI.Model
{
    public class Checkin
    {
        private int _id;
        private int _scannerkey;
        private int _classroom;
        private DateTime _checkinTime;

        public Checkin(int id, int scannerkey, int classroom, DateTime checkinTime)
        {
            _id = id;
            _scannerkey = scannerkey;
            _classroom = classroom;
            _checkinTime = checkinTime;
        }
        public Checkin() { }

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
        public int Classroom
        {
            get { return _classroom; }
            set { _classroom = value; }
        }
        public DateTime CheckinTime
        {
            get { return _checkinTime; }
            set { _checkinTime = value; }
        }
    }
}
