using System;
using System.Collections.Generic;


namespace Unit03.Game
{
    public class Jumper
    {
        /// <summany>
        /// The jumper in the parachute
        ///
        /// The responsibility of Jumper is to keep track of the parachute
        /// and delete the lines when a letter is guessed.
        /// </summary>
        private List<string> parachute = new List<string>();
        public Jumper()
        {
            parachute.Add("  ___ ");
            parachute.Add(" /   \\ ");
            parachute.Add(" \\   /");
            parachute.Add("  \\ /");
            parachute.Add("   O  ");
            parachute.Add("  /|\\\n  / \\\n\n^^^^^^^\n");
        }
        /// <summary>
        /// <return> Return the lines of the parachute and the jumper in a string form.</return>
        /// </summary>
        public string GetLines()
        {
            return String.Join("\n", parachute);
        }

        /// <summary>
        /// Delete one line of the parachute.
        /// </summary>
        public void DeleteLine()
        {
            parachute.RemoveAt(0);
            if(parachute.Count == 2)
            {
                parachute[0] = "   X  ";
            }
        }

        /// <summary>
        /// Chevk if the parachute still have lines. 
        /// </summary>
        /// <return> Return boolean value. True if the parachute still have lines.
        /// False if not.</return>
        public bool StillAlive()
        {
            if(parachute.Count == 2)
            {
                return false;
            }
            return true;
        }
    }
}
