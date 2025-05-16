using System;

public class Controller
{
    public int score { get; set; }
    public int wrongAnswers { get; set; }
    private readonly IView view;
    public Controller(IView view)
    {
        this.view = view;
        this.score = 0;
        this.wrongAnswers = 0;
    }

    public void Run()
    {
        view.StartScreen();
        Random rand = new Random();
        Game(rand);
    }

    public void Game(Random rand)
    {
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

            int playerAnswer = int.Parse(view.GetQuestion(question));

            if (playerAnswer == correctAnswer)
            {
                view.ShowMessage("Correct!\n");
                score++;
            }
            else
            {
                view.GetRightAnswer(correctAnswer);
                wrongAnswers++;
            }
        }

        view.GameOver(score);
    }
}