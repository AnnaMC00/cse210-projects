using System;

namespace Unit03.Game
{
    /// <summary>
    /// A service that handles terminal operations.
    /// 
    /// The responsibility of a TerminalService is to provide input and output operations for the 
    /// terminal.
    /// </summary>
    public class TerminalService
    {
        
        /// <summary>
        /// Constructs a new instance of TerminalService.
        /// </summary>
        public TerminalService()
        {
        }

        /// <summary>
        /// Gets a letter input from the terminal. Directs the user with the given prompt.
        /// </summary>
        /// <param name="prompt">The given prompt.</param>
        /// <returns>Inputted letter.</returns>
        public char ReadLetter(string prompt)
        {
            Console.Write(prompt);
            return char.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Displays the given text on the terminal. 
        /// </summary>
        /// <param name="text">The given text.</param>
        public void WriteText(string text)
        {
            Console.WriteLine(text);
        }
    }
}