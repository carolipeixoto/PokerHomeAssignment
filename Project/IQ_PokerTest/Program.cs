using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ_PokerTest
{
    class Program
    {
        public static string Game { get; private set; }

        static void Main(string[] args)
        {
            //This loop will control the player's hand
            do
            {
                int playersIncluded = 0;

                List<Class.HandAnalyzer> handAnalyzer = new List<Class.HandAnalyzer>();

                //Control how many players wants to be included
                Console.WriteLine("How many players do you want to include? (2~10)");
                var entry = Console.ReadLine();
               
                bool number = int.TryParse(entry, out int qtHand);

                //Control if the user included a number and the quantity allowed
                if (number == false || (qtHand < 2 ||qtHand > 10))
                {
                    Console.WriteLine("\nInvalid number. To try again press any key, to exit press ESC.");
                }
                else
                {
                    try
                    {
                        //This loop will receive and analyze each player's hand
                        do {
                            playersIncluded += 1;

                            Console.WriteLine(string.Concat("Player-", playersIncluded.ToString(), ":" ));
                            Class.HandAnalyzer PlayerHand = new Class.HandAnalyzer(Console.ReadLine());
                            handAnalyzer.Add(PlayerHand);
                        } while (playersIncluded < qtHand);

                        Console.WriteLine(Environment.NewLine);

                        //IF the user included only wrong hands
                        if (handAnalyzer.Where(c => c.qError == 0).Count() == 0)
                        {
                            Console.WriteLine("All players are disqualified.");
                        }
                        else
                            Console.WriteLine(string.Format($"The Winner(s) is/are: {WhoWin(handAnalyzer)}. With a(n) {NameOfGame(Game)}"));

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine(Environment.NewLine);

                    Console.WriteLine("\nTo play again press any key, to exit press ESC.");
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Change the value of the Game's name
        /// </summary>
        /// <param name="game"></param>
        /// <returns>string</returns>
        public static string NameOfGame(string game)
        {
            switch (game)
            {
                case "HighCard":
                    return "High Card";
                case "OnePair":
                    return "One Pair";
                case "ThreOfAKind":
                    return "Three Of A Kind";
                case "Flush":
                    return "Flush";
                default:
                    break;
            }

            return "";
        }


        /// <summary>
        /// Compare games and decide who is the winner and if had a tie
        /// </summary>
        /// <param name="handAnalyzer"></param>
        /// <returns></returns>
        public static string WhoWin(IList<Class.HandAnalyzer> handAnalyzer)
        {
            StringBuilder result = new StringBuilder();

            //Order the hands to take the biggest one and remove the players with errors
            handAnalyzer = handAnalyzer.OrderByDescending(c => c.Hand).Where(c => c.qError == 0).ToList();

            Class.HandAnalyzer win = handAnalyzer.FirstOrDefault();

            if (win.Hand == Enums.Hand.HighCard)
            {
                handAnalyzer = handAnalyzer.OrderByDescending(c => c.HighCard()).ToList();
                win = handAnalyzer.FirstOrDefault();
            }

            result.Append(win.PlayerName);
            Game = win.Hand.ToString();

            for (int i = 1; i < handAnalyzer.Count(); i++)
            {
                if (win.Hand == Enums.Hand.HighCard)
                {
                    if (handAnalyzer[i].HighCard() == win.HighCard())
                    {
                        result.AppendFormat(", {0}", handAnalyzer[i].PlayerName);
                        Game = handAnalyzer[i].Hand.ToString();
                    }
                }
                else if (handAnalyzer[i].Hand == win.Hand)
                {
                    result.AppendFormat(", {0}", handAnalyzer[i].PlayerName);
                    Game = handAnalyzer[i].Hand.ToString();
                }
                else
                {
                    break;
                }
            }

            return result.ToString();
        }
    }
}
