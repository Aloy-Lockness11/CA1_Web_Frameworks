using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CA1
{
    internal abstract class Event
    {
        private int eventID;
        private string name;
        private DateTime date;
        private int duration;


        public Event(int eventID, string name, DateTime date,int duration)
        {
            this.eventID = eventID;
            this.duration = duration;
            this.name = name;
            this.date = date;        
        }
        public int EventID
        {
            get { return eventID; }
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

        //Duration In minutes

        public int Duration
        {
            get { return duration; }
            set { value = duration; }
        }
    }
}
