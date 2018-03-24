using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ_PokerTest.Class
{
    public class Card
    {
        //It controls the cards and suits received
        public Card(string card)
        {
            //remove any space
            card = card.Trim();

            try
            {
                Dictionary<string, Enums.CardList> cardMatch = new Dictionary<string, Enums.CardList>()
                {
                    ["2"] = Enums.CardList.Two,
                    ["3"] = Enums.CardList.Three,
                    ["4"] = Enums.CardList.Four,
                    ["5"] = Enums.CardList.Five,
                    ["6"] = Enums.CardList.Six,
                    ["7"] = Enums.CardList.Seven,
                    ["8"] = Enums.CardList.Eight,
                    ["9"] = Enums.CardList.Nine,
                    ["10"] = Enums.CardList.Ten,
                    ["J"] = Enums.CardList.Jack,
                    ["Q"] = Enums.CardList.Queen,
                    ["K"] = Enums.CardList.King,
                    ["A"] = Enums.CardList.Ace,
                };

                if(card.Length == 3)
                    CardMatched = cardMatch[card.Substring(0, 2).ToUpper()];
                else
                    CardMatched = cardMatch[card.Substring(0, 1).ToUpper()];

                Dictionary<string, Enums.SuitValues> suitMatch = new Dictionary<string, Enums.SuitValues>()
                {
                    ["H"] = Enums.SuitValues.Hearts,
                    ["C"] = Enums.SuitValues.Clubs,
                    ["S"] = Enums.SuitValues.Spades,
                    ["D"] = Enums.SuitValues.Diamonds
                };

                if (card.Length == 3)
                    SuitMatched = suitMatch[card.Substring(2, 1).ToUpper()];
                else
                    SuitMatched = suitMatch[card.Substring(1, 1).ToUpper()];
            }
            catch (Exception)
            {
                HandAnalyzer.cardError = true;
            }
        }

        public Enums.CardList CardMatched { get; set; }
        public Enums.SuitValues SuitMatched { get; set; }
    }
}
