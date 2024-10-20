using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CA1
{
    internal abstract class Event
    {
        public string name;
        public DateTime date;
        public TimeOnly duration;


        public Event(string name, DateTime date,TimeOnly duration)
        {
            this.duration = duration;
            this.name = name;
            this.date = date;        
        }

        public string Name
            {
             get { return name; }
             set { value =  name; }
        }

        public DateTime Date
        {
            get { return date; }
            set { value = date; }
        }

        public TimeOnly Duration
        {
            get { return duration; }
            set { value = duration; }
        }
    }
}
