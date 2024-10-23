using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class RaceDayEvent : Event
    {
        private static int nextID = 1;
        private String location;
        private List<Race> races = new List<Race>();

        public String Location
        {
            get { return location; }
            set { location = value; }
        }
        public List<Race> Races
        {
            get { return races; }
        }
        public RaceDayEvent(string name, String Location, DateTime date, int duration) : base(nextID, name, date, duration)
        {
            this.Location = Location;
            nextID += 1;
        }

        public void displayRaces()
        {
            if (races.Count == 0)
            {
                utils.GraphicsDisplay.DisplayMessage("No Races");
            }
            else
            {
                utils.GraphicsDisplay.DisplayRaces(races);
            }
        }
        public void addRace(Race race)
        {
            this.races.Add(race);
        }

    }
}
