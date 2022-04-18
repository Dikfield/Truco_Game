using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco
{
    public abstract class Players
    {

        public List<Card> Hand { get; set; }
        public List<Card> RestOfCards { get; set; }
        public Card RemovedCard { get; set; }
        public Random Random { get; set; }
        public int Position { get; init; }
        public string Team { get; set; }
        public Players(string team, int position)
        {
            Position = position;
            Team = team;
        }
        public void HandGen(Deck deck)
        {
            Hand = new List<Card>();
            RestOfCards = deck.DeckOfCards;
            for (int i = 0; i < 3; i++)
            {
                Hand.Add(deck.DeckOfCards[0]);
                RestOfCards.RemoveAt(0);
            }

        }
        public void PrintCards()
        {
            Console.WriteLine($"\nThis is the hand of the player {Position}");
            foreach(Card card in Hand)
            {
                Console.WriteLine($"{card.Name}");
            }
        }
        public void PrintRest()
        {
            Console.WriteLine($"\nThis is the rest");
            foreach (Card card in RestOfCards)
            {
                Console.WriteLine(card.Name);
            }
        }
        public virtual void CardChoice(int number)
        {
            var rnd = new Random();
            if (number == 0)
            {
                int index = rnd.Next(Hand.Count);
                PrintRandomCard(Hand[index]);
                CardRemotion(Hand[index]);
            }
            else
            {
                PrintRandomCard(Hand.OrderByDescending(q => q.Value).Last());
                CardRemotion(Hand.OrderByDescending(q => q.Value).Last());
            }
        }
        public void PrintRandomCard(Card card)
        {
            Console.WriteLine($"\nThe Player {Position} choosen card is\n{card.Name}");
        }
        public void CardRemotion(Card card)
        {
            RemovedCard = card;
            Hand.Remove(card);
        }
    }
}
