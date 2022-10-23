using System;
using System.Collections.Generic;

namespace Unit03.Game
{
    /// <summany>
    /// The person in charge of everithing related to the word to guess
    ///
    /// The responsibility of GuessWord is to choose the word to guess and to change every line
    /// with the guessed letter.
    /// </summary>
    public class GuessWord
    {
        private List<string> words = new List<string>();
        private char[] word;
        private char[] spaces;

        /// <summary>
        /// Constructs a new instance of GuessWord.
        /// </summary>
        public GuessWord()
        {
            words.Add("class");
            words.Add("temple");
            words.Add("computer");
            words.Add("church");
            words.Add("chocolate");
            words.Add("music");
            words.Add("piano");
            words.Add("code");
            GetWordList();

            spaces = new char[word.Length];
            for(int i = 0; i < (word.Length); ++i)
            {
                spaces[i] = '_';
            }
        }

        /// <summary>
        /// Get the word from the words list and break it into a list so every letter is a char value.
        /// </summary>
        private void GetWordList()
        {
            Random random = new Random();
            int index = random.Next(words.Count);

            string wordindex = words[index];
            char[] listletters = wordindex.ToCharArray();
            word = listletters;
        }

        /// <summary>
        /// Change the line with its corresponding letter.
        /// </summary>
        /// <param name="letter"> The guessed letter </param> 
        /// <return> Return boolean value. True if the guessed letter was found in the word, and false if not.</return>
        public bool ChangeLineWithLetter(char letter)
        {
            bool change = false;
            for(int i = 0; i < (word.Length); ++i)
            {
                if(word[i] == letter)
                {
                    spaces[i] = letter;
                    change = true;
                }
            }
            return change;
        }
        
        /// <summary>
        /// <return> Return the list of lines in a string form.</return>
        /// </summary>
        public string GetSpaces()
        {
            return String.Join(" ", spaces);
        }

        /// <summary>
        /// Compares the choosen word with the list of guessed letter.
        /// </summary>
        /// <return> Return boolean value. True if the choosen word is equal to the guessed word
        /// (if every line was changed to its corresponding letter)
        /// False if the word was guessed incorrectly.</return>
        public bool WordGuessed()
        {
            string wordString = String.Join("", word);
            string spacesString = String.Join("", spaces);
            if(spacesString == wordString)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the word list converted to string.
        /// </summary>
        public string GetWord()
        {
            return String.Join("", word);
        }
    }
}