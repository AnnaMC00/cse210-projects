using System.Collections.Generic;
using Unit06.Game.Casting;

namespace Unit06.Game.Scripting
{
    public class MoveEnemyAction : Action
    {
        public MoveEnemyAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> enemies = cast.GetActors(Constants.ENEMY_GROUP);
            foreach (Enemy enemy in enemies)
            {
                Body body = enemy.GetBody();
                Point position = body.GetPosition();
                Point velocity = body.GetVelocity();
                position = position.Add(velocity);
                body.SetPosition(position);  
            }     
        }
    }
}