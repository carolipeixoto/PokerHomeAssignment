using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ_PokerTest.Class
{
    /// <summary>
    /// Class to Analyze each player's hand
    /// </summary>
    public class HandAnalyzer
    {
        public static bool cardError;
        public string PlayerName { get; private set; }
        public IList<Card> Cards { get; private set; }

        public HandAnalyzer(string playerHand)
        {
            qError = 0;
            cardError = false;
            this.Cards = new List<Card>();

            //Convert in array the value received
            string[] arrayCards = playerHand.Split(',');

            //First position will be the Player's Name
            PlayerName = arrayCards[0];

            if (arrayCards.Count() != 6)
            {
                
                qError += 1;
            }

            foreach (var item in arrayCards.Skip(1))
            {
                Cards.Add(new Card(item));
            }

            Cards.OrderBy(c => c.CardMatched);

            //Determine if the hand had a error, if so, will desconsider this hand
            if (cardError || qError>0)
            {
                qError += 1;
                Console.WriteLine("Invalid format, this player will be excluded.");
            }

            CheckHand();
        }

        //Make the analysis of Games
        private void CheckHand()
        {
            if (Flush())
                Hand = Enums.Hand.Flush;
            else if (ThreOfAKind())
                Hand = Enums.Hand.ThreOfAKind;
            else if (OnePair())
                Hand = Enums.Hand.OnePair;
            else
                Hand = Enums.Hand.HighCard;
        }

        //Five cards if the same suit
        private bool Flush()
        {
            return Cards.GroupBy(c => c.SuitMatched).Count() == 1 ? true : false;
        }

        //Three cards of the same rank
        private bool ThreOfAKind()
        {
            return Cards.GroupBy(c => c.CardMatched).Count(group => group.Count() == 3) == 1 ? true : false;
        }

        //Twor cards of the same rank
        private bool OnePair()
        {
            return Cards.GroupBy(c => c.CardMatched).Count(group => group.Count() == 2) == 1 ? true : false;
        }

        //If no one has one pair or a better hand, the highest card wins
        public Enums.CardList HighCard()
        {
            return Cards.Max(c => c.CardMatched);
        }
        public Enums.Hand Hand { get; set; }
        public int qError { get; set; }
    }
}
