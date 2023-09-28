public static class TicTacToe {
    public static Player[] Players { get; set; } = new Player[2];
    public static Player ActivePlayer { get; set; } = Players[0];
    public static bool GameOver { get; set; } = false;
    public static int WindowWidth { get; set; } = 60;

    public static void Main() {
        // Set Console Properties -------------------------/
        Console.Title = "Tic-Tac-Toe";
        // Console.WindowWidth = WindowWidth; // Only works on Windows
        Console.CursorVisible = false;

        // Display Title Page -------------------------------------------------/
        Console.Clear();
        Title title = new();
        title.Render();

        // Display Instructions -------/
        Utilities.Center("Welcome to Tic-Tac-Toe!");
        Console.WriteLine();
        Utilities.Center("Players take turns claiming spaces on a board.");
        Utilities.Center("The first player to claim three in a row wins!");
        Console.WriteLine();
        Utilities.Center("Press any key to continue...");
        Console.ReadKey(true);

        Console.Clear();
        // --------------------------------------------------------------------/

        // Initialize Players -----------------------------/
        title.Render();
        Players[0] = new();
        Players[1] = new();
        ActivePlayer = Players[0];

        // Game Loop ----------------------------------------------------------/
        Board board = new();

        while (!GameOver) {
            Console.Clear();
            // Display Title & Instructions ---------------/
            title.Render();
            Utilities.Center($"{ActivePlayer.Name}'s turn!");
            Utilities.Bar();

            // Display Board ------------------------------/
            board.Render();
            
            // Check for Win Condition --------------------/
            board.CheckForWin();

            // Get Player Input ---------------------------/
            board.Select();

        }
        //---------------------------------------------------------------------/
    }
}

public class Player {
    public static int PlayerCount { get; set; } = 0;
    public string Name { get; set; } = $"Player {++PlayerCount}";
    public char Symbol { get; set; }

    public Player() {
        Console.Write($"Enter a name for {Name}: ");
        Name = Console.ReadLine()!;
        Name ??= $"Player {PlayerCount}";
        Symbol = (PlayerCount == 1) ? 'X' : 'O';
    }
}

public static class Utilities {
    public static void Center(string text) {
        Console.SetCursorPosition((TicTacToe.WindowWidth - text.Length) / 2, Console.CursorTop);
        Console.WriteLine(text);
    }
    
    public static void Bar() {
        Console.WriteLine("------------------------------------------------------------");
    }
}