using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    public class GameHistory
    {
        public static DataTable HistoryTable { get ; set; }

        static GameHistory()
        {
            HistoryTable = new DataTable("GameHistory");

            HistoryTable.Columns.Add("Game", typeof(string));
            HistoryTable.Columns.Add("Question", typeof(string));
            HistoryTable.Columns.Add("User Answer", typeof(string));
            HistoryTable.Columns.Add("Correct Answer", typeof(int));

        }

        public static void AddHistory(string game, string question, string userAnswer, int correctAnswer)
        {
            DataRow row = HistoryTable.NewRow();
            row["Game"] = game;
            row["Question"] = question;
            row["User Answer"] = userAnswer;
            row["Correct Answer"] = correctAnswer;
            HistoryTable.Rows.Add(row);
        }

        public static void DisplayHistory()
        {
            Console.WriteLine("Game History:");
            foreach (DataRow row in HistoryTable.Rows)
            {
                Console.WriteLine($"{row["Game"]}, {row["Question"]}, User Answer: {row["User Answer"]}, Correct Answer: {row["Correct Answer"]}");
            }
        }

    }
}
