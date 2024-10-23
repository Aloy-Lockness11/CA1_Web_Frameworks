using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class RaceGoer : User
    {
        private static int nxtRaceGoerId = 1;
        public RaceGoer(string name, string email, string username, string password) : base(name, nxtRaceGoerId, email, username, password)
        {
            nxtRaceGoerId += 1;
        }

        public override void DisplayMenuOptions()
        {
            Console.WriteLine(
                "+===============================================+\n" +
                "|                Race Goer Menue                |\n" +
                "+===============================================+\n" +
                "|                                               |\n" +
                "|1.Display All Event Days                       |\n" +
                "|2.Display All Races on selected event          |\n" +
                "|3.Display All Horse on selected evwnt and Race |\n" +
                "|4.Exit                                         |\n" +
                "|                                               |\n" +
                "+===============================================+"
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
                menueOption = utils.Validator.validInt(1, 4, "Enter Right Menu Option Please");
                switch (menueOption)
                {
                    case 1:
                        DisplayAllEventDays();
                        break;
                    case 2:
                        DisplayAllRacesPresentOnSelectedDay();
                        break;
                    case 3:
                        DisplayAllHorsePresentOnASelectedDayAndRace();
                        break;
                    case 4:
                        isExist = true;
                        break;
                    default:
                        utils.GraphicsDisplay.DisplayErrorMessage("Enter Right Menu Option Please");
                        break;

                }
            }
            return false;
        }
    }
}
