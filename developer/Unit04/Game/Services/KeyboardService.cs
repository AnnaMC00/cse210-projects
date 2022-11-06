using Raylib_cs;
using Unit04.Game.Casting;


namespace Unit04.Game.Services
{
    /// <summary>
    /// <para> Detects player input.</para>
    /// <para>
    /// The responsibility of KeyboardService is to detect player key presses and translate them
    /// into a point representing a direction.
    /// </para>
    /// </summary>
    public class KeyboardService
    {
        private int _cellSize = 15;

        /// <summary>
        /// Constructs a new instance of Keyboardservice using the given cell size.
        /// </summary>
        /// <param name="cellSize">The cell Size (in pixels).</param>
        public KeyboardService(int cellSize)
        {
            this._cellSize = cellSize;
        }

        /// <summary>
        /// Gets the selected direction based on the currently pressed key.
        /// </summary>
        /// <returns>The direction as an instance of Point.</returns>
        public Point GetDirection()
        {
            int dx = 0;
            
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                dx = -1;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                dx = 1;
            }

            Point direction = new Point(dx, 0);
            direction = direction.Scale(_cellSize);

            return direction;
        }
    }
}