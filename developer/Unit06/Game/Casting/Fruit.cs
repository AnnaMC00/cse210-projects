using System;
using System.Collections.Generic;


namespace Unit06.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Fruit : Actor
    {
        private Body _body;
        private Image _image;
        private int _points;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Fruit(Body body, Image image, int points, bool debug) : base(debug)
        {
            this._body = body;
            this._image = image;
            this._points = points;
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
        public Image GetImage()
        {
            return _image;
        }

        /// <summary>
        /// Gets the points.
        /// </summary>
        /// <returns>The points.</returns>
        public int GetPoints()
        {
            return _points;
        }

        /// <summary>
        /// Change the direction of the fruit horizontally.
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
        /// Change the direction of the enemie vertically.
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