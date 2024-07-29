

namespace MathGame
{
    internal class MainMenu
    {

        public static string GetUserChoice()
        {
            string userInput = "";
            while (true)
            {
                Console.WriteLine("Type one of the letters to play.");
                userInput = Console.ReadLine()?.Trim().ToUpper();
                if (Array.Exists(ValidChoices, usersChoice => usersChoice == userInput))
                {
                    return userInput;
                }
                Console.WriteLine("Invalid Choice, type one of the letters.");
            }

        }


        // Display menu
        public static void DisplayMenu()
        {

            Console.WriteLine(MenuOptionsText.MenuHeader);
            Console.WriteLine("");
            Console.WriteLine(MenuOptionsText.Addition);
            Console.WriteLine(MenuOptionsText.Subtraction);
            Console.WriteLine(MenuOptionsText.Multiplication);
            Console.WriteLine(MenuOptionsText.Division);
            Console.WriteLine(MenuOptionsText.DisplayPoints);
            Console.WriteLine(MenuOptionsText.DisplayHistory);
            Console.WriteLine(MenuOptionsText.Quit);
        }


        //  Array of accepted user inputs
        private static readonly string[] ValidChoices = { "A", "S", "M", "D","P","H", "Q"};


        // Variables holding text of menu
        public static class MenuOptionsText
        {
            public const string MenuHeader = "Main Menu";
            public const string Addition = "A. Addition";
            public const string Subtraction = "S. Subtraction";
            public const string Multiplication = "M. Multiplication";
            public const string Division = "D. Division";
            public const string DisplayPoints = "P. Display Points";
            public const string DisplayHistory = "H. Display History";
            public const string Quit = "Q. Quit";
        }


    }
}
