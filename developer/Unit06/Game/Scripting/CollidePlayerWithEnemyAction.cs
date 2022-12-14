using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class CollidePlayerWithEnemyAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;

        public CollidePlayerWithEnemyAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor(Constants.PLAYER_GROUP);
            List<Actor> enemies = cast.GetActors(Constants.ENEMY_GROUP);
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);

            foreach (Actor actor in enemies)
            {
                Enemy enemy = (Enemy) actor;
                Body enemyBody = enemy.GetBody();
                Body playerBody = player.GetBody();

                if (_physicsService.HasCollided(enemyBody, playerBody))
                {
                    stats.RemoveLife();

                    if (stats.GetLives() > 0)
                    {
                        callback.OnNext(Constants.TRY_AGAIN);
                    }
                    else if (stats.GetLives() <= 0)
                    {
                        callback.OnNext(Constants.GAME_OVER);
                    }
                }
            }

            
        }
    }
}