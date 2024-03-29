﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {   
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get => endurance;

            private set
            {
                if (isInvalidStat(value))
                {
                    throw new Exception($"{nameof(Endurance)} should be between 0 and 100.");
                }

                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;

            private set
            {
                if (isInvalidStat(value))
                {
                    throw new Exception($"{nameof(Sprint)} should be between 0 and 100.");
                }

                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;

            private set
            {
                if (isInvalidStat(value))
                {
                    throw new Exception($"{nameof(Dribble)} should be between 0 and 100.");
                }

                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;

            private set
            {
                if (isInvalidStat(value))
                {
                    throw new Exception($"{nameof(Passing)} should be between 0 and 100.");
                }

                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;

            private set
            {
                if (isInvalidStat(value))
                {
                    throw new Exception($"{nameof(Shooting)} should be between 0 and 100.");
                }

                shooting = value;
            }
        }

        private bool isInvalidStat(int value)
            => value < 0 || value > 100;
    }
}
