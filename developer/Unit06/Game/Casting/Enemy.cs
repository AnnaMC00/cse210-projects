using System;
using System.Collections.Generic;


namespace Unit06.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Enemy : Actor
    {

        private Body _body;
        private Animation _animation;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Enemy(Body body, Animation animation, bool debug) : base(debug)
        {
            this._body = body;
            this._animation = animation;
        }

        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Body GetBody()
        {
            return _body;
        }

        /// <summary>
        /// Gets the animation.
        /// </summary>
        /// <returns>The animation.</returns>
        public Animation GetAnimation()
        {
            return _animation;
        }

        /// <summary>
        /// Change the direction of the enemy horizontally.
        /// </summary>
        public void ChangeDirectionX()
        {
            Point velocity = _body.GetVelocity();
            int vx = velocity.GetX() * -1;
            int vy = velocity.GetY();
            Point newVelocity = new Point(vx, vy);
            _body.SetVelocity(newVelocity);
        }

        /// <summary>
        /// Change the direction of the enemy vertically.
        /// </summary>
        public void ChangeDirectionY()
        {
            Point velocity = _body.GetVelocity();
            int vx = velocity.GetX();
            int vy = velocity.GetY() * -1;
            Point newVelocity = new Point(vx, vy);
            _body.SetVelocity(newVelocity);
        }
    }
}