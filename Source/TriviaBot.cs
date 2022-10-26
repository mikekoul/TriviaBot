using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewTest
{
    internal sealed class TriviaBot
    {
        private Dictionary<int, TriviaData> questionsAndAnswers = new Dictionary<int, TriviaData>();

        public void Run(int numQuestions)
        {
            DisplayHeader();
            GetQuestionsAndAnswers(numQuestions);
            RateTheTrivia();
            SaveTrivia();
        }

        public void DisplayHeader()
        {
            Console.WriteLine(@"   _____  ____  _  _     _  ____    ____  ____  _____   _____  ____  ____  ____    ");
            Console.WriteLine(@"  /__ __\/  __\/ \/ \ |\/ \/  _ \  /  __\/  _ \/__ __\  \__  \/  _ \/  _ \/  _ \   ");
            Console.WriteLine(@"    / \  |  \/|| || | //| || / \|  | | //| / \|  / \      /  || / \|| / \|| / \|   ");
            Console.WriteLine(@"    | |  |    /| || \// | || |-||  | |_\\| \_/|  | |     _\  || \_/|| \_/|| \_/|   ");
            Console.WriteLine(@"\\  \_/  \_/\_\\_/\__/  \_/\_/ \|  \____/\____/  \_/    /____/\____/\____/\____/ //");
            Console.WriteLine(@" \\-----------------------------------------------------------------------------//"); Console.WriteLine("\n> Welcome to the Ensurem Trivia Bot 3000! The only trivia game where you provide both the question and answer.");
        }

        public void GetQuestionsAndAnswers(int numQuestions)
        {
            Console.WriteLine($"\n> Please provide {numQuestions} questions and the correct answer.");

            for (int i = 1; i <= numQuestions; i++)
            {
                Console.WriteLine($"Question {i}:");
                string question = Console.ReadLine();

                Console.WriteLine($"Answer {i}:");
                string answer = Console.ReadLine();
                // map question number to question/answer values
                questionsAndAnswers.Add(i, new TriviaData(question, answer));
            }
        }

        public void RateTheTrivia()
        {
            Console.WriteLine("\n> Wow, those sure were some trivia questions. How would you rate them on a scale from (1 to 5)?");

            Console.WriteLine("Trivia Rating (1 to 5):");
            string num = Console.ReadLine();
            if (Int32.TryParse(num, out int triviaRating))
            {
                if (triviaRating >= 1 && triviaRating <= 5)
                {
                    Console.WriteLine($"\n> We agree that your trivia was {(TriviaRating)triviaRating}");
                }
                else
                {
                    // numeric value not 1 through 5
                    Console.WriteLine("Number is not on the rating system...");
                }
            }
            else
            {
                // non numeric value
                Console.WriteLine("We didn't understand that rating...");
            }
        }

        public void SaveTrivia()
        {
            Console.WriteLine("> Saving trivia ...");

            // Creates unique question/answer set filename using date of submission
            var uniqueId = DateTime.Now.ToString("yyyyMMdd HHmmss");
            using StreamWriter file = new($"../../../QuestionSets/QuestionSet-{uniqueId}.txt");
            foreach (var triviaQuestion in questionsAndAnswers)
            {
                file.WriteLine(triviaQuestion.Key);
                file.WriteLine(triviaQuestion.Value.Question);
                file.WriteLine(triviaQuestion.Value.Answer);
            }
        }

        public enum TriviaRating
        {
            Poor = 1,
            Meh = 2,
            Ok = 3,
            Good = 4,
            Excellent = 5
        }

        private class TriviaData
        {
            public string Question { get; private set; }
            public string Answer { get; private set; }

            public TriviaData(string question, string answer)
            {
                Question = question;
                Answer = answer;
            }
        }
    }
}
