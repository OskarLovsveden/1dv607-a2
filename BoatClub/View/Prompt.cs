using System;
using System.Collections.Generic;

namespace View
{
    public class Prompt
    {
        public string PromptQuestion(string title, string conditionDescription, Func<string,bool> conditions)
        {
            string result;
            System.Console.WriteLine(title);
            do
            {
                System.Console.WriteLine(conditionDescription);
                result = Console.ReadLine();

            } while (conditions(result));

            return result;
        }

        public string PromptSelection(string title, List<string> options, Func<string,bool> conditions)
        {
            string userSelection;
            System.Console.WriteLine(title);
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
    }
}