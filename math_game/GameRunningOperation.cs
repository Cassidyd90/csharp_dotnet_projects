
using System.Net.Http.Headers;
using static MathGame.GameLogic;
using System.Data;

namespace MathGame
{
    internal class GameRunningOperations
    {

        private static Dictionary<string, int> points = new Dictionary<string, int>
        {
            {"Addition", 0 },
            {"Subtraction", 0 },
            {"Multiplication", 0 },
            {"Division", 0 }
        };

        public static void DisplayPoints()
        {
            foreach (var point in points)
            {
                Console.WriteLine($"{point.Key} score : {point.Value}");
            }
        }



        public static void GameRunOperation() 
        {
            string userChoice;          

            do
            {
                userChoice = MainMenu.GetUserChoice();

                switch (userChoice)
                {
                    case "A":
                        GameOperationsTemplates.GamePerformOperation((a, b) => a + b, "+", "Addition", points);
                        break;
                    case "S":
                        GameOperationsTemplates.GamePerformOperation((a, b) => a - b, "-", "Subtraction", points);
                        break;
                    case "M":
                        GameOperationsTemplates.GamePerformOperation((a, b) => a * b, "*", "Multiplication", points);
                        break;
                    case "D":
                        GameOperationsTemplates.GamePerformOperation((a, b) => a / b, "/", "Division", points);
                        break;
                    case "P":
                        DisplayPoints();
                        break;
                    case "H":
                        GameHistory.DisplayHistory();
                        break;
                    case "Q":
                        Console.WriteLine("Thanks for playing!");
                        break;
                }

            } while (userChoice != "Q");
            
        }
    }
}
