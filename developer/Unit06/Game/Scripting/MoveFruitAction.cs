using Unit06.Game.Casting;

namespace Unit06.Game.Scripting
{
    public class MoveFruitAction : Action
    {
        public MoveFruitAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Fruit fruit = (Fruit)cast.GetFirstActor(Constants.FRUIT_GROUP);
            Body body = fruit.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            position = position.Add(velocity);
            body.SetPosition(position);       
        }
    }
}