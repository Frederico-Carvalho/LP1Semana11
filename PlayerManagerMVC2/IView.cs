using System.Collections.Generic;

namespace PlayerManagerMVC2
{
    public interface IView
    {
        void ShowMenu();
        string GetInput(string prompt);
        void ShowMessage(string message);
        void ShowPlayers(IEnumerable<Player> players);
    }
}