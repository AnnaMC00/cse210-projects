using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawPlayerAction : Action
    {
        private VideoService _videoService;
        
        public DrawPlayerAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor(Constants.PLAYER_GROUP);
            Body body = player.GetBody();

            if (player.IsDebug())
            {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                _videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
            }

            Animation animation = player.GetAnimation();
            Image image = animation.NextImage();
            Point position = body.GetPosition();
            _videoService.DrawImage(image, position);
        }
    }
}