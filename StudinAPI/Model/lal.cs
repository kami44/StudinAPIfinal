using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudinAPI.Model
{
    public class lal
    {

        public lal(int scannerkey, DateTime currentLessonTime)
        {
            Scannerkey = scannerkey;
            CurrentLessonTime = currentLessonTime;
        }
        public lal(){}
        public int Scannerkey { get; set; }
        public DateTime CurrentLessonTime { get; set; }
    }
}
