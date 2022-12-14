using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawWallAction : Action
    {
        private VideoService _videoService;
        
        public DrawWallAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> walls = cast.GetActors(Constants.WALL_GROUP);
            
            foreach (Wall wall in walls)
            {
                Body body = wall.GetBody();

                if (wall.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    _videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }

                Image image = wall.GetImage();
                Point position = body.GetPosition();
                _videoService.DrawImage(image, position);
            }
        }
    }
}