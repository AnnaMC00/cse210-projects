using System;
using Microsoft.VisualBasic;
using Unit05.Game.Casting;

namespace Unit05
{
    /// <summary>
    /// <para>The responsibility of Constants is to store the variables
    /// thal will be used along the program.
    /// </para>
    /// </summary>
    public class Constants
    {
        public static int COLUMNS = 60;
        public static int ROWS = 40;
        public static int CELL_SIZE = 15;
        public static int MAX_X = 900;
        public static int MAX_Y = 600;

        public static int FRAM_RATE = 15;
        public static int FONT_SIZE = 15;
        public static string CAPTION = "Cycle";
        // public static int SNAKE_LENGTH = 8;
        
        public static Color RED = new Color(255, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color GREEN = new Color(0, 255, 0);

        public static int PLAYER1 = 1;
        public static int PLAYER2 = 2;
    }
}