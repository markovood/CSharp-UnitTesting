using System;
using System.Collections.Generic;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private bool NotAllCardsAreDifferent(IList<ICard> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                var currentCard = cards[i];
                cards.RemoveAt(i);

                if (cards.Contains(currentCard))
                {
                    return true;
                }

                cards.Insert(i, currentCard);
            }

            return false;
        }

        private int NumberOfAKind(IList<ICard> cards)
        {
            int numberOfAKind = 1;
            for (int i = 0; i < cards.Count - 1; i++)
            {
                var currentCard = cards[i];
                var nextCard = cards[i + 1];
                if (currentCard.Face == nextCard.Face)
                {
                    numberOfAKind++;
                }
            }

            return numberOfAKind;
        }

        public bool IsValidHand(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("hand");
            }

            if (hand.Cards.Count < 5 || hand.Cards.Count > 5)
            {
                throw new ApplicationException("Hand should have exactly 5 cards!");
            }

            if (hand.Cards.Count == 5)
            {
                if (NotAllCardsAreDifferent(hand.Cards))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("hand");
            }

            if (hand.Cards.Count < 5 || hand.Cards.Count > 5)
            {
                throw new ApplicationException("Hand should have exactly 5 cards!");
            }

            if (NumberOfAKind(hand.Cards) < 4)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("hand");
            }

            if (hand.Cards.Count < 5 || hand.Cards.Count > 5)
            {
                throw new ApplicationException("Hand should have exactly 5 cards!");
            }

            if (hand.Cards.Count == 5)
            {
                for (int i = 0; i < hand.Cards.Count - 1; i++)
                {
                    var currentCard = hand.Cards[i];
                    var nextCard = hand.Cards[i + 1];
                    if (currentCard.Suit != nextCard.Suit)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
