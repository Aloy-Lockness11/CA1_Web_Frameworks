using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CA1.utils
{
    internal class Validator
    {
        public static String validString(String message, String regex)
        {
            String input = "";
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter Value : ");
                input = Console.ReadLine();
                if (Regex.IsMatch(input, regex))
                {
                    isValid = true;
                }
                else
                {
                    GraphicsDisplay.DisplayErrorMessage(message);
                }
            }
            return input;
        }

        public static int validInt(int min, int max, String message)
        {
            int input = 0;
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter Value : ");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input >= min && input <= max)
                    {
                        isValid = true;
                    }
                    else
                    {
                        GraphicsDisplay.DisplayErrorMessage(message);
                    }
                }
                catch (Exception e)
                {
                   GraphicsDisplay.DisplayErrorMessage("Please enter a valid Integer");
                }
            }
            return input;
            
        }
        
        //returns valid index ID from race List
        public static int validIndexID(List<Race> raceList, String message)
        {
            int raceListIndex = -1;
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter Value : ");
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());

                    //find ID in event list 
                    bool found = false;
                    for (int i = 0; i < raceList.Count; i++)
                    {
                        if (raceList[i].EventID == input)
                        {
                            found = true;
                            raceListIndex = i;
                            isValid = true;
                        }
                    }


                    if (found)
                    {
                        isValid = true;
                    }
                    else
                    {
                        GraphicsDisplay.DisplayErrorMessage(message);
                    }
                }
                catch (Exception e)
                {
                    GraphicsDisplay.DisplayErrorMessage("Please enter a valid Integer");
                }
            }
            return raceListIndex;

        }

        //returns valid index ID from raceDayEvent List
        public static int validIndexID(List<RaceDayEvent> raceDayEventList, String message)
        {
            int raceDayEventListIndex = -1;
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter Value : ");
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());

                    //find ID in event list 
                    bool found = false;
                    for (int i = 0; i < raceDayEventList.Count; i++)
                    {
                        if (raceDayEventList[i].EventID == input)
                        {
                            found = true;
                            raceDayEventListIndex = i;
                            isValid = true;
                        }
                    }


                    if (found)
                    {
                        isValid = true;
                    }
                    else
                    {
                        GraphicsDisplay.DisplayErrorMessage(message);
                    }
                }
                catch (Exception e)
                {
                    GraphicsDisplay.DisplayErrorMessage("Please enter a valid Integer");
                }
            }
            return raceDayEventListIndex;

        }

        public static int validIndexID(List<Horse> horseList, String message)
        {
            int horseListIndex = -1;
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter Value : ");
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());

                    //find ID in event list 
                    bool found = false;
                    for (int i = 0; i < horseList.Count; i++)
                    {
                        if (horseList[i].HorseID == input)
                        {
                            found = true;
                            horseListIndex = i;
                            isValid = true;
                        }
                    }


                    if (found)
                    {
                        isValid = true;
                    }
                    else
                    {
                        GraphicsDisplay.DisplayErrorMessage(message);
                    }
                }
                catch (Exception e)
                {
                    GraphicsDisplay.DisplayErrorMessage("Please enter a valid Integer");
                }
            }
            return horseListIndex;

        }


        public static DateTime validDate(String message, String regex)
        {
            DateTime input = new DateTime();
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter Value : ");
                String date = Console.ReadLine();
                if (Regex.IsMatch(date, regex))
                {
                    input = DateTime.Parse(date);
                    isValid = true;
                }
                else
                {
                    GraphicsDisplay.DisplayErrorMessage(message);
                }
            }
            return input;
        }

        public static bool IsInHorseList(List<Horse> list, int horseID)
        {
            foreach (Horse horse in list)
            {
                if (horse.HorseID == horseID) 
                {
                    return true;
                }
            }
            return false; 
        }
    }
}
