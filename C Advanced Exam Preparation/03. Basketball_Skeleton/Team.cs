using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        
        private List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            players = new List<Player>();
        }

        public string Name { get;private set; }
        public int OpenPositions { get; private set; }
        public char Group { get; private set; }
        public IReadOnlyCollection<Player> Players => players;
        public int Count => players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return $"Invalid player's information.";
            }
            else if (this.OpenPositions == 0)
            {
                return $"There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return $"Invalid player's rating.";
            }
            else
            {
                this.players.Add(player);
                this.OpenPositions--;
                return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
            }
        }

        public bool RemovePlayer(string name)
        {
            if (players.Any(p => p.Name == name))
            {
                players.Remove(players.First(p => p.Name == name));
                OpenPositions++;
                return true;
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int playersToRemove = 0;

            if (players.Any(p => p.Position == position))
            {               
                while (players.FirstOrDefault(p => p.Position == position) != default)
                {
                    var playerToRemove = players.FirstOrDefault(p => p.Position == position);
                    playersToRemove++;
                    OpenPositions++;
                    players.Remove(playerToRemove);
                }
            }

            return playersToRemove;

        }

        public Player RetirePlayer(string name)
        {
            var playerToRetire = players.FirstOrDefault(p => p.Name == name);

            if (playerToRetire == default)
            {
                return null;
            }

            playerToRetire.Retired = true;
            return playerToRetire;
        }

        public List<Player> AwardPlayers(int games)
        {
            return new List<Player>(Players.Where(p => p.Games >= games));
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (var player in players.Where(p => p.Retired == false))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
