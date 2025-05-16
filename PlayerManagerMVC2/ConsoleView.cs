using System;
using System.Collections.Generic;

namespace PlayerManagerMVC2
{
    public class ConsoleView : IView
    {
        public void ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("----\n");
            Console.WriteLine("1. Insert player");
            Console.WriteLine("2. List all players");
            Console.WriteLine("3. List players with score greater than");
            Console.WriteLine("4. Sort players");
            Console.WriteLine("0. Quit\n");
            Console.Write("Your choice > ");
        }

        public string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowPlayers(IEnumerable<Player> players)
        {
            Console.WriteLine("\nList of players\n---------------");
            foreach (var player in players)
            {
                Console.WriteLine($" -> {player.Name} with a score of {player.Score}");
            }
        }
    }
}