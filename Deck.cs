using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco
{
    public class Deck
    {
        readonly int[] Numbers = { 2, 3, 4, 5, 6, 7, 11, 12, 13, 14 };
        readonly string[] Suits = { "Hearts", "Clubs", "Diamonds", "Spades" };
        public List<Card> DeckOfCards { get; set; }

        public Deck()
        {
            DeckOfCards = new List<Card>();

            foreach (int numbers in Numbers)
            {
                foreach (string suits in Suits)
                {
                    DeckOfCards.Add(new Card ( false, suits, numbers ));
                }
            }
        }
        public void Shuffle()
        {
            var rnd = new Random();
            DeckOfCards = DeckOfCards.OrderBy(q => rnd.Next(DateTime.Now.Day)).ToList();
        }
        public void PrintDeck()
        {
            Console.WriteLine($"\nThis is the Deck");
            foreach (Card card in DeckOfCards)
            {
                Console.WriteLine(card.Name);
            }
        }
    }
}
