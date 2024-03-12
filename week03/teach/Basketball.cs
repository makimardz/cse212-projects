/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);
        // If the player already exists in the dictionary, update their total points
            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            }
            // Otherwise, add the player to the dictionary
            else
            {
                players.Add(playerId, points);
            }
        }

        // Sort the players by career points (descending order)
        var sortedPlayers = new List<KeyValuePair<string, int>>(players);
        sortedPlayers.Sort((x, y) => y.Value.CompareTo(x.Value));

        // Display the top 10 players with the highest career points
        Console.WriteLine("Top 10 Players by Career Points:");
        for (int i = 0; i < Math.Min(10, sortedPlayers.Count); i++)
        {
            Console.WriteLine($"{i + 1}. Player ID: {sortedPlayers[i].Key}, Career Points: {sortedPlayers[i].Value}");
        }
    }
}