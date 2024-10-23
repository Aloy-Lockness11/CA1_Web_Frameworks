using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1.utils
{
    internal class GraphicsDisplay
    {
        public static void DisplayHorses(List<Horse> horses)
        {
            {
                Console.WriteLine("                                 Horses                                   ");
                Console.WriteLine("+========================================================================+");
                Console.WriteLine("| HorseID | Horse Name                     | Date Of Birth | Age         |");
                Console.WriteLine("+========================================================================+");

                foreach (Horse horse in horses)
                {
                    Console.WriteLine($"| {horse.HorseID,-7} | {horse.Name,-30} | {horse.DateOfBirth,-13} | {horse.Age,-3} yrs old |");
                }

                Console.WriteLine("+========================================================================+");
            }
        }

        public static void DisplayRaceDayEvents(List<RaceDayEvent> raceDays)
        {
            Console.WriteLine("                                   Race Days                                  ");
            Console.WriteLine("+============================================================================+");
            Console.WriteLine("| EventID | Event Name                     | Date                | Duration  |");
            Console.WriteLine("+============================================================================+");

            foreach (RaceDayEvent raceDayEvent in raceDays)
            {
                // Format the date "
                string formattedDate = raceDayEvent.Date.ToString("MM/dd/yyyy hh:mm tt");

                Console.WriteLine( $"| {raceDayEvent.EventID,-7} | {raceDayEvent.Name,-30} | {formattedDate,-19} | {raceDayEvent.Duration,-5} min |");
            }

            Console.WriteLine("+============================================================================+");
        }

        public static void DisplayRaces(List<Race> races)
        {
            Console.WriteLine("                                   Races                                      ");
            Console.WriteLine("+============================================================================+");
            Console.WriteLine("| RaceID  | Race Name                      | Date                | Duration  |");
            Console.WriteLine("+============================================================================+");

            foreach (Race race in races)
            {
                // Format the date t"
                string formattedDate = race.Date.ToString("MM/dd/yyyy hh:mm tt");

                
                Console.WriteLine($"| {race.EventID,-7} | {race.Name,-30} | {formattedDate,-19} | {race.Duration,-5} min |");
            }

            Console.WriteLine("+============================================================================+");
        }
    

    public static void DisplayMessage(string message)
        {
            Console.WriteLine(
                    "+--------------------------------------------+\n" +
                    $"{message}\n" +
                    "+--------------------------------------------+"
            );
        }

        public static void DisplayErrorMessage(string message)
        {
            Console.WriteLine(
                    "+============================================+\n" +
                    $"{message}\n" +
                    "+============================================+"
            );
        }



    }
}
