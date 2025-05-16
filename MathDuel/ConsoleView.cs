using System;

public class ConsoleView : IView
{
    public void StartScreen()
    {
        Console.WriteLine("=== Math Duel ===");
        Console.WriteLine("Answer the math problems correctly!");
        Console.WriteLine("You can make up to 3 mistakes.");
        Console.WriteLine();
    }

    public string GetQuestion(string question)
    {
        Console.Write("Question: " + question + " ");
        return Console.ReadLine();
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void GetRightAnswer(int correctAnswer)
    {
        Console.WriteLine($"Wrong! The correct answer was {correctAnswer}.\n");
    }

    public void GameOver(int score)
    {
        Console.WriteLine($"Game over! Your final score is: {score}");
    }
}