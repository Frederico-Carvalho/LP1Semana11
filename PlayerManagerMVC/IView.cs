using System.Collections.Generic;

namespace PlayerManagerMVC
{
    public interface IView
    {
        void ShowMenu();
        string GetInput(string prompt);
        void ShowMessage(string message);
        void ShowPlayers(IEnumerable<Player> players);
    }
}