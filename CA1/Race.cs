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
        private static int nxtRaceID = 1;
        private List<Horse> horses;

        public List<Horse> Horses
        {
            get { return horses; }
        }

        public Race(string name, DateTime date, int duration) : base(nxtRaceID, name, date, duration)
        {
            horses = new List<Horse>();
            nxtRaceID += 1;
        }
        public Race(DateTime date, int duration) : base(nxtRaceID, "Race"+nxtRaceID, date, duration)
        {
            horses = new List<Horse>();
            nxtRaceID += 1;
        }
        public void addHorse(Horse horse)
        {
            horses.Add(horse);
        }
        public void removeHorse(Horse horse)
        {
            horses.Remove(horse);
        }
        public void displayHorses()
        {
            if (horses.Count == 0)
            {
                utils.GraphicsDisplay.DisplayMessage("No Horses");
            }
            else
            {
                utils.GraphicsDisplay.DisplayHorses(horses);
            }
        }


    }
}
