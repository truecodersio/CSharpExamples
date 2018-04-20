using System;
using System.Linq;
using System.Collections.Generic;

namespace CSharpExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var iName = AskQuestionIteration("What is your name?");

            var rName = AskQuestionRecursion("What is your name?");
        }

        static string AskQuestionIteration(string question)
        {
            while (true)
            {
                Console.WriteLine(question);
                var response = Console.ReadLine();

                if (string.IsNullOrEmpty(response))
                {
                    Console.WriteLine("You need to answer our question");
                    continue;
                }

                return response;
            }
        }

        static string AskQuestionRecursion(string question)
        {
            Console.WriteLine(question);
            var response = Console.ReadLine();

            if (string.IsNullOrEmpty(response))
            {
                Console.WriteLine("You need to answer our question");
                return AskQuestionRecursion(question);
            }

            return response;
        }
    }
}
