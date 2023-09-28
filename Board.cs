public class Board {
    public static (int x, int y) Position { get; set; } = (0, 0);
    public static int SpaceWidth { get; set; } = 18;
    public static int SpaceHeight { get; set; } = 7;
    public Space[,] Spaces { get; set; } = new Space[3,3];
    public static Space? ActiveSpace { get; set; }

    public Board() {
        // Create Spaces --------------/
        for (int y = 0; y < 3; y++) {
            for (int x = 0; x < 3; x++) {
                Spaces[x, y] = new(x, y);
            }
        }
        ActiveSpace = Spaces[0,0];
    }

    public void Render() {
        Position = (Console.CursorLeft, Console.CursorTop);
        // Render Spaces --------------/
        for (int y = 0; y < 3; y++) {
            for (int x = 0; x < 3; x++) {
                Spaces[x, y].Render(x, y);
            }
        }
    }

    public void Select() {
        ConsoleKey key;
        (int x, int y) = ActiveSpace!.Position;

        while (true) {
            key = Console.ReadKey(true).Key;

            switch (key) {
                case ConsoleKey.UpArrow:
                    if (y > 0) {
                        ActiveSpace = Spaces[x, y - 1];
                        return;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (x < 2) {
                        ActiveSpace = Spaces[x + 1, y];
                        return;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (y < 2) {
                        ActiveSpace = Spaces[x, y + 1];
                        return;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (x > 0) {
                        ActiveSpace = Spaces[x - 1, y];
                        return;
                    }
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    if (!ActiveSpace.IsClaimed) {
                        if (TicTacToe.ActivePlayer.Symbol == 'X') {
                            ActiveSpace.Symbol = new XMark();
                        } else {
                            ActiveSpace.Symbol = new OMark();
                        }
                        // Update Space Properties
                        ActiveSpace.ClaimedBy = TicTacToe.ActivePlayer;
                        ActiveSpace.IsClaimed = true;

                        // Change Players
                        TicTacToe.ActivePlayer = (TicTacToe.ActivePlayer == TicTacToe.Players[0]) ? TicTacToe.Players[1] : TicTacToe.Players[0];
                        return;
                    }
                    break;

            }
        }
    }

    public void CheckForWin() {
        // Check for Horizontal Win -----------/
        for (int y = 0; y < 3; y++) {
            if (Spaces[0, y].IsClaimed) {
                if (Spaces[0, y].ClaimedBy == Spaces[1, y].ClaimedBy && Spaces[1, y].ClaimedBy == Spaces[2, y].ClaimedBy) {
                    TicTacToe.GameOver = true;
                    Console.WriteLine();
                    Player Winner = (TicTacToe.ActivePlayer == TicTacToe.Players[0]) ? TicTacToe.Players[1] : TicTacToe.Players[0];
                    Utilities.Center($"{Winner.Name} wins!");
                    return;
                }
            }
        }

        // Check for Vertical Win -------------/
        for (int x = 0; x < 3; x++) {
            if (Spaces[x, 0].IsClaimed) {
                if (Spaces[x, 0].ClaimedBy == Spaces[x, 1].ClaimedBy && Spaces[x, 1].ClaimedBy == Spaces[x, 2].ClaimedBy) {
                    TicTacToe.GameOver = true;
                    Console.WriteLine();
                    Player Winner = (TicTacToe.ActivePlayer == TicTacToe.Players[0]) ? TicTacToe.Players[1] : TicTacToe.Players[0];
                    Utilities.Center($"{Winner.Name} wins!");
                    return;
                }
            }
        }

        // Check for Diagonal Win -------------/
        if (Spaces[0, 0].IsClaimed) {
            if (Spaces[0, 0].ClaimedBy == Spaces[1, 1].ClaimedBy && Spaces[1, 1].ClaimedBy == Spaces[2, 2].ClaimedBy) {
                TicTacToe.GameOver = true;
                Console.WriteLine();
                Player Winner = (TicTacToe.ActivePlayer == TicTacToe.Players[0]) ? TicTacToe.Players[1] : TicTacToe.Players[0];
                Utilities.Center($"{Winner.Name} wins!");
                return;
            }
        }

        if (Spaces[2, 0].IsClaimed) {
            if (Spaces[2, 0].ClaimedBy == Spaces[1, 1].ClaimedBy && Spaces[1, 1].ClaimedBy == Spaces[0, 2].ClaimedBy) {
                TicTacToe.GameOver = true;
                Console.WriteLine();
                Player Winner = (TicTacToe.ActivePlayer == TicTacToe.Players[0]) ? TicTacToe.Players[1] : TicTacToe.Players[0];
                Utilities.Center($"{Winner.Name} wins!");
                return;
            }
        }

        // Check for Draw ---------------------/
        foreach (Space space in Spaces) {
            if (space.Symbol is null) {
                return;
            }
        }
        TicTacToe.GameOver = true;
        Console.WriteLine();
        Utilities.Center("It's a Draw!");
    }
}
