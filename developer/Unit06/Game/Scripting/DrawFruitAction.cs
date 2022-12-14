using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawFruitAction : Action
    {
        private VideoService _videoService;
        
        public DrawFruitAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> fruits =  cast.GetActors(Constants.FRUIT_GROUP);
            
            foreach (Fruit fruit in fruits)
            {
                Body body = fruit.GetBody();

                if (fruit.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    _videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }

                Image image = fruit.GetImage();
                Point position = body.GetPosition();
                _videoService.DrawImage(image, position);
            }
        }
    }
}