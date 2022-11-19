using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary.
    /// <para>An input action that controls the player's trail.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the player.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService _keyboardService;
        private Point _direction1 = new Point(0, Constants.CELL_SIZE * -1);
        private Point _direction2 = new Point(0, Constants.CELL_SIZE * -1);
        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {   
            Player player1 = (Player)cast.GetActors("player")[0];
            Player player2 = (Player)cast.GetActors("player")[1];
            
            // first player
            if (player1.GetPlayerNumber() == 1)
            {
                // left
                if (_keyboardService.IsKeyDown("a"))
                {
                    _direction1 = new Point(-Constants.CELL_SIZE, 0);
                }
                // right
                if (_keyboardService.IsKeyDown("d"))
                {
                    _direction1 = new Point(Constants.CELL_SIZE, 0);
                }
                // up
                if (_keyboardService.IsKeyDown("w"))
                {
                    _direction1 = new Point(0, -Constants.CELL_SIZE);
                }
                // down
                if (_keyboardService.IsKeyDown("s"))
                {
                    _direction1 = new Point(0, Constants.CELL_SIZE);
                }

                player1.TurnPlayer(_direction1);
            }

            // second player
            if (player2.GetPlayerNumber() == 2)
            {
                // left
                if (_keyboardService.IsKeyDown("j"))
                {
                    _direction2 = new Point(-Constants.CELL_SIZE, 0);
                }
                // right
                if (_keyboardService.IsKeyDown("l"))
                {
                    _direction2 = new Point(Constants.CELL_SIZE, 0);
                }
                // up
                if (_keyboardService.IsKeyDown("i"))
                {
                    _direction2 = new Point(0, -Constants.CELL_SIZE);
                }
                // down
                if (_keyboardService.IsKeyDown("k"))
                {
                    _direction2 = new Point(0, Constants.CELL_SIZE);
                }
                player2.TurnPlayer(_direction2);
            }
        }
    }
}