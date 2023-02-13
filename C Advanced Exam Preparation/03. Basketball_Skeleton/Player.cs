using System;
using System.Text;

namespace Basketball
{
    public class Player
    {
        public Player(string name,string position,double rating, int games)
        {
            Name = name;
            Position = position;
            Rating = rating;
            Games = games;
        }
        public string Name { get; private set; }
        public string Position { get; private set; }
        public double Rating { get; private set; }
        public int Games { get; private set; }

        public bool Retired { get; set; } = false;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Player: {Name}");
            sb.AppendLine($"--Position: {Position}");
            sb.AppendLine($"--Rating: {Rating}");
            sb.AppendLine($"--Games played: {Games}");

            return sb.ToString().TrimEnd();
        }
    }
}
