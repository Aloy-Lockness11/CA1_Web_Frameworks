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
        private static int nxtRaceCourseManagerID = 0;

        public RaceCourseManager(string name, string email, string username, string password) : base(name, nxtRaceCourseManagerID, email, username, password)
        {
            nxtRaceCourseManagerID += 1;
        }
        public override void DisplayMenuOptions()
        {
            Console.WriteLine(
                "+=========================================+\n" +
                "|         RaceCourse Manager Menu         |\n" +
                "+=========================================+\n" +
                "|                                         |\n" +
                "|1.Create Race DAY Event                  |\n" +
                "|2.Create Races for Selected Event        |\n" +
                "|3.Display All Event Days                 |\n" +
                "|4.Display Events on Selected Day         |\n" +
                "|5.Add Test Data                          |\n" +
                "|6.Exit                                   |\n" +
                "|                                         |\n" +
                "+=========================================+"
            );
        }
        public override bool Menu()
        {
            int menueOption = 0;
            bool isExist = false;

            while (!isExist)
            {
                DisplayMenuOptions();

                Console.WriteLine("\n Enter Menu Choice");
                menueOption = utils.Validator.validInt(1, 6, "Enter Right Menu Option Please");
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
                        DisplayAllRacesPresentOnSelectedDay();
                        break;
                    case 5:
                        addTestData();
                        break;
                    case 6:
                        isExist = true;
                        break;
                    default:
                        utils.GraphicsDisplay.DisplayErrorMessage("Enter Right Menu Option Please");
                        break;

                }
            }
            return false;
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
            string message = "Please Select a Event by Event ID (Should exist in Events):";
            string messageNameInput = "Please Enter a Name With Alphabets only 30 characters or leave empty to Default :";
            string messageDateInput = "Please Enter a Date and Time in the format dd/mm/yyyy hh:ss :";
            string messageDurationInput = $"Please Enter a Duration in minutes between {durationMin} and {durationMax} :";
            if (raceEventList.Count == 0)
            {
                utils.GraphicsDisplay.DisplayErrorMessage("No Event Days Available");
            }
            else
            {
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine(message);
                int eventListIndex = utils.Validator.validIndexID(RaceEventList, "error:" + message + " and try again!! ");
                bool isValid = false;
                while (!isValid)
                {
                    try
                    {
                        Console.WriteLine("+--------------------------------------------+");
                        Console.WriteLine(messageNameInput);
                        string name = utils.Validator.validString("error:" + messageNameInput + " and try again!! ", @"^[a-zA-Z\s]{0,30}$");
                        Console.WriteLine("+--------------------------------------------+");
                        Console.WriteLine(messageDateInput);
                        DateTime date = utils.Validator.validDate("error:" + messageDateInput + " and try again!! ", @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/([0-9]{4}) ([01][0-9]|2[0-3]):([0-5][0-9])$");
                        Console.WriteLine("+--------------------------------------------+");
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
                        RaceEventList[eventListIndex].addRace(race);
                        utils.GraphicsDisplay.DisplayMessage("Race Created Successfully");
                        isValid = true;
                    }
                    catch (Exception e)
                    {
                        utils.GraphicsDisplay.DisplayErrorMessage(
                            $"{e.Message}\n" +
                            "Error Occurred while Creating and Adding Race. Try again please.\n" 
                            );
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
            string messageDateInput = "Please Enter a Date and Time in the format dd/mm/yyyy hh:mm :";
            string messageDurationInput = $"Please Enter a Duration in minutes between {durationMin} and {durationMax} :";
            bool isValid = false;
            while (!isValid)
            {
                try
                {
                    Console.WriteLine("+---------------------------------------------------------------+");
                    Console.WriteLine(messageNameInput);
                    string name = utils.Validator.validString("error:"+ messageNameInput +" And try again!! ", @"^[a-zA-Z\s]{1,30}$");
                    Console.WriteLine("+--------------------------------------------+");
                    Console.WriteLine(messageLocationInput);
                    string location = utils.Validator.validString("error:" + messageLocationInput + " And try again!! ", @"^[A-Za-z0-9]{3} [A-Za-z0-9]{4}$");
                    Console.WriteLine("+--------------------------------------------+");
                    Console.WriteLine(messageDateInput);
                    DateTime date = utils.Validator.validDate("error:" + messageDateInput + " And try again!! ", @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/([0-9]{4}) ([01][0-9]|2[0-3]):([0-5][0-9])$");
                    Console.WriteLine("+--------------------------------------------+");
                    Console.WriteLine(messageDurationInput);
                    int duration = utils.Validator.validInt(durationMin,durationMax,"error:" + messageDurationInput + " and try again!! ");
                    RaceDayEvent raceDayEvent = new RaceDayEvent(name, location, date, duration);
                    AddRace(raceDayEvent);

                    utils.GraphicsDisplay.DisplayMessage(name + " Event Created Successfully");

                    isValid = true;
                }
                catch (Exception e)
                {
                    utils.GraphicsDisplay.DisplayErrorMessage(
                        $"{e.Message}\n" +
                        "Error Occurred while Creating and Adding Event. Try again please.\n"
                    );
                }


            }
            return isValid;
        }



        
    }

}  

