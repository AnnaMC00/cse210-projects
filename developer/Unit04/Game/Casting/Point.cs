using System.Collections.Generic;
namespace Unit04.Game.Casting
{
    /// <summary>
    /// <para>A distance from a relative origin (0, 0).</para>
    /// <para>
    /// The responsibility of Points is to hold and provide information about itself. Point has a few
    /// convenience methods for adding, scaling, and comparing them.
    /// </para>
    /// </summary>
    public class Point
    {
        private int _x = 0;
        private int _y = 0;

        /// <summary>
        /// Constructs a new instance of Point using the given x and y values.
        /// </summary>
        /// <param name="x">The given x value.</param>
        /// param name="y">The given y value.</param>
        public Point(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        /// <summary>
        /// Wheter or not this Point is equal to the given one.
        /// </summary>
        /// <param name="other">Ther point to compare.</param>
        /// <returns>True of both x and y are equal; false if otherwise.</returns>
        public bool Equals(Point other)
        {
            return this._x == other.GetX() && this._y == other.GetY();
        } 

        /// <summary>
        /// Gets the value of the x coordinate.
        /// </summary>
        /// <returns>The x coordinate.</returns>
        public int GetX()
        {
            return _x;
        }

        /// <summary>
        /// Gets the value of the y coordinate.
        /// </summary>
        /// <returns> The y coordinate.</returns>
        public int GetY()
        {
            return _y;
        }

        /// <summary>
        /// Scales the point by multiplying the x and y values by the provided factor.
        /// <param name ="factor">The scaling factor.</param>
        /// <returns>A scaled instance of Point.</returns>
        public Point Scale(int factor)
        {
            int x = this._x * factor;
            int y = this._y * factor;
            return new Point(x, y);
        }

        // El method Add era para generar la caida de los items. Si sumaba la posicion actual mas la velocidad lo lograba.
        // Aunque aun me pregunto como hacer que cuando se toquen los elementos no tengan que sobreponerse ne el msismo punto
        // sino en el mismo espacio.
    }
}
