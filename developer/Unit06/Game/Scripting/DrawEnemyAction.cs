using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawEnemyAction : Action
    {
        private VideoService _videoService;
        
        public DrawEnemyAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> enemies = cast.GetActors(Constants.ENEMY_GROUP);

            foreach (Enemy enemy in enemies)
            {
                Body body = enemy.GetBody();

                if (enemy.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    _videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }

                Animation animation = enemy.GetAnimation();
                Image image = animation.NextImage();
                Point position = body.GetPosition();
                _videoService.DrawImage(image, position);
            }
        }
    }
}