using System;
using System.Collections.Generic;


namespace Unit02.Game
{
    /// <summary>
    /// A person who make the pack of cards and mix it.
    ///
    /// The responsibility of the CardPack is to manage an actual pack with
    /// 52 cards so a card doenst get repited. 
    /// </summary>
    public class CardPack
    {
        public int card = 0;
        public List<int> pack = new List<int>();

        /// <summary>
        /// Construct a new instance of CardPack. 
        /// </summary>
        public CardPack()
        {
            for (int i = 0; i < 4; i++)
            {
                for(int c = 1; c < 14; c++)
                {
                    pack.Add(c);
                }
            }
        }

        /// <summary>
        /// Choose and remove the card from the pack. 
        /// </summary>
        public int GetCard()
        {
            Random random = new Random();
            int index = random.Next(pack.Count);
            card = pack[index];
            pack.RemoveAt(index);

            return card;
        }
    }
}