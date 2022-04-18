using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco
{
    public class Engine
    {
        public int Round { get; set; }
        public int TeamARoundPoints { get; set; }
        public int TeamBRoundPoints { get; set; }
        public int TeamAGamePoints { get; set; }
        public int TeamBGamePoints { get; set; }
        public Deck Deck { get; set; }
        public Player1 Player1 { get; set; }
        public Player2 Player2 { get; set; }
        public Player3 Player3 { get; set; }
        public Player4 Player4 { get; set; }

        public Engine()
        {
            Deck = new Deck();
            Player1 = new Player1();
            Player2 = new Player2();
            Player3 = new Player3();
            Player4 = new Player4();
            Deck.Shuffle();
            GivePlayersCards();
            PrintPlayersCards();
            BattleLoop();
            TeamsPontuationPrint();


        }
        
        private void GivePlayersCards()
        {

            Player1.HandGen(Deck);
            Player2.HandGen(Deck);
            Player3.HandGen(Deck);
            Player4.HandGen(Deck);
        }
        private void PrintPlayersCards()
        {
            Player1.PrintCards();

        }
        private void PlayingCards()
        {
            var rnd = new Random();
            int starts = rnd.Next(1, 5);// Random, who starts
            Console.WriteLine("\nThe round starts----------------------------");
            if (Round == 0)
            {
                if (starts == 1)
                {
                    Player1.CardChoice(0);
                    Player2.CardChoice(0);
                    if (Player1.RemovedCard.Value >= Player2.RemovedCard.Value)
                    {
                        Player3.CardChoice(1);
                    }
                    else
                        Player3.CardChoice(0);
                    Player4.CardChoice(1);
                }
                else if (starts == 2)
                {
                    Player2.CardChoice(0);
                    Player3.CardChoice(0);
                    Player4.CardChoice(1);
                    Player1.CardChoice(0);
                }
                else if (starts == 3)
                {
                    Player3.CardChoice(0);
                    Player4.CardChoice(0);
                    Player1.CardChoice(0);
                    Player2.CardChoice(1);
                }
                else if (starts == 4)
                {
                    Player4.CardChoice(0);
                    Player1.CardChoice(0);
                    Player2.CardChoice(1);
                    if (Player1.RemovedCard.Value >= Player2.RemovedCard.Value && Player1.RemovedCard.Value >= Player4.RemovedCard.Value)
                    {
                        Player3.CardChoice(1);
                    }
                    else
                        Player3.CardChoice(0);
                }
            }
            else // The winner of last round starts here
            {
                if(Player1.RemovedCard.Value >= Player2.RemovedCard.Value && Player1.RemovedCard.Value >= Player3.RemovedCard.Value 
                    && Player1.RemovedCard.Value >= Player4.RemovedCard.Value)
                {
                    Player1.CardChoice(0);
                    Player2.CardChoice(0);
                    if (Player1.RemovedCard.Value >= Player2.RemovedCard.Value)
                    {
                        Player3.CardChoice(1);
                    }
                    else
                        Player3.CardChoice(0);

                    Player4.CardChoice(1);
                }
                else if(Player2.RemovedCard.Value >= Player3.RemovedCard.Value && Player2.RemovedCard.Value >= Player4.RemovedCard.Value
                    && Player2.RemovedCard.Value >= Player1.RemovedCard.Value)
                {
                    Player2.CardChoice(0);
                    Player3.CardChoice(0);
                    Player4.CardChoice(1);
                    Player1.CardChoice(0);
                }
                else if (Player3.RemovedCard.Value >= Player4.RemovedCard.Value && Player3.RemovedCard.Value >= Player1.RemovedCard.Value
                    && Player3.RemovedCard.Value >= Player2.RemovedCard.Value)
                {
                    Player3.CardChoice(0);
                    Player4.CardChoice(0);
                    Player1.CardChoice(0);
                    Player2.CardChoice(1);
                }
                else if (Player4.RemovedCard.Value >= Player1.RemovedCard.Value && Player4.RemovedCard.Value >= Player2.RemovedCard.Value
                    && Player4.RemovedCard.Value >= Player3.RemovedCard.Value)
                {
                    Player4.CardChoice(0);
                    Player1.CardChoice(0);
                    Player2.CardChoice(1);
                    if (Player1.RemovedCard.Value >= Player2.RemovedCard.Value && Player1.RemovedCard.Value >= Player4.RemovedCard.Value)
                    {
                        Player3.CardChoice(1);
                    }
                    else
                        Player3.CardChoice(0);
                }
            }
        }
        public void WinningSystem()
        {
            if (Player1.RemovedCard.Value >= Player2.RemovedCard.Value && Player1.RemovedCard.Value >= Player4.RemovedCard.Value ||
                Player3.RemovedCard.Value >= Player2.RemovedCard.Value && Player3.RemovedCard.Value >= Player4.RemovedCard.Value)
                Console.WriteLine($"\nTeam A won the Round {++Round} \n------------------------------\n", TeamARoundPoints++);
            else
                Console.WriteLine($"\nTeam B won the Round {++Round} \n------------------------------\n", TeamBRoundPoints++);
        }
        public void BattleLoop()
        {
            while (Player1.Hand.Count > 0 && TeamARoundPoints < 2 || TeamBRoundPoints < 2 && Player2.Hand.Count > 0)
            {
                if (TeamARoundPoints < 2 && TeamBRoundPoints < 2)
                {
                    PlayingCards();
                    WinningSystem();
                    if (Player1.Hand.Count > 0)
                    {
                        PrintPlayersCards();
                    }
                    if (TeamARoundPoints >= 2 || TeamBRoundPoints >= 2)
                    {
                        if (TeamARoundPoints > TeamBRoundPoints)
                        {
                            Console.WriteLine("\nTeam A won this match\n", TeamAGamePoints += 2);
                        }
                        else
                            Console.WriteLine("\nTeam B won this match\n", TeamBGamePoints += 2);
                    }
                }

            }

        }
        public void TeamsPontuationPrint()
        {
            Console.WriteLine($"Team A has {TeamAGamePoints}");
            Console.WriteLine($"Team B has {TeamBGamePoints}");
        }
    }
}
