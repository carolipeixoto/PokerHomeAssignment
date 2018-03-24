using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQ_PokerTest
{
    public class Enums
    {
        /// <summary>
        /// Flush: Five cards of the same suit
        /// Three of a kind: Three cards of the same rank
        /// One pair: Two cards of the same rank
        /// High card: If no one has one pair or a better hand, the highest card wins
        ///It is ascending - worst to best 
        /// </summary>
        public enum Hand
        {
            HighCard,
            OnePair,
            ThreOfAKind,
            Flush
        }

        /// <summary>
        ///  The possible ranks are 2, 3, 4, 5, 6, 7, 8, 9,10, Jack (J),
        ///Queen(Q), King(K), and Ace(A).
        ///It is ascending - worst to highest
        /// </summary>
        public enum CardList
        {
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace
        }
        
        /// <summary>
        ///The possible suits are hearts(H), 
        ///clubs(C), spades(S), and diamonds(D). 
        /// </summary>
        public enum SuitValues
        {
            Hearts,
            Clubs,
            Spades,
            Diamonds
        }
    }


}
