using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private List<Player> players;

    public Team(string name)
    {
        players = new List<Player>();
        Name = name;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }
    public void AddPlayer(Player player)
    {
        players.Add(player);
    }
    public double TeamRating()
    {
        var allPlayers = players.Select(p => p.GetPlayerStats()).ToList();
        if (players.Count == 0)
        {
            return 0;
        }
        else
        {
            return allPlayers.Average();
        }

    }
    public void RemovePlayer(string playerName)
    {
        if (players.Exists(p => p.Name == playerName))
        {
            var playerToRemove = players.Find(p => p.Name == playerName);
            players.Remove(playerToRemove);
        }
        else
        {
            throw new ArgumentException($"Player {playerName} is not in {this.name} team.");
        }
    }
}
