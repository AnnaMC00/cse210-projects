using System;


namespace Unit02.Game
{
    /// <summany>
    /// A person who directs the game.
    ///
    /// The responsibility of Director is to control the sequence of the play.
    /// </summary>
    public class Director
    {
        int score = 300;
        bool isPlaying = true;
        CardPack cardPack = new CardPack();
        int card = 0;
        int newCard = 0;
        string higherOrLower = "";
        bool correctIncorrect = true; /// true = correct / false = incorrect
        bool sameCard = false;

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
            card = cardPack.GetCard();
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            Console.WriteLine("\nWelcome to the Hilo game!\nRules are simple:\nI will show you a card, you need to guess if the next one is higher or lower.\nYou will have 100 points if you guess correctly and you will lose 75 if you guess incorrectly.\n\nLet's start!");

            while (isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();

            }
            Console.WriteLine("Thank you for playing!\n");
        }

        /// <summary>
        /// Shows the first card to the user and ask if they want to guess.
        /// </summary>
        public void GetInputs()
        {
            Console.Write("This is the card: ");
            Console.WriteLine(card);

            bool answer = false;
            do
            {
                Console.Write("\nGuess next card? [y/n] ");
                string guessNext = Console.ReadLine();
                if (guessNext == "y" || guessNext == "n")
                {
                    isPlaying = (guessNext == "y");
                    answer = true;
                }
                else
                {
                    Console.WriteLine("Please choose a correct answer.");
                }
            } while (!answer);

            if (!isPlaying)
            {
                return;
            }

            answer = false;
            do
            {
                Console.Write("Guess! Higher or Lower? [h/l] ");
                higherOrLower = Console.ReadLine();
                if (higherOrLower == "h" || higherOrLower == "l")
                {
                    answer = true;
                }
                else
                {
                    Console.WriteLine("Please choose a correct answer.\n");
                }
            } while (!answer);
        }

        /// <summary>
        /// Analize the answer given depending the next card and updates the score.
        /// </summary>
        public void DoUpdates()
        {
            if (!isPlaying)
            {
                return;
            }

            newCard = cardPack.GetCard();
            if (card < newCard && higherOrLower == "h") /// CORRECT
            {
                score += 100;
                correctIncorrect = true;
            }
            else if (card > newCard && higherOrLower == "l") /// CORRECT
            {
                score += 100;
                correctIncorrect = true;
            }
            else if (card == newCard) /// SAME CARD
            {
                sameCard = true;
            }
            else /// INCORRECTS
            {
                score -= 75;
                correctIncorrect = false;
            }
        }

        /// <summary>
        /// Display the new card, if the player guessed correctly or not and the score. 
        /// </summary>
        public void DoOutputs()
        {
            if (!isPlaying)
            {
                return;
            }

            Console.WriteLine($"New Card: {newCard}\n");

            if (sameCard)
            {
                Console.WriteLine("It was the same card! No points!!");
            }
            else
            {
                if (correctIncorrect)
                {
                Console.WriteLine("You guessed correctly!");
                }
                else
                {
                Console.WriteLine("You guessed incorrectly!");
                }
            }
            
            card = newCard;
            sameCard = false;

            if (cardPack.pack.Count != 0 && score > 0)
            {
                isPlaying = true;
            }
            else
            {
                isPlaying = false;
                if (cardPack.pack.Count == 0)
                {
                    Console.WriteLine("\nThere is no more cards in the pack!\nYou win!");
                }
            }
            Console.WriteLine($"\nYour score: {score}");
        }
    }
}