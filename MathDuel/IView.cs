using System;

public interface IView
{
    void StartScreen();
    string GetQuestion(string question);
    void ShowMessage(string message);
    void GetRightAnswer(int correctAnswer);
    void GameOver(int score);
}