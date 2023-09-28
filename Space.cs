public class Space {
    public static int SpaceCount { get; set; } = 0;
    public bool IsClaimed { get; set; } = false;
    public Player? ClaimedBy { get; set; }
    public Art? Symbol { get; set; }
    public (int x, int y) Position { get; set; }
    public (bool Top, bool Right, bool Bottom, bool Left) Boarders { get; set; } = (false, false, false, false);

    public Space(int x, int y) {
        // Set Properties -------------/
        SpaceCount++;
        IsClaimed = false;
        ClaimedBy = null;
        Symbol = null;
        Position = (x, y);

        // Set Boarders ---------------/
        bool bTop = (y != 0); // Check if in top row
        bool bRight = (x != 2); // Check if in right column
        bool bBottom = (y != 2); // Check if in bottom row
        bool bLeft = (x != 0); // Check if in left column
        Boarders = (bTop, bRight, bBottom, bLeft);
    }

    public void Render(int x, int y) {
        // Set Cursor Position --------/
        int xAdjust = (x == 0) ? 0 : 3 * x;
        int yAdjust = (y == 0) ? 0 : 3 * y;
        int xCoord = Board.Position.x + (x * Board.SpaceWidth) + xAdjust;
        int yCoord = Board.Position.y + (y * Board.SpaceHeight) + yAdjust;
        Console.SetCursorPosition(xCoord + x, yCoord + y);

        // Render Symbol Art ----------/
        if (Symbol is not null) {
            for (int i = 0; i < Symbol.ArtStrings!.Length; i++) {
                for (int j = 0; j < Symbol.ArtStrings[i].Length; j++) {
                    Console.SetCursorPosition(xCoord + j, yCoord + i);
                    if (Symbol.ArtStrings[i][j] == ' ') {
                        Console.Write(' ');
                    } else {
                        Console.Write(Symbol.ArtStrings[i][j]);
                    }
                }
            }
        }

        // Render Boarders ------------/
        RenderBoarders(xCoord, yCoord);
    }

    public void RenderBoarders(int x, int y) {
        if (Board.ActiveSpace == this) {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        if (Boarders.Top) {
            RenderTopBoarder(x, y - 1);
        }
        if (Boarders.Right) {
            RenderRightBoarder(x + Board.SpaceWidth + 1, y);
        }
        if (Boarders.Bottom) {
            RenderBottomBoarder(x, y + Board.SpaceHeight + 1);
        }
        if (Boarders.Left) {
            RenderLeftBoarder(x - 1, y);
        }
        Console.ResetColor();
    }

    public void RenderTopBoarder(int x, int y) {
        Console.SetCursorPosition(x, y);
        for (int i = 0; i <= Board.SpaceWidth / 2; i++) {
            Console.Write("* ");
        }
    }

    public void RenderRightBoarder(int x, int y) {
        for (int i = y; i <= Board.SpaceHeight + y; i++) {
            Console.SetCursorPosition(x, i);
            Console.Write("* ");
        }
    }

    public void RenderBottomBoarder(int x, int y) {
        Console.SetCursorPosition(x, y);
        for (int i = 0; i <= Board.SpaceWidth / 2; i++) {
            Console.Write("* ");
        }
    }

    public void RenderLeftBoarder(int x, int y) {
        for (int i = y; i <= Board.SpaceHeight + y; i++) {
            Console.SetCursorPosition(x, i);
            Console.Write(" *");
        }
    }
}