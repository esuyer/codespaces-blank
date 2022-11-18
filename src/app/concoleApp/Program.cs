// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
using consoleApp;
using battleship;

Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

ConsoleApp app = new ConsoleApp();

if (args.Length == 0 || string.IsNullOrEmpty(args[0]))
{
    // no arguments passed, start the game
    app.DisplayGameSplash();
    Game game = new Game();
    game.Setup();

    // while there are ships in the game that are left to sync
    do 
    {
        Trace.WriteLine("What are the coordinates of your next missle strike, Captain?");
        Trace.Write("Row:");
        string? line = Console.ReadLine();
        char row = 'A';
        if (line != null) row = char.Parse(line);

        Trace.Write("Col:");
        int col = Convert.ToInt32(Console.ReadLine());

        game.FireMissle(row, col);
        app.DisplayMap(game.Map);
        app.DisplayShips(game.Ships);

    } while ( (game.Ships.Find(x => x.IsSunk == false)) != null );

}



