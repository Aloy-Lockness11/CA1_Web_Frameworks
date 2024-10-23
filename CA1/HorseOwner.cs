using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class HorseOwner:User
    {
        private List<Horse> ownedhorses;
        private static int nxtOwnerID = 1;
        public List<Horse> Horses
        {
            get { return ownedhorses; }
        }

        public HorseOwner(string name, string email, string username, string password) : base(name, nxtOwnerID, email, username, password)
        {
            nxtOwnerID += 1;
            ownedhorses = new List<Horse>();
        }

        public void addOwnedhorses(Horse horse)
        {
            ownedhorses.Add(horse);
        }

        public void removeOwnedhorses(Horse horse)
        {
            ownedhorses.Remove(horse);
        }
        public override void DisplayMenuOptions()
        {
            Console.WriteLine("+=============================================+");
            Console.WriteLine("|              Horse Owner Menu               |");
            Console.WriteLine("+=============================================+");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|1.Create New Owned Horse                     |");
            Console.WriteLine("|2.Add Horse to Selected Race By ID           |");
            Console.WriteLine("|3.Display All Event Days                     |");
            Console.WriteLine("|4.Display All Races  on Selected Day         |");
            Console.WriteLine("|5.Display All Horse on Selected Day and Race |");
            Console.WriteLine("|6.Display Owned Horses                       |");
            Console.WriteLine("|7.Exit                                       |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("+=============================================+"); 

        }
        public override bool Menu()
        {
            int menueOption = 0;
            bool isExist = false;

            while (!isExist)
            {
                DisplayMenuOptions();

                Console.WriteLine("\n Enter Menu Choice");
                menueOption = utils.Validator.validInt(1, 7, "Enter Right Menu Option Please");

                switch (menueOption)
                {
                    case 1:
                        createNewOwnedHorse();
                        break;
                    case 2:
                        addHorseToSelectedRaceByID();
                        break;
                    case 3:
                        DisplayAllEventDays();
                        break;
                    case 4:
                        DisplayAllRacesPresentOnSelectedDay();
                        break;
                    case 5:
                        DisplayAllHorsePresentOnASelectedDayAndRace();
                        break;
                    case 6:
                        DisplayOwnedHorses();
                        break;
                    case 7:
                        isExist = true;
                        break;
                    default:
                        utils.GraphicsDisplay.DisplayErrorMessage("Enter Right Menu Option Please");
                        break;

                }
            }
            return false;

        }

        private void DisplayOwnedHorses()
        {
            if (ownedhorses.Count == 0)
            {
                utils.GraphicsDisplay.DisplayErrorMessage("No horses Owned");
            }
            else
            {
                utils.GraphicsDisplay.DisplayHorses(ownedhorses);
            }
            
        }

        private void addHorseToSelectedRaceByID()
        {
            string messageHorse = "Please Select a Existing Horse by Horse ID:";
            string messageEvent = "Please Select an Event by Event ID that Exisits:";
            string messageRace = "Please Select a Race by Race ID that Exisits";

            if (raceEventList.Count == 0)
            {
                utils.GraphicsDisplay.DisplayErrorMessage("No Event Days Available");
            }

            else if (ownedhorses.Count == 0)
            {
                utils.GraphicsDisplay.DisplayErrorMessage("No Horses owned");
            }
            else
            {
                Console.WriteLine("+--------------------------------------------+");
                Console.WriteLine(messageEvent);
                int eventIndexID = utils.Validator.validIndexID(raceEventList, $"Error :{messageEvent} And try Again !!");
                if (raceEventList[eventIndexID].Races.Count == 0)
                {
                    utils.GraphicsDisplay.DisplayErrorMessage("No Races Available");
                }
                else
                {
                    Console.WriteLine("+--------------------------------------------+");
                    Console.WriteLine(messageRace);
                    int raceIndexID = utils.Validator.validIndexID(raceEventList[eventIndexID].Races, $"Error :{messageRace} And try Again !!");
                    Console.WriteLine("+--------------------------------------------+");
                    Console.WriteLine(messageHorse);
                    int HorseIndexID = utils.Validator.validIndexID(ownedhorses, $"Error :{messageHorse} And try Again !!");
                    //checks for if the owner has the horse and if has already put the horse
                    //in the race
                    if (utils.Validator.IsInHorseList(raceEventList[eventIndexID].Races[raceIndexID].Horses, HorseIndexID))
                    {
                        utils.GraphicsDisplay.DisplayErrorMessage("Error: Horse Already Added to race");
                    }
                    else
                    {
                        raceEventList[eventIndexID].Races[raceIndexID].Horses.Add(ownedhorses[HorseIndexID]);
                        utils.GraphicsDisplay.DisplayMessage($"Horse Added successfully to Race");
                    }
                    
                    
                    
                }
            }
        }

        private bool createNewOwnedHorse()
        {
            String messageName = "Please Enter Horse Name, cannot Be More than 10 Chars:";
            String messageDOB = "Please Enter Horse Date of Birth in the format dd/mm/yyyy:";
            String messageAge = "Please Enter Horse Age between 0 and 40:";

            bool isValid = false;
            while (!isValid)
            {
                try
                {
                    Console.WriteLine("+---------------------------------------------------------------+");
                    Console.WriteLine(messageName);
                    string name = utils.Validator.validString("error:" + messageName + " And try again!! ", @"^[a-zA-Z\s]{1,30}$");
                    Console.WriteLine("+--------------------------------------------+");
                    Console.WriteLine(messageDOB);
                    string dob = utils.Validator.validString("error:" + messageDOB + " And try again!! ", @"^([0-2][0-9]|3[0-1])/(0[0-9]|1[0-2])/[0-9]{4}$");
                    Console.WriteLine("+--------------------------------------------+");
                    Console.WriteLine(messageAge);
                    int age = utils.Validator.validInt(0, 40, "error:" + messageAge + " And try again!! ");
                    Horse horse = new Horse(name, dob, age);
                    addOwnedhorses(horse);
                    utils.GraphicsDisplay.DisplayMessage("Horse Created Successfully");
                    isValid = true;
                }
                catch
                (Exception e)
                {
                    utils.GraphicsDisplay.DisplayErrorMessage(
                        $"{e.Message}\n" +
                        "Error Occurred while Creating and Adding Horse. Try again please.\n"
                        );
                }
            }
            return isValid;
        }
    }
}
    
