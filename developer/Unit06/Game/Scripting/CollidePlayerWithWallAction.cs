using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class CollidePlayerWithWallAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        
        public CollidePlayerWithWallAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor(Constants.PLAYER_GROUP);
            Body body = player.GetBody();
            Point position = body.GetPosition();
            int x = position.GetX();
            int y = position.GetY();

            if (x < (Constants.WALL_WIDTH))
            {
                position = new Point(Constants.WALL_WIDTH, y);
            }
            else if ((x + Constants.PLAYER_WIDTH) > (Constants.FIELD_RIGHT - Constants.WALL_WIDTH))
            {
                position = new Point(Constants.FIELD_RIGHT - Constants.WALL_WIDTH - Constants.PLAYER_WIDTH, position.GetY());
            }
            else if (y < (Constants.FIELD_TOP + Constants.WALL_WIDTH))
            {
                position = new Point(position.GetX(), Constants.FIELD_TOP + Constants.WALL_HEIGHT);
            }
            else if ((y + Constants.PLAYER_HEIGHT) > (Constants.FIELD_BOTTOM - Constants.WALL_WIDTH))
            {
                position = new Point(position.GetX(), Constants.FIELD_BOTTOM - Constants.WALL_HEIGHT - Constants.PLAYER_HEIGHT);
            }
            body.SetPosition(position);
        }
    }
}