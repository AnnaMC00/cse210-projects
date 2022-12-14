using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class CollideEnemyWithWallAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        
        public CollideEnemyWithWallAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> walls = cast.GetActors(Constants.WALL_GROUP);
            List<Actor> enemies = cast.GetActors(Constants.ENEMY_GROUP);
                        
            foreach (Actor actor1 in walls)
            {
                Wall wall = (Wall)actor1;
                Body wallBody = wall.GetBody();
                
                foreach (Actor actor2 in enemies)
                {
                    Enemy enemy = (Enemy)actor2;
                    Body enemyBody = enemy.GetBody();
                    
                    if (_physicsService.HasCollided(wallBody, enemyBody))
                    {
                        Point velocity = enemyBody.GetVelocity();
                        int vx = velocity.GetX();
                        int vy = velocity.GetY();

                        if (vx == 0)
                        {
                            enemy.ChangeDirectionY();
                        }
                        else if (vy == 0)
                        {
                            enemy.ChangeDirectionX();
                        }
                    }
                }
            }
        }
    }
}