using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class ControlPlayerAction : Action
    {
        private KeyboardService _keyboardService;

        public ControlPlayerAction(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor(Constants.PLAYER_GROUP);

            if (_keyboardService.IsKeyDown(Constants.LEFT))
            {
                player.MoveLeft();
            }
            else if (_keyboardService.IsKeyDown(Constants.RIGHT))
            {
                player.MoveRight();
            }
            else if (_keyboardService.IsKeyDown(Constants.UP))
            {
                player.MoveUp();
            }
            else if (_keyboardService.IsKeyDown(Constants.DOWN))
            {
                player.MoveDown();
            }
            else
            {
                player.StopMoving();
            }
        }
    }
}