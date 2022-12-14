using System.Collections.Generic;
using System;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class CollideFruitWithWallAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        
        public CollideFruitWithWallAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> walls = cast.GetActors(Constants.WALL_GROUP);
            List<Actor> fruits = cast.GetActors(Constants.FRUIT_GROUP);
            
            foreach (Actor actor1 in walls)
            {
                Wall wall = (Wall)actor1;
                Body wallBody = wall.GetBody();
                
                foreach (Actor actor2 in fruits)
                {
                    Fruit fruit = (Fruit)actor2;
                    Body fruitBody = fruit.GetBody();
                    
                    if (_physicsService.HasCollided(wallBody, fruitBody))
                    {
                        Random random = new Random();
                        int i = random.Next(1, 3);

                        if (i == 1)
                        {
                            fruit.ChangeDirectionY();
                        }
                        else if (i == 2)
                        {
                            fruit.ChangeDirectionX();
                        }
                    }
                }
            }
        }
    }
}