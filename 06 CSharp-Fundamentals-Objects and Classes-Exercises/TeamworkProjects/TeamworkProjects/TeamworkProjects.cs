using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkProjects
{
    class TeamworkProjects
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of assignment")
                {
                    break;
                }

                char[] delimiter = new char[] { '-', '>' };
                string[] teamInfo = input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = GetCommand(input);
                string userName = teamInfo[0];
                string teamName = teamInfo[1];

                if (command == "-")
                {
                    if (teams.Any(x => x.Creator == userName))
                    {
                        PrintMessage($"{userName} cannot create another team!");
                    }
                    else if (!teams.Any(x => x.TeamName == teamName))
                    {
                        Team newTeam = new Team();
                        newTeam.TeamName = teamName;
                        newTeam.Creator = userName;
                        teams.Add(newTeam);

                        PrintMessage($"Team {teamName} has been created by {userName}!");
                    }
                    else
                    {
                        PrintMessage($"Team {teamName} was already created!");
                    }
                }
                else
                {
                    if (!teams.Any(x => x.TeamName == teamName))
                    {
                        PrintMessage($"Team {teamName} does not exist!");
                    }
                    else if (teams.Any(x => x.Users.Contains(userName)) || teams.Any(x => x.Creator == userName))
                    {
                        PrintMessage($"Member {userName} cannot join team {teamName}!");
                    }
                    else
                    {
                        int indexTeam = teams.FindIndex(x => x.TeamName == teamName);
                        teams[indexTeam].Users.Add(userName);
                    }
                }
            }

            Team.PrintOutput(teams);
        }

        public class Team
        {
            public Team()
            {
                Users = new List<string>();
            }
            public string TeamName { get; set; }
            public string Creator { get; set; }
            public List<string> Users { get; set; }
            public static void PrintOutput(List<Team> teams)
            {
                List<string> disbandesTeams = new List<string>();

                foreach (var team in teams.OrderBy(a => a.TeamName).OrderByDescending(a => a.Users.Count))
                {
                    if (team.Users.Count > 0)
                    {
                        PrintMessage(team.TeamName);
                        PrintMessage($"- {team.Creator}");

                        foreach (var user in team.Users.OrderBy(a => a))
                        {
                            PrintMessage($"-- {user}");
                        }
                    }
                    else
                    {
                        disbandesTeams.Add(team.TeamName);
                    }
                }

                PrintMessage("Teams to disband:");

                foreach (var team in disbandesTeams.OrderBy(a => a))
                {
                    PrintMessage(team);
                }
            }
        }
        public static string GetCommand(string input)
        {
        string command = string.Empty;

        if (input.Contains("-") && input[input.IndexOf("-") + 1] != '>')
        {
            command = "-";
        }
        else
        {
            command = "->";
        }

        return command;
        }

        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
