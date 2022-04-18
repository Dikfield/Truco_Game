using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco
{
    public class Card
    {
        public bool Isturned { get; set; }
        public string Suit { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int Value { get; set; }



        public Card(bool isTurned,string suit, int number)
        {

            Isturned = isTurned;
            Number = number;
            int value = CardValueGen(number, suit);
            Value = value;
            Suit = suit;
            string name = CardNameGen() + " " + "of"+ " " + Suit;
            Name = name;
        }
        private string CardNameGen()
        {
            switch (Number)
            {
                case < 11:
                    return Number.ToString();
                case 11:
                    return "Jack";
                case 12:
                    return "Queen";
                case 13:
                    return "King";
                case 14:
                    return "Ace";
            }
            return null;
        }
        private int CardValueGen(int number, string suit)
        {
            switch (number)
            {
                case 2:
                    return 40;
                case 3:
                    return 50;
                case 4:
                    if (suit == "Clubs") 
                    {
                        return 100;
                    }
                    return 1;
                case 5:
                    return 2;
                case 6:
                    return 3;
                case 7:
                    if (suit == "Hearts")
                    {
                        return 90;
                    }
                    else if (suit == "Diamonds")
                    {
                        return 70;
                    }
                    return 4;
                case 11:
                    return 5;
                case 12:
                    return 6;
                case 13:
                    return 7;
                case 14:
                    if(suit == "Spades")
                    {
                        return 80;
                    }
                    return 8;
            }
            return 0;
        }
    }
}
