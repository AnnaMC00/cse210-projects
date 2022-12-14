using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class CheckOverAction : Action
    {
        public CheckOverAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> fruits = cast.GetActors(Constants.FRUIT_GROUP);
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);

            if (fruits.Count == 0)
            {
                stats.AddStage();
                if (stats.GetStage() == 0)
                {
                    stats.AddStage();
                    stats.AddLevel();
                    callback.OnNext(Constants.NEXT_LEVEL);
                }
                else
                {
                    callback.OnNext(Constants.NEXT_STAGE);
                }
            }
        }
    }
}