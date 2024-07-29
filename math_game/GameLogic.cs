

using System.Data;

namespace MathGame
{
    internal class GameLogic
    {
        internal class GameOperationsTemplates
        {
            public static void GamePerformOperation(Func<int, int, int> operation, string operationSymbol, string operationKey, Dictionary<string, int> points)
            {
                int randomNumberA;
                int randomNumberB;
                int result;

                // Getting the numbers
                if (operationSymbol == "/")
                {
                    do
                    {
                        randomNumberB = GetRandomNumber(1, 101); // Divisor should not be zero
                        randomNumberA = GetRandomNumber(0, 101); // Dividend should be within 0 to 100
                    }
                    while (randomNumberA % randomNumberB != 0 || randomNumberA / randomNumberB > 100); // Ensure result is an integer and <= 100

                    result = randomNumberA / randomNumberB;
                }
                else
                {
                    randomNumberA = GetRandomNumber(0, 101);
                    randomNumberB = GetRandomNumber(0, 101);
                    result = operation(randomNumberA, randomNumberB);
                }

                string question = $"What is {randomNumberA} {operationSymbol} {randomNumberB} equal to?";
                // Display the question
                Console.WriteLine(question);

                // Get user input and check the answer
                int userAnswer;
                bool parseSuccess = int.TryParse(Console.ReadLine(), out userAnswer);

                if (!parseSuccess)
                {
                    Console.WriteLine("That's definitely wrong, it's not even a number.");
                    GameHistory.AddHistory(operationKey, question, "Invalid Answer", result);
                    return;
                }

                if (userAnswer == result)
                {
                    Console.WriteLine("That's correct");
                    points[operationKey]++;
                    GameHistory.AddHistory(operationKey, question, userAnswer.ToString(), result);
                }
                else
                {
                    Console.WriteLine($"That's wrong, correct answer is {result}");
                    GameHistory.AddHistory(operationKey, question, userAnswer.ToString(), result);
                }

                // Display current points for the game
                Console.WriteLine($"{operationKey} points: {points[operationKey]}");
            }

            private static readonly Random rnd = new Random();

            public static int GetRandomNumber(int min, int max)
            {
                return rnd.Next(min, max);
            }
        }
    }
}