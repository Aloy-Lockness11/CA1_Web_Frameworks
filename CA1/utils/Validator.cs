using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
                Console.WriteLine(message);
                input = Console.ReadLine();
                if (Regex.IsMatch(input, regex))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("+=======================================+");
                    Console.WriteLine($"{message}");
                    Console.WriteLine("+=======================================+");
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
                Console.WriteLine(message);
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input >= min && input <= max)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("+=================================================+");
                        Console.WriteLine($"|Please enter a number within Range:{min} to {max}|");
                        Console.WriteLine("+=================================================+");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("+==========================================+");
                    Console.WriteLine($"{message}");
                    Console.WriteLine("+==========================================+");
                }
            }
            return input;
            
            
            
        }

        
        public static DateTime validDate(String message, String regex)
        {
            DateTime input = new DateTime();
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine(message);
                String date = Console.ReadLine();
                if (Regex.IsMatch(date, regex))
                {
                    input = DateTime.Parse(date);
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("+=======================================+");
                    Console.WriteLine($"{message}");
                    Console.WriteLine("+=======================================+");
                }
            }
            return input;
        }

    }
}
