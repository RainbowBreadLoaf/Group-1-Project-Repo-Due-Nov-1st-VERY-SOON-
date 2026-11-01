Using system;
using system. Collections. Generic; 
using system. Linq;

public class program 
{
    static void main(string[] args) 
    {
        Dictionary<string, List<int>> ScoreboardProject = new Dictionary<string, List<int>>();

        scoreboardProject.Add("PtT1234", new List<int> { 95, 87, 92 });
        scoreboardProject.Add("H4wk3y3s", new List<int> { 78, 85, 90 });
        scoreboardProject.Add("Guest20394", new List<int> { 88, 91, 84 });
        scoreboardProject.Add("Gamerkid3023", new List<int> { 92, 89, 95 });

        bool running = true;
        while (running) 
        {
            Console.WriteLine("\n----------------------------");
            console.WriteLine("        Scoreboard Menu       ");
            Console.WriteLine("1. View Scoreboard");
            Console.WriteLine("2. Add a New Player");
            console.WriteLine("3. Add a score to an existing player");
            console.WriteLine("4. Remove a Player from the Board");
            console.WriteLine("5.Display Scoreboard Alphabetically");
            console.WriteLine("6. Exit");
            Console.WriteLine("------------------------------");
            Console.Write("Select an option (1 -6): ");
           
            string choice = Console.ReadLine();
            bool viewSorted = false;

            switch (choice) 
            {
                case "1":
                    if (scoreboardProject.count == 0) 
                    {
                        Console.WriteLine("The scoreboard is empty.");
                    break;
                    }

                    Console,WriteLine(" -Scoreboard-");
                    if(viewSorted == true)
                    {
                    foreach (KeyValuePair<string, List<int>> player in sortedScoreboardProject) 
                    
                    {
                        string scores = string.Join(", ", player.Value);
                        Console.WriteLine($"Player: {player.Key}, Match Scores: {scores}");
                    }
                }
                    else 
                    {
                        foreach (KeyValuePair<string, List<int>> player in scoreboardProject) 
                        {
                            string scores = string.Join(", ", player.Value);
                            Console.WriteLine($"Player: {player.Key}, Match Scores: {scores}");
                        }
                    }                        
                     case "2":
                    Console.Write("Enter the new player's name: ");
                    string newPlayerName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(newPlayerName)) 
                    {
                        Console.WriteLine("Player name cannot be empty.");
                    }
                    else if (scoreboardProject.ContainsKey(newPlayerName)) 
                    {
                        Console.WriteLine("Player already exists.");
                    }
                    else
                    {
                        Console.Write("Enter the initial score for the player: ");
                        if (int.TryParse(Console.ReadLine(), out int initialScore))
                        {
                            scoreboardProject.Add(newPlayerName, new List<int> {initialScore});
                            Console.WriteLine($"Player added successfully with score of {initialScore}.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid score entered.");
                        }
                    }
                break;
                Case "3":
                    Console.Write("Enter the player's name to add a score: ");
                    string existingPlayerName = Console.ReadLine();

                    if (scoreboardProject.ContainsKey(existingPlayerName)) 
                    {
                        Console.Write("Enter the score to add: ");
                        if (int.TryParse(Console.ReadLine(), out int newScore)) 
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
                    string playerToRemove = Console.ReadLine();

                    if (scoreboardProject.ContainsKey(playerToRemove))
                    {
                        scoreboardProject.Remove(playerToRemove);
                        Console.WriteLine($"Player {playerToRemove} removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Player not found.");
                    }
                    break;
                case "5":
                 Console.WriteLine("------------------------------");
                 Console.WriteLine("Please select how you would like to sort the scoreboard by typing the option in:"); 
                 Console.WriteLine("1:Ascending order");
                 Console.WriteLine("2:Descending order");
                 Console.WriteLine("3: Unsorted order (Original order)");
                 Console.WriteLine("------------------------------");
                 choice = Console.ReadLine();
                 switch (choice)
                 {
                    case "1":
                    sortedScoreBoard = scoreboardProject.OrderBy(kv => kv.Key);
                    viewSorted = true;
                    break;
                    case "2":
                    sortedScoreBoard = scoreboardProject.OrderByDescending(kv => kv.Key);
                    viewSorted = true;
                    break;
                    case "3":
                    viewSorted = false;
                    break;
                 }
                    Break;
                case "6":
                    running = false;
                    Console.WriteLine("Exiting the Scoreboard Program. Goodbye!");
                    break;
            }
                    }
    }
}   





