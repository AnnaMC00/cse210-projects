namespace Unit06.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Player : Actor
    {
        private Body _body;
        private Animation _animation;

        /// <summary>
        /// Constructs a new instance of Player.
        /// </summary>
        public Player(Body body, Animation animation, bool debug) : base(debug)
        {
            this._body = body;
            this._animation = animation;
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
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Body GetBody()
        {
            return _body;
        }

        /// <summary>
        /// Moves the Player to its next position.
        /// </summary>
        public void MoveNext()
        {
            Point position = _body.GetPosition();
            Point velocity = _body.GetVelocity();
            Point newPosition = position.Add(velocity);
            _body.SetPosition(newPosition);
        }

        /// <summary>
        /// Moves the player to the left.
        /// </summary>
        public void MoveLeft()
        {
            Point velocity = new Point(-Constants.PLAYER_VELOCITY, 0);
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Moves the player to the right.
        /// </summary>
        public void MoveRight()
        {
            Point velocity = new Point(Constants.PLAYER_VELOCITY, 0);
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Moves the player up.
        /// </summary>
        public void MoveUp()
        {
            Point velocity = new Point(0, -Constants.PLAYER_VELOCITY);
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Moves the player down.
        /// </summary>
        public void MoveDown()
        {
            Point velocity = new Point(0, Constants.PLAYER_VELOCITY);
            _body.SetVelocity(velocity);
        }

        /// <summary>
        /// Stops the player from moving.
        /// </summary>
        public void StopMoving()
        {
            Point velocity = new Point(0, 0);
            _body.SetVelocity(velocity);
        }
    }
}