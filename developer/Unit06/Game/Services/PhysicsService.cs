using Unit06.Game.Casting;


namespace Unit06.Game.Services
{
    public interface PhysicsService
    {
        /// <summary>
        /// Wheter or not two bodies have collided.
        /// </summary>
        /// <param name="subject">The first body.</param>
        /// <param name="agent">The second body.</param>
        /// <returns>True if the bodies collided; false if otherwise.</param>
        bool HasCollided(Body subject, Body agent);
    }
}