using System;
using System.Collections.Generic;
using System.IO;

public class Controller
{
    private readonly List<int> equationList;
    private readonly List<int> aList;
    private readonly List<int> bList;
    public int score { get; set; }
    public int wrongAnswers { get; set; }
    private readonly IView view;

    public Controller(IView view, string filename)
    {
        this.view = view;
        score = 0;
        wrongAnswers = 0;
        LoadData(filename, out equationList, out aList, out bList);
    }

    public void LoadData(string filename, out List<int> equations, out List<int> aList, out List<int> bList)
    {
        equations = new List<int>();
        aList = new List<int>();
        bList = new List<int>();

        foreach (string line in File.ReadLines(filename))
        {
            string[] parts = line.Split(' ');
            if (parts.Length < 3) continue;

            if (parts[0] == "+")
                equations.Add(0);
            else if (parts[0] == "-")
                equations.Add(1);
            else
                equations.Add(2);

            int.TryParse(parts[1], out int numa);
            aList.Add(numa);

            int.TryParse(parts[2], out int numb);
            bList.Add(numb);
        }
    }
    public void Run()
    {
        view.StartScreen();
        Game();
    }

    public void Game()
    {
        for (int i = 0; i < equationList.Count; i++)
        {
            int correctAnswer;
            string question;

            if (equationList[i] == 0)
            {
                correctAnswer = aList[i] + bList[i];
                question = $"{aList[i]} + {bList[i]} = ?";
            }
            else if (equationList[i] == 1)
            {
                correctAnswer = aList[i] - bList[i];
                question = $"{aList[i]} - {bList[i]} = ?";
            }
            else
            {
                correctAnswer = aList[i] * bList[i];
                question = $"{aList[i]} * {bList[i]} = ?";
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
            if (wrongAnswers == 3)
            {
                break;
            }
        }

        view.GameOver(score);
    }
}