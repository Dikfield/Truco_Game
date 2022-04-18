using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco
{
    public class Player1 : Players
    {
        public Player1():base("A", 1)
        {

        }

        public override void CardChoice(int number)
        {
            if (Hand.Count ==3)
            {
                Console.WriteLine($"\nChoose a card,\n\nfor Card {Hand[0].Name} select: 1,\nfor Card {Hand[1].Name} select:2,\nfor Card {Hand[2].Name} select 3");
            }
            else if (Hand.Count ==2)
            {
                Console.WriteLine($"\nChoose a card,\n\nfor Card {Hand[0].Name} select: 1,\nfor Card {Hand[1].Name} select:2");
            }
            else
            {
                Console.WriteLine($"\nChoose a card,\n\nfor Card {Hand[0].Name} select: 1");
            }
            
            switch (Console.ReadLine())
            {
                case "1":
                    PrintRandomCard(Hand[0]);
                    CardRemotion(Hand[0]);
                    break;

                case "2":
                    PrintRandomCard(Hand[1]);
                    CardRemotion(Hand[1]);
                    break;

                case "3":
                    PrintRandomCard(Hand[2]);
                    CardRemotion(Hand[2]);
                    break;

            };
        }
    }
}
