using System;
using System.Collections.Generic; 
using System.Linq;

public class Program 
{
    static void Main(string[] args) 
    {
        Dictionary<string, List<int>> scoreboardProject = new Dictionary<string, List<int>>(); // The dictionary.

        var sortedScoreboard = scoreboardProject.OrderBy(kv => kv.Key); // This is for the initialization of the sorting mechanism.

        scoreboardProject.Add("PtT1234", new List<int> { 95, 87, 92 });
        scoreboardProject.Add("H4wk3y3s", new List<int> { 78, 85, 90 });
        scoreboardProject.Add("Guest20394", new List<int> { 88, 91, 84 });
        scoreboardProject.Add("Gamerkid3023", new List<int> { 92, 89, 95 });

        bool running = true;
        bool viewSorted = false; // This is for the sorting system, being able to pick between sorted and unsorted.
        
        while (running) // This helps prevent an infinite loop
        {
            Console.WriteLine("\n----------------------------");
            Console.WriteLine("        Scoreboard Menu       ");
            Console.WriteLine("1. View Scoreboard");
            Console.WriteLine("2. Add a New Player");
            Console.WriteLine("3. Add a score to an existing player");
            Console.WriteLine("4. Remove a Player from the Board");
            Console.WriteLine("5. Display Scoreboard Alphabetically");
            Console.WriteLine("6. Exit");
            Console.WriteLine("------------------------------");
            Console.Write("Select an option (1-6): ");
           
            string? choice = Console.ReadLine();
            

            switch (choice) 
            {
                case "1": // This is for viewing of the players, with one of the enumation methods from the textbook.
                    if (scoreboardProject.Count == 0) 
                    {
                         Console.WriteLine("The scoreboard is empty.");
                         
                    }

                    Console.WriteLine(" -Scoreboard-");
                    if (viewSorted == true) // This is for the chaning between viewing a sorted list and an unsorted list.
                    {
                        foreach (KeyValuePair<string, List<int>> player in sortedScoreboard) // This is the sorted list.
                    
                        {
                            string scores = string.Join(", ", player.Value);
                            Console.WriteLine($"Player: {player.Key}, Match Scores: {scores}");
                        }
                    }
                    else 
                    {
                        foreach (KeyValuePair<string, List<int>> player in scoreboardProject) // This is the unsorted list.
                        {
                            string scores = string.Join(", ", player.Value);
                            Console.WriteLine($"Player: {player.Key}, Match Scores: {scores}");
                        }
                    }    
                    break;                    
                case "2": // This is for the Addition of Players
                    Console.Write("Enter the new player's name: ");
                    string? newPlayerName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(newPlayerName))  // This detects if the player is null or empty
                    {
                        Console.WriteLine("Player name cannot be empty.");
                    }
                    else if (scoreboardProject.ContainsKey(newPlayerName)) // This pervents a bug involving the same player being added.
                    {
                        Console.WriteLine("Player already exists.");
                    }
                    else
                    {
                        Console.Write("Enter the initial score for the player: ");
                        if (int.TryParse(Console.ReadLine(), out int initialScore))
                        {
                            scoreboardProject.Add(newPlayerName, new List<int> {initialScore}); // This adds the player with an initial score.
                            Console.WriteLine($"Player added successfully with score of {initialScore}.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid score entered.");
                        }
                    }
                    break;
                case "3":
                    Console.Write("Enter the player's name to add a score: "); // This is for the addition of a score to an existing player.
                    string existingPlayerName = Console.ReadLine() ?? ""; // The ?? "" code is to prevent nulls, preventing the warnings.

                    if (scoreboardProject.ContainsKey(existingPlayerName)) // This detects if the player name in the dictionary is found.
                    {
                        Console.Write("Enter the score to add: ");
                        if (int.TryParse(Console.ReadLine(), out int newScore))  // Thhis adds the score into the list.
                        {
                            scoreboardProject[existingPlayerName].Add(newScore);
                            Console.WriteLine($"Score of {newScore} added for player {existingPlayerName}.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid score entered.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Player not found.");
                    }
                    break;
                case "4":
                    Console.Write("Enter the player's name to remove: "); 
                    string? playerToRemove = Console.ReadLine() ?? ""; // The ?? "" code is to prevent nulls, preventing the warnings.

                    if (scoreboardProject.ContainsKey(playerToRemove)) // This detects if the player name in the dictionary is found.
                    {
                        scoreboardProject.Remove(playerToRemove); // This removes the player from the list
                        Console.WriteLine($"Player {playerToRemove} removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Player not found.");
                    }
                    break;
                case "5":
                 Console.WriteLine("------------------------------"); // This splits into another switch case, where you can pick between Ascending, Descending, and Unsorted.
                 Console.WriteLine("Please select how you would like to sort the scoreboard by typing the option in:"); 
                 Console.WriteLine("1: Ascending order");
                 Console.WriteLine("2: Descending order");
                 Console.WriteLine("3: Unsorted order (Original order)");
                 Console.WriteLine("------------------------------");
                 choice = Console.ReadLine();
                 switch (choice)
                 {
                    case "1":
                       sortedScoreboard = scoreboardProject.OrderBy(kv => kv.Key); // This orders it Ascending and turns sorting on.
                       viewSorted = true;
                       break;
                    case "2":
                       sortedScoreboard = scoreboardProject.OrderByDescending(kv => kv.Key); // This orders it Descending and turns sorting on.
                       viewSorted = true;
                       break;
                    case "3":
                       viewSorted = false; // This turns sorting off.
                       break;
                 }
                    break;
                case "6":
                    running = false; // This simply exits the program.
                    Console.WriteLine("Exiting the Scoreboard Program. Goodbye!");
                    break;
            }
                    }
    }
}   
// The end of the program.









