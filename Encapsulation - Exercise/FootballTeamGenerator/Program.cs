using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {   
        private static List<Team> teams;
        static void Main(string[] args)
        {
             teams = new List<Team>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandInfo = input.Split(';');
                string command = commandInfo[0];
                string teamName = commandInfo[1];
                try
                {
                    if (command == "Team")
                    {
                        CreateNewTeam(teamName);
                    }

                    else if (command == "Add")
                    {
                        AddPlayerToTheTeam(teamName, commandInfo);
                    }

                    else if (command == "Remove")
                    {
                        RemovePlayerFromTeam(commandInfo, teamName);

                    }

                    else if (command == "Rating")
                    {
                        RateTeam(teamName);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
            }
        }

        private static void RateTeam(string teamName)
        {
            Team teamtoRate = teams.FirstOrDefault(t => t.Name == teamName);

            if (teamtoRate == null)
            {
                throw new Exception($"Team {teamName} does not exist.");
            }

            Console.WriteLine($"{teamName} - {teamtoRate.Rating}");
        }

        private static void RemovePlayerFromTeam(string[] commandInfo, string teamName)
        {
            string playerName = commandInfo[2];
            Team teamToRemovePlayerFrom = teams.FirstOrDefault(t => t.Name == teamName);

            if (teamToRemovePlayerFrom == null)
            {
                throw new Exception($"Team {teamName} does not exist.");
            }

            teamToRemovePlayerFrom.RemovePlayer(playerName);
        }

        private static void CreateNewTeam(string teamName)
        {
            Team team = new Team(teamName);
            teams.Add(team);
        }

        static void AddPlayerToTheTeam(string teamName, string[] commandInfo)
        {
            Team teamToJoin = teams.FirstOrDefault(t => t.Name == teamName);

            if (teamToJoin == null)
            {
                throw new Exception($"Team {teamName} does not exist.");
            }

            else
            {
                string playerName = commandInfo[2];
                int endurance = int.Parse(commandInfo[3]);
                int sprint = int.Parse(commandInfo[4]);
                int dribble = int.Parse(commandInfo[5]);
                int passing = int.Parse(commandInfo[6]);
                int shooting = int.Parse(commandInfo[7]);

                Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                teamToJoin.AddPlayer(player);
            }
        }   
    }
}
