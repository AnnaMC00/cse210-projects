using Unit05.Game.Casting;
using Unit05.Game.Directing;
using Unit05.Game.Scripting;
using Unit05.Game.Services;


namespace Unit05
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // Player 1
            Point positionP1 = new Point(Constants.COLUMNS / 3, Constants.ROWS / 2);
            positionP1 = positionP1.Scale(Constants.CELL_SIZE);
            Color colorP1 = Constants.RED;
            Point score1position = new Point(Constants.COLUMNS / 3, 0);
            score1position = score1position.Scale(Constants.CELL_SIZE);

            // // Player 2
            Point positionP2 = new Point(Constants.COLUMNS / 3 * 2, Constants.ROWS / 2);
            positionP2 = positionP2.Scale(Constants.CELL_SIZE);
            Color colorP2 = Constants.GREEN;
            Point score2position = new Point(Constants.COLUMNS / 3 * 2, 0);
            score2position = score2position.Scale(Constants.CELL_SIZE);

            // create the cast
            Cast cast = new Cast();
            cast.AddActor("player", new Player(positionP1, colorP1, Constants.PLAYER1));
            cast.AddActor("player", new Player(positionP2, colorP2, Constants.PLAYER2));
            cast.AddActor("score", new Score(Constants.PLAYER1, score1position));
            cast.AddActor("score", new Score(Constants.PLAYER2, score2position));

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);

            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}
