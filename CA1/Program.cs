namespace CA1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RaceCourseManager raceCourseManager = new RaceCourseManager("manger1", "user@gmail.com", "manager1", "password1");
            HorseOwner horseOwner = new HorseOwner("Howner1", "user4@gmail.com", "Howner1", "password112");
            RaceGoer raceGoer = new RaceGoer("RaceGoer1", "user2@gmail.com", "RaceGoer1", "password2");



            int menuOption = 0;
            bool isExit = false;
            while (!isExit)
            {
                DisplayMenuOptions();

                Console.WriteLine("\n Enter Menu Choice");
                menuOption = utils.Validator.validInt(1, 4, "Please enter a valid menu option");
                switch (menuOption)
                {
                    case 1:
                        raceCourseManager.Menu();
                        break;
                    case 2:
                        horseOwner.Menu();
                        break;
                    case 3:
                        raceGoer.Menu();
                        break;
                    case 4:
                        utils.GraphicsDisplay.DisplayMessage("Goodbye");
                        isExit = true;
                        break;
                    default:
                        utils.GraphicsDisplay.DisplayErrorMessage("Please enter a valid menu option");
                        break;
                }
            }

        }
        public static void DisplayMenuOptions()
        {
            Console.WriteLine(
                "+=========================================+\n" +
                "|       Main Menu                         |\n" +
                "+=========================================+\n" +
                "|                                         |\n" +
                "|1.RaceCourse Manager                     |\n" +
                "|2.Horse Owner                            |\n" +
                "|3.Race Goer                              |\n" +
                "|4.Exit                                   |\n" +
                "|                                         |\n" +
                "+=========================================+"
            );

        }
    }
}
