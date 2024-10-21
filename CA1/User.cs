﻿using System;
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
        private String name;
        private String id;
        private String email;
        private String username;
        private String password;

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

        public String Id
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


        protected User(string name, string id, string email, string username, string password)
        {
            this.name = name;
            this.id = id;
            this.email = email;
            this.username = username;
            this.password = password;
        }

        public static bool AddRace(RaceDayEvent raceDayEvent)
        {
            if(raceDayEvent != null)
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

        public static RaceDayEvent FindRace(int raceID)
        {
            foreach (RaceDayEvent raceDayEvent in raceEventList)
            {
                if (raceDayEvent.EventID == raceID)
                {
                    return raceDayEvent;
                }
            }
            return null;
        }

        public static void DisplayAllEventDays()
        {
            if(raceEventList.Count == 0)
            {
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("No Events Available");
                Console.WriteLine("+--------------------------------------------+");
            }
            else
            {
                foreach (Event raceDayEvent in raceEventList)
                {
                    Console.WriteLine("+--------------------------------------------+");
                    Console.WriteLine($"{raceDayEvent.EventID} | {raceDayEvent.Name} | {raceDayEvent.Date} | {raceDayEvent.Duration}");
                    Console.WriteLine("+--------------------------------------------+");
                }
            }
            
        }

        public abstract bool Menu();
        public abstract void DisplayMenuOptions();
    }
}
