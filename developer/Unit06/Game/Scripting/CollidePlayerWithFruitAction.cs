using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class CollidePlayerWithFruitAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        
        public CollidePlayerWithFruitAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor(Constants.PLAYER_GROUP);
            List<Actor> fruits = cast.GetActors(Constants.FRUIT_GROUP);
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);

            foreach (Actor actor in fruits)
            {
                Fruit fruit = (Fruit)actor;
                Body fruitBody = fruit.GetBody();
                Body playerBody = player.GetBody();

                if (_physicsService.HasCollided(fruitBody, playerBody))
                {
                    int points = fruit.GetPoints();
                    stats.AddPoints(points);
                    cast.RemoveActor(Constants.FRUIT_GROUP, fruit);
                }
            }
        }
    }
}