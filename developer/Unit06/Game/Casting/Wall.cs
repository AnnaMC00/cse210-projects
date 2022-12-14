namespace Unit06.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Wall : Actor
    {
        private Body _body;
        private Image _image;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Wall(Body body, Image image, bool debug) : base(debug)
        {
            this._body = body;
            this._image = image;
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <returns>The animation.</returns>
        public Image GetImage()
        {
            return _image;
        }

        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Body GetBody()
        {
            return _body;
        }        
    }
}