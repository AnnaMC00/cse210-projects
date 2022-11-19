using System;


namespace Unit04.Game.Casting
{
    /// <summary>
    /// The value of the actor.
    /// The responsibility of the Score class is to give each actor
    /// their respective values.
    /// </summary>
    public class RocksAndDiamonds : Actor
    {
        Random random = new Random();
        private int _scorePoint;

        /// <summary>
        /// Constructs a new instance of ScorePoints.
        /// </summary>
        public RocksAndDiamonds()
        {
            _scorePoint = 0;
        }

        /// <summary>
        /// Get a random * or O.
        /// </summary>
        /// <returns>The item.</returns>
        public string RandomRockOrDiamond()
        {
            string[] r_d = {"*", "O"};
            int arrayIndex = random.Next(0, 2);
            string item = r_d[arrayIndex];

            SetScorePoint(item);

            return item;
        }

        /// <summary>
        /// Gives the item its corresponding score.
        /// </summary>
        /// <param name="item">Item</param>
        public void SetScorePoint(string item)
        {
            if (item == "*")
            {
                _scorePoint = 10;
            }
            if (item == "O")
            {
                _scorePoint = -10;
            }

        }

        public Point StartPosition(int maxX, int maxY, int cellSize)
        {
            int x = random.Next(maxX); // aca podria haberse usado columnas, la manera en la que lo hize da puntos que no se mostraran en la pantalla
            Point position = new Point(x, 0);
            position = position.Scale(cellSize);

            return position;
        }

        /// <summary>
        /// Makes the item to fall.
        /// </summary>
        /// <param name="actualPosition">Actual position of the item</param>
        /// <returns>A new point witht the new position</returns>
        public Point ItemFall(Point actualPosition)
        {
            int y = actualPosition.GetY();
            y += 5;
            Point position = new Point(actualPosition.GetX(), y);
            return position;
        }

        /// <summary>
        /// Get a random color.
        /// </summary>
        /// <returns>A random color.</returns>
        public Color RandomColor()
        {
            int r = random.Next(0, 256);
            int g = random.Next(0, 256);
            int b = random.Next(0, 256);
            Color color = new Color(r, g, b);

            return color;
        }

        /// <summary>
        /// Gets the scorePoint.
        /// </summary>
        /// <returns>The scorePoint as a int.</returns>
        public int GetScorePoint()
        {
            return _scorePoint;
        }
    }
}