using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unit04.Game.Casting;
using Unit04.Game.Directing;
using Unit04.Game.Services;

namespace Unit04
{
    /// <summary>
    /// The program's entry point.
    /// </summaru>
    class Program
    {
        private static int FRAME_RATE = 12;
        private static int MAX_X = 1000;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 20;
        private static int FONT_SIZE = 20;
        private static string CAPTION = "Greed";
        private static Color WHITE = new Color(255, 255, 255);

        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="arg">The given arguments.</param>
        static void Main(string[] args)
        {
            // Create the cast
            Cast cast = new Cast();

            // Create the banner
            Actor banner = new Actor();
            banner.SetText("Score: 0");
            banner.SetFontSize(FONT_SIZE);
            banner.SetColor(WHITE);
            banner.SetPosition(new Point(CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            // Create the player
            Actor player = new Actor();
            player.SetText("#");
            player.SetFontSize(FONT_SIZE);
            player.SetColor(WHITE);
            player.SetPosition(new Point(MAX_X / 2, MAX_Y - CELL_SIZE * 2));
            cast.AddActor("player", player);

            // Since the rocks and diamonds are being created through the game
            // the list will not be created here.

            // start the game
            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(cast);
        }
    }
}