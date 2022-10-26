using System;

namespace InterviewTest
{
    class Program
    {
        // Updated Oct 2022: Per research question count decreases 5 -> 3
        private const int QuestionCount = 3;

        static void Main(string[] args)
        {
            new TriviaBot().Run(QuestionCount);
        }
    }
}
