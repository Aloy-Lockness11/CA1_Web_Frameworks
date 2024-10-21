using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA1.utils;

namespace CA1
{
    internal class RaceCourseManager : User
    {
        

        public RaceCourseManager(string name, string id, string email, string username, string password) : base(name, id, email, username, password)
        {

        }
        public override void DisplayMenuOptions()
        {
            Console.WriteLine("+=========================================+");
            Console.WriteLine("|       RaceCourse Manager Menu           |");
            Console.WriteLine("+=========================================+");
            Console.WriteLine("|                                         |");
            Console.WriteLine("|1.Create Race DAY Event                  |");
            Console.WriteLine("|2.Create Races for Selected Event        |");
            Console.WriteLine("|3.Display All Event Days                 |");
            Console.WriteLine("|4.Display Events on Selected Day         |");
            Console.WriteLine("|                                         |");
            Console.WriteLine("+=========================================+");
        }
        public override bool Menu()
        {
            int menueOption = 0;
            bool isExist = false;

            while (!isExist)
            {
                switch (menueOption)
                {
                    case 1:
                        createRaceDayEvent();
                        break;
                    case 2:
                        createRacesForSelectedEvent();
                        break;
                    case 3:
                        displayAllEventDays();
                        break;
                    case 4:
                        displayAllRacesPresentOnSelectedDay();
                        isExist = true;
                        break;
                    default:
                        Console.WriteLine("+===============================+");
                        Console.WriteLine("|Enter Right Menu Option Please |");
                        Console.WriteLine("+===============================+");
                        break;

                }
            }
            return false;
        }

        private void displayAllRacesPresentOnSelectedDay()
        {

            string message = "Please Select a Event by Event ID:";
            if (raceEventList.Count == 0)
            {
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("No Event Days Available");
                Console.WriteLine("+--------------------------------------------+");
            }
            else
            {
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine(message);
                int eventID = utils.Validator.validInt(0, raceEventList.Count, $"Error :{message} And try Again !!");
                RaceEventList[eventID].displayRaces();
            }
        }

        private void displayAllEventDays()
        {
            DisplayAllEventDays();
        }

        private void createRacesForSelectedEvent()
        {
            int durationMin = 15;
            int durationMax = 61;
            Race race;
            string message = "Please Select a Event by Event ID:";
            string messageNameInput = "Please Enter a Name With Alphabets only 30 characters :";
            string messageDateInput = "Please Enter a Date and Time in the format dd/mm/yyyy hh:ss :";
            string messageDurationInput = $"Please Enter a Duration in minutes between {durationMin} and {durationMax} :";
            if (raceEventList.Count == 0)
            {
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine("No Event Days Available");
                Console.WriteLine("+--------------------------------------------+");
            }
            else
            {
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine(message);
                int eventID = utils.Validator.validInt(0, raceEventList.Count, $"Error :{message} And try Again !!");
                while (true)
                {
                    try
                    {
                        Console.WriteLine(messageNameInput);
                        string name = utils.Validator.validString("error:" + messageNameInput + " and try again!! ", @"^[a-zA-Z]{1,30}$");
                        Console.WriteLine(messageDateInput);
                        DateTime date = utils.Validator.validDate("error:" + messageDateInput + " and try again!! ", @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/([0-9]{4}) ([01][0-9]|2[0-3]):([0-5][0-9])$");
                        Console.WriteLine(messageDurationInput);
                        int duration = utils.Validator.validInt(durationMin, durationMax, "error:" + messageDurationInput + " and try again!! ");
                        if (name.Length == 0)
                        {
                            race = new Race(date, duration);
                        }
                        else
                        {
                            race = new Race(name, date, duration);
                        }
                        RaceEventList[eventID].addRace(race);
                        Console.WriteLine("==============================================");
                        Console.WriteLine("Race Created and Added to Event Successfully");
                        Console.WriteLine("==============================================");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("==============================================");
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Error Occured while Creating and adding race to event Try again Please");
                        Console.WriteLine("==============================================");
                    }

                }
            }
        }

        private bool createRaceDayEvent()
        {
            int durationMin = 15;
            int durationMax = 360;
            string messageNameInput = "Please Enter a Name With Alphabets only 30 characters :";
            string messageLocationInput = "Please Enter location in eir Code format :";
            string messageDateInput = "Please Enter a Date and Time in the format dd/mm/yyyy hh:ss :";
            string messageDurationInput = $"Please Enter a Duration in minutes between {durationMin} and {durationMax} :";
            bool isValid = false;
            while (!isValid)
            {
                try
                {
                    Console.WriteLine("+---------------------------------------------------------------+");
                    Console.WriteLine(messageNameInput);
                    string name = utils.Validator.validString("error:"+ messageNameInput +" and try again!! ", @"^[a-zA-Z]{1,30}$");
                    Console.WriteLine(messageLocationInput);
                    string location = utils.Validator.validString("error:" + messageLocationInput + " and try again!! ", @"^[A-Za-z0-9]{3} [A-Za-z0-9]{4}$");
                    Console.WriteLine(messageDateInput);
                    DateTime date = utils.Validator.validDate("error:" + messageDateInput + " and try again!! ", @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/([0-9]{4}) ([01][0-9]|2[0-3]):([0-5][0-9])$");
                    Console.WriteLine(messageDurationInput);
                    int duration = utils.Validator.validInt(durationMin,durationMax,"error:" + messageDurationInput + " and try again!! ");
                    RaceDayEvent raceDayEvent = new RaceDayEvent(name, location, date, duration);
                    AddRace(raceDayEvent);
                    Console.WriteLine("==============================================");
                    Console.WriteLine("race event created successfully");
                    Console.WriteLine("==============================================");
                    isValid = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("==============================================");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Error Occured while Creating and Adding Race event Try again Please");
                    Console.WriteLine("==============================================");
                }


            }
            return isValid;
        }



        
    }

}  

