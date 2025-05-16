using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int score = 0;
        int wrongAnswers = 0;

        Console.WriteLine("=== Math Duel ===");
        Console.WriteLine("Answer the math problems correctly!");
        Console.WriteLine("You can make up to 3 mistakes.");
        Console.WriteLine();

        while (wrongAnswers < 3)
        {
            int a = rand.Next(1, 11);     // 1 to 10
            int b = rand.Next(1, 11);
            int operation = rand.Next(3); // 0: +, 1: -, 2: *

            int correctAnswer;
            string question;

            if (operation == 0)
            {
                correctAnswer = a + b;
                question = $"{a} + {b} = ?";
            }
            else if (operation == 1)
            {
                correctAnswer = a - b;
                question = $"{a} - {b} = ?";
            }
            else
            {
                correctAnswer = a * b;
                question = $"{a} * {b} = ?";
            }

            Console.Write("Question: " + question + " ");
            string input = Console.ReadLine();

            int playerAnswer = int.Parse(input);

            if (playerAnswer == correctAnswer)
            {
                Console.WriteLine("Correct!\n");
                score++;
            }
            else
            {
                Console.WriteLine($"Wrong! The correct answer was {correctAnswer}.\n");
                wrongAnswers++;
            }
        }

        Console.WriteLine($"Game over! Your final score is: {score}");
    }
}
