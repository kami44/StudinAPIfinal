using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudinAPI.Model
{
    public class lol
    {
        public lol(int teacherId, DateTime currentLessonTime)
        {
            TeacherId = teacherId;
            CurrentLessonTime = currentLessonTime;
        }
        public lol()
        {
                
        }
        public int TeacherId { get; set; }
        public DateTime CurrentLessonTime { get; set; }
    }
}
