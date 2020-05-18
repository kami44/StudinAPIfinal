using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudinAPI.Model
{
    public class Dummy
    {
        private int _id;
        private int _amount;
        private static int idcounter = 1;

        public Dummy(int amount)
        {
            _id = idcounter;
            idcounter++;
            _amount = amount;
        }
        public Dummy(){}
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
    }
}
