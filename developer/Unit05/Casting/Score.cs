using System;


namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>
    /// The responsibility of Score is to keep track of the points that each player won.
    /// </para>
    /// </summary>
    public class Score : Actor
    {
        private int _points = 0;

        /// <summary>
        /// Constructs a new instance of an Score.
        /// </summary>
        public Score(int playerNumber, Point position)
        {
            this._position = position;
            this._playerNumber = playerNumber;
            AddPoints(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            this._points += points;
            SetText($"Score: {this._points}");
        }
    }
}