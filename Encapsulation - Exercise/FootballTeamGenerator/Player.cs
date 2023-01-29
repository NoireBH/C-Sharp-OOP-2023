using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;

        public Player(string name,int endurance,int sprint,int dribble,int passing,int shooting)
        {
            Name = name;
            Stats = new Stats(endurance, sprint, dribble, passing, shooting);
        }

        public string Name
        {
            get { return name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }

                name = value;
            }
        }

        public double AverageStats
            => (this.Stats.Endurance + this.Stats.Sprint + this.Stats.Dribble
            + this.Stats.Passing + this.Stats.Shooting) / 5.0;

        public Stats Stats { get; private set; }
    }
}
