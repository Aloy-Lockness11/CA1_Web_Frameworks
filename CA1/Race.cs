using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CA1
{
    internal class Race:Event
    {
        private static int nxtRaceID = 0;
        private List<Horse> horses;

        public Race(string name, DateTime date, int duration) : base(nxtRaceID, name, date, duration)
        {
            nxtRaceID += 1;
        }
        public Race(DateTime date, int duration) : base(nxtRaceID, "Race"+nxtRaceID, date, duration)
        { 
            nxtRaceID += 1;
        }

        public bool menu()
        {
            return false;
        }


    }
}
