public class Art {
    public string[]? ArtStrings { get; set; }

    public void Render() {
        if (ArtStrings is null) return;

        foreach (string line in ArtStrings) {
            Utilities.Center(line);
        }
    }
}
public class Title : Art {
    public Title() {
        ArtStrings = new string[] {
            @"------------------------------------------------------------",
            @"       _____ ___ ___   _____ _   ___   _____ ___  ___       ",
            @"      |_   _|_ _/ __|_|_   _/_\ / __|_|_   _/ _ \| __|      ",
            @"        | |  | | (_|___|| |/ _ \ (_|___|| || (_) | _|       ",
            @"        |_| |___\___|   |_/_/ \_\___|   |_| \___/|___|      ",
            @"                                                            ",
            @"------------------------------------------------------------"                                          
        };
    }
}
public class XMark : Art {
    public XMark() {
        ArtStrings = new string[] {
            @"                  ",
            @"      __  __      ",
            @"      \ \/ /      ",
            @"       >  <       ",
            @"      /_/\_\      ",
            @"                  ",
            @"                  "
        };
    }
}
public class OMark : Art {
    public OMark() {
        ArtStrings = new string[] {
            @"                  ",
            @"       ___        ",
            @"      / _ \       ",
            @"     | (_) |      ",
            @"      \___/       ",
            @"                  ",
            @"                  "
        };
    }
}