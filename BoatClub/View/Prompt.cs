using System;
using System.Collections.Generic;

namespace View
{
    public class Prompt
    {
        public string PromptQuestion(string conditionDescription, Func<string, bool> conditions)
        {
            string result;
            do
            {
                System.Console.WriteLine(conditionDescription);
                result = Console.ReadLine();

            } while (conditions(result));

            return result;
        }

        public string PromptSelection(List<string> options, Func<string, bool> conditions)
        {
            string userSelection;
            foreach (string option in options)
            {
                System.Console.WriteLine(option);
            }
            do
            {
                userSelection = Console.ReadKey(true).KeyChar.ToString();
            } while (conditions(userSelection));

            return userSelection;
        }

        public void PromptShowTilClick(string data)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(data);

            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("\nPress any key to go back");

            Console.ResetColor();
            Console.ReadKey();
        }

        public void SetPromptMessage(string promptTitle, string currentPropertyValue = "")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(promptTitle);

            if (currentPropertyValue.Length != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($" ({currentPropertyValue})");
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.WriteLine(": ");
            Console.ResetColor();
        }
    }
}