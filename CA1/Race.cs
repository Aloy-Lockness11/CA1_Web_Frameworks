using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class Race:Event
    {
        private String locations;
        public List<string> horses;

        

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Location
        {
            get { return locations; }
            set { locations = value; }
        }

        public Race(string name, DateTime date, TimeOnly duration,String locations) : base(name, date, duration)
        {

        }

        public bool menu()
        {
            return false;
        }


    }
}
