using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class RaceDayEvent:Event
    {
        private List<Race> races;

        public RaceDayEvent(string name, DateTime date,TimeOnly duration) : base(name, date, duration)
        {
        }

        
    }
}
