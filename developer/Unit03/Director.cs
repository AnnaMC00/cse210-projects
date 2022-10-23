namespace Unit03.Game
{
    /// <summany>
    /// A person who directs the game.
    ///
    /// The responsibility of Director is to control the sequence of the play.
    /// </summary>
    public class Director
    {
        private Jumper jumper = new Jumper();
        private GuessWord guessWord = new GuessWord();
        private TerminalService terminalService = new TerminalService();
        private bool isPlaying = true;
        private char letter;

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            while (isPlaying)
            {
                DoOutputs();
                GetInputs();
                DoUpdates();
            }
        }

        /// <summary>
        /// Display the updated parachute and the lines of the word to guess. Also keep track
        /// if the word was guessed or if the jumper is still alive.
        /// </summary>
        private void DoOutputs()
        {
            terminalService.WriteText($"\n{guessWord.GetSpaces()}\n");
            terminalService.WriteText(jumper.GetLines()); // print the parachute.....
            // add messages like you lost a line or you guess a letter
            if(!jumper.StillAlive())
            {
                terminalService.WriteText($"The word was \"{guessWord.GetWord()}\"\nGood luck next time!\n");
                isPlaying = false;
                return;
            }
            else if(guessWord.WordGuessed())
            {
                terminalService.WriteText("\nYou did it!\nThanks for playing!\n");
                isPlaying = false;
                return;
            }
        }

        /// <summary>
        /// Ask the user to guess a letter.
        /// </summary>
        private void GetInputs()
        {
            if(!isPlaying)
            {
                return;
            }
            
            letter = terminalService.ReadLetter("Guess a letter [a-z]: ");

        }

        /// <summary>
        /// Analize the letter given and if is guessed incorrectly it will delete a line from the parachute.
        /// </summary>
           private void DoUpdates()
        {
            if(!isPlaying)
            {
                return;
            }
            bool letterfound = guessWord.ChangeLineWithLetter(letter);

            if(!letterfound)
            {
                jumper.DeleteLine();
            }
        }
    }
}