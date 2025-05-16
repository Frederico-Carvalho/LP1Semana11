using System;
using System.IO;
using System.Collections.Generic;
namespace PlayerManagerMVC2
{
    public class PlayerController
    {
        private readonly List<Player> playerList;

        // Comparer for comparing player by name (alphabetical order)
        private readonly IComparer<Player> compareByName;

        // Comparer for comparing player by name (reverse alphabetical order)
        private readonly IComparer<Player> compareByNameReverse;

        private readonly IView view;

        public PlayerController(IView view, string filename)
        {
            this.view = view;
            compareByName = new CompareByName(true);
            compareByNameReverse = new CompareByName(false);
            playerList = LoadPlayersFromFile(filename);
        }

        private List<Player> LoadPlayersFromFile(string filename)
        {
            var players = new List<Player>();

            foreach (string line in File.ReadLines(filename))
            {
                string[] parts = line.Split(',');

                if (parts.Length == 2 &&
                    !string.IsNullOrWhiteSpace(parts[0]) &&
                    int.TryParse(parts[1], out int score))
                {
                    string name = parts[0].Trim();
                    players.Add(new Player(name, score));
                }
                else
                {
                    view.ShowMessage($"Aviso: linha ignorada '{line}' (formato inválido)");
                }
            }

            return players;
        }


        public void Run()
        {
            // We keep the user's option here
            string option;

            // Main program loop
            do
            {
                // Show menu and get user option
                view.ShowMenu();
                option = view.GetInput("");

                // Determine the option specified by the user and act on it
                switch (option)
                {
                    case "1":
                        // Insert player
                        InsertPlayer();
                        break;
                    case "2":
                        view.ShowPlayers(playerList);
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        SortPlayerList();
                        break;
                    case "0":
                        view.ShowMessage("Bye!");
                        break;
                    default:
                        view.ShowMessage("\n>>> Unknown option! <<<\n");
                        break;
                }

                // Wait for user to press a key...
                view.GetInput("\nPress any key to continue...");

                // Loop keeps going until players choses to quit (option 4)
            } while (option != "0");
        }

        private void InsertPlayer()
        {
            string name = view.GetInput("Name: ");
            int score = int.Parse(view.GetInput("Score: "));
            playerList.Add(new Player(name, score));
        }

        private void ListPlayersWithScoreGreaterThan()
        {
            int minScore = int.Parse(view.GetInput("Minimum score player should have? "));
            var filtered = playerList.FindAll(p => p.Score > minScore);
            view.ShowPlayers(filtered);
        }

        private void SortPlayerList()
        {
            view.ShowMessage("Player order\n------------");
            view.ShowMessage($"{(int)PlayerOrder.ByScore}. Order by score");
            view.ShowMessage($"{(int)PlayerOrder.ByName}. Order by name");
            view.ShowMessage($"{(int)PlayerOrder.ByNameReverse}. Order by name (reverse)");
            PlayerOrder playerOrder = Enum.Parse<PlayerOrder>(view.GetInput("> "));

            switch (playerOrder)
            {
                case PlayerOrder.ByScore:
                    playerList.Sort();
                    break;
                case PlayerOrder.ByName:
                    playerList.Sort(compareByName);
                    break;
                case PlayerOrder.ByNameReverse:
                    playerList.Sort(compareByNameReverse);
                    break;
            }
        }
    }
}