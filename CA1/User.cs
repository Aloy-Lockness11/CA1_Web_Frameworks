using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal abstract class User
    {
        private static int HORSE_OWNER_CREATE_KEY = 11002;
        private static int MANAGER_CREATE_KEY = 11001;

        public static List<RaceDayEvent> raceEventList = new List<RaceDayEvent>();
        protected String name;
        protected int id;
        protected String email;
        protected String username;
        protected String password;

        public static List<RaceDayEvent> RaceEventList
        {
            get { return raceEventList; }
        }
        public String Username
        {
            get { return username; }
            set { username = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }


        protected User(string name, int id, string email, string username, string password)

        {
            this.name = name;
            this.id = id;
            this.email = email;
            this.username = username;
            this.password = password;
        }

        public static bool AddRace(RaceDayEvent raceDayEvent)
        {
            if (raceDayEvent != null)
            {
                raceEventList.Add(raceDayEvent);
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool RemoveRace(RaceDayEvent raceDayEvent)
        {
            if (raceDayEvent != null)
            {
                raceEventList.Remove(raceDayEvent);
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void DisplayAllEventDays()
        {
            if (raceEventList.Count == 0)
            {
                utils.GraphicsDisplay.DisplayMessage("No Event Days Available");
            }
            else
            {
                utils.GraphicsDisplay.DisplayRaceDayEvents(raceEventList);
            }

        }
        public static void DisplayAllRacesPresentOnSelectedDay()
        {
            string message = "Please Select a Event by Event ID:";
            if (raceEventList.Count == 0)
            {
                utils.GraphicsDisplay.DisplayMessage("No Event Days Available");
            }
            else
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(message);
                int eventIndexID = utils.Validator.validIndexID(raceEventList, $"Error :{message} And try Again !!");
                RaceEventList[eventIndexID].displayRaces();
            }
        }

        public static void DisplayAllHorsePresentOnASelectedDayAndRace()
        {
            string messageEvent = "Please Select an Event by Event ID that Exisits:";
            string messageRace = "Please Select a Race by Race ID that Exisits";
            if (raceEventList.Count == 0)
            {
                utils.GraphicsDisplay.DisplayMessage("No Event Days Available");
            }
            else
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(messageEvent);
                int eventIndexID = utils.Validator.validIndexID(raceEventList, $"Error :{messageEvent} And try Again !!");
                if (raceEventList[eventIndexID].Races.Count == 0)
                {
                    utils.GraphicsDisplay.DisplayMessage("Races not found");
                }
                else
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine(messageRace);
                    int raceIndexID = utils.Validator.validIndexID(raceEventList[eventIndexID].Races, $"Error :{messageRace} And try Again !!");
                    raceEventList[eventIndexID].Races[raceIndexID].displayHorses();
                }
            }

        }

        public void addTestData()
        {
            // Correct DateTime format and parsing
            string dateFormat = "dd/MM/yyyy HH:mm";

            // Adding race events
            raceEventList.Add(new RaceDayEvent("Grand Schichal Race", "A91 DAWF", DateTime.ParseExact("30/10/2024 07:30", dateFormat, null), 30));
            raceEventList.Add(new RaceDayEvent("Northern Hills Marathon", "B23 FST", DateTime.ParseExact("01/11/2024 08:00", dateFormat, null), 42));
            raceEventList.Add(new RaceDayEvent("Sunset Valley Sprint", "C87 HJK", DateTime.ParseExact("05/11/2024 16:00", dateFormat, null), 10));

            // Adding races to the first event (Grand Schichal Race)
            raceEventList[0].addRace(new Race("Kianas Turns", DateTime.ParseExact("30/10/2024 07:30", dateFormat, null), 30));
            raceEventList[0].addRace(new Race(DateTime.ParseExact("30/10/2024 08:00", dateFormat, null), 30));
            raceEventList[0].addRace(new Race(DateTime.ParseExact("30/10/2024 08:30", dateFormat, null), 30));

            // Adding races to the second event (Northern Hills Marathon)
            raceEventList[1].addRace(new Race("Marathon Start", DateTime.ParseExact("01/11/2024 08:00", dateFormat, null), 42));
            raceEventList[1].addRace(new Race("Midway Point", DateTime.ParseExact("01/11/2024 09:30", dateFormat, null), 21));
            raceEventList[1].addRace(new Race("Final Stretch", DateTime.ParseExact("01/11/2024 10:30", dateFormat, null), 42));

            // Adding races to the third event (Sunset Valley Sprint)
            raceEventList[2].addRace(new Race("Sprint Heat 1", DateTime.ParseExact("05/11/2024 16:00", dateFormat, null), 10));
            raceEventList[2].addRace(new Race("Sprint Heat 2", DateTime.ParseExact("05/11/2024 16:30", dateFormat, null), 10));
            raceEventList[2].addRace(new Race("Sprint Finals", DateTime.ParseExact("05/11/2024 17:00", dateFormat, null), 10));


            // Adding horses to the races of the first event (Grand Schichal Race)
            raceEventList[0].Races[0].addHorse(new Horse("Mei", "12/05/1999", 25));
            raceEventList[0].Races[0].addHorse(new Horse("Kiana", "12/05/1999", 25));
            raceEventList[0].Races[1].addHorse(new Horse("Bronya", "10/06/2000", 22));
            raceEventList[0].Races[1].addHorse(new Horse("Himeko", "03/11/1998", 28));
            raceEventList[0].Races[2].addHorse(new Horse("Theresa", "05/07/2001", 20));

            // Adding horses to the races of the second event (Northern Hills Marathon)
            raceEventList[1].Races[0].addHorse(new Horse("Raiden", "15/08/1997", 27));
            raceEventList[1].Races[0].addHorse(new Horse("Fu Hua", "19/09/1996", 29));
            raceEventList[1].Races[1].addHorse(new Horse("Yae Sakura", "08/10/2000", 23));
            raceEventList[1].Races[1].addHorse(new Horse("Mobius", "28/04/1998", 26));
            raceEventList[1].Races[2].addHorse(new Horse("Elysia", "15/03/1999", 25));

            // Adding horses to the races of the third event (Sunset Valley Sprint)
            raceEventList[2].Races[0].addHorse(new Horse("Aponia", "12/12/1995", 28));
            raceEventList[2].Races[0].addHorse(new Horse("Kosma", "24/01/1998", 26));
            raceEventList[2].Races[1].addHorse(new Horse("Griseo", "11/11/2001", 22));
            raceEventList[2].Races[1].addHorse(new Horse("Kalpas", "18/06/1999", 25));
            raceEventList[2].Races[2].addHorse(new Horse("Eden", "04/02/1997", 27));

            utils.GraphicsDisplay.DisplayMessage("Test Data Loaded Successfuly");
        }


        public abstract bool Menu();
        public abstract void DisplayMenuOptions();

    }
}
