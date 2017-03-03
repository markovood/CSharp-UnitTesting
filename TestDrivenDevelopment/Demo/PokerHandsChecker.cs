using System;
using System.Collections.Generic;
using System.Linq;

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

        private int NumberOfAKind(ref IList<ICard> cards)
        {
            // keep the sorting
            cards = cards.OrderByDescending(c => c.Face).ToList();

            int numberOfAKind = 1;
            int maxNumberOfAKind = 1;
            for (int i = 0; i < cards.Count - 1; i++)
            {
                var currentCard = cards[i];
                var nextCard = cards[i + 1];
                if (currentCard.Face == nextCard.Face)
                {
                    numberOfAKind++;
                    if (numberOfAKind > maxNumberOfAKind)
                    {
                        maxNumberOfAKind = numberOfAKind;
                    }
                }
                else
                {
                    numberOfAKind = 1;
                }
            }

            return maxNumberOfAKind;
        }

        private void RemovePair(IList<ICard> cards)
        {
            for (int i = 0; i < cards.Count - 1; i++)
            {
                var currentCard = cards[i];
                var nextCard = cards[i + 1];
                if (currentCard.Face == nextCard.Face)
                {
                    cards.Remove(currentCard);
                    cards.Remove(nextCard);
                    break;
                }
            }
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
            if (hand == null)
            {
                throw new ArgumentNullException("hand");
            }

            if (hand.Cards.Count < 5 || hand.Cards.Count > 5)
            {
                throw new ApplicationException("Hand should have exactly 5 cards!");
            }
            
            var cards = hand.Cards;
            if (NumberOfAKind(ref cards) == 1)
            {
                for (int i = 0; i < cards.Count - 1; i++)
                {
                    var currentCard = cards[i];
                    var nextCard = cards[i + 1];
                    if (Math.Abs(currentCard.Face - nextCard.Face) != 1) return false;
                }

                // check that all cards are same suit
                var cardSuit = cards[0].Suit;
                bool areSameSuit = cards.All(c => c.Suit == cardSuit);

                return areSameSuit;
            }
            else return false;
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

            var cards = hand.Cards;
            if (NumberOfAKind(ref cards) == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFullHouse(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("hand");
            }

            if (hand.Cards.Count < 5 || hand.Cards.Count > 5)
            {
                throw new ApplicationException("Hand should have exactly 5 cards!");
            }

            var cards = hand.Cards;
            if (NumberOfAKind(ref cards) == 3)
            {
                // remove the three of a kind
                for (int i = 0; i < cards.Count - 2; i++)
                {
                    var currentCard = cards[i];
                    var nextCard = cards[i + 1];
                    var nextOfTheNext = cards[i + 2];
                    if (currentCard.Face == nextCard.Face && nextCard.Face == nextOfTheNext.Face)
                    {
                        cards.Remove(currentCard);
                        cards.Remove(nextCard);
                        cards.Remove(nextOfTheNext);
                        break;
                    }
                }

                // check if the rest are different, N.B. there are only 2 cards left
                if (cards[0].Face == cards[1].Face) return true;
                else return false;
            }
            else return false;
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
            if (hand == null)
            {
                throw new ArgumentNullException("hand");
            }

            if (hand.Cards.Count < 5 || hand.Cards.Count > 5)
            {
                throw new ApplicationException("Hand should have exactly 5 cards!");
            }

            var cards = hand.Cards;
            if (NumberOfAKind(ref cards) == 1)
            {
                for (int i = 0; i < cards.Count - 1; i++)
                {
                    var currentCard = cards[i];
                    var nextCard = cards[i + 1];
                    if (Math.Abs(currentCard.Face - nextCard.Face) != 1) return false;
                }

                // check that there is at least one card with different suit
                var cardSuit = cards[0].Suit;
                bool hasOneCardWithDiffSuit = cards.Any(c => c.Suit != cardSuit);

                return hasOneCardWithDiffSuit;
            }
            else return false;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("hand");
            }

            if (hand.Cards.Count < 5 || hand.Cards.Count > 5)
            {
                throw new ApplicationException("Hand should have exactly 5 cards!");
            }

            var cards = hand.Cards;
            if (NumberOfAKind(ref cards) == 3)
            {
                // remove the three of a kind
                for (int i = 0; i < cards.Count - 2; i++)
                {
                    var currentCard = cards[i];
                    var nextCard = cards[i + 1];
                    var nextOfTheNext = cards[i + 2];
                    if (currentCard.Face == nextCard.Face && nextCard.Face == nextOfTheNext.Face)
                    {
                        cards.Remove(currentCard);
                        cards.Remove(nextCard);
                        cards.Remove(nextOfTheNext);
                        break;
                    }
                }

                // check if the rest are different, N.B. there are only 2 cards left
                if (cards[0].Face == cards[1].Face) return false;
                else return true;
            }
            else return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (hand == null) throw new ArgumentNullException("hand");

            if (hand.Cards.Count < 5 || hand.Cards.Count > 5) throw new ApplicationException("Hand should have exactly 5 cards!");

            var cards = hand.Cards;
            if (NumberOfAKind(ref cards) == 2)
            {
                // remove the pair
                RemovePair(cards);
                // now only 3 cards left
                if (NumberOfAKind(ref cards) == 2)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public bool IsOnePair(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("hand");
            }

            if (hand.Cards.Count < 5 || hand.Cards.Count > 5)
            {
                throw new ApplicationException("Hand should have exactly 5 cards!");
            }

            var cards = hand.Cards;
            if (NumberOfAKind(ref cards) == 2)
            {
                // get the pair & remove it
                RemovePair(cards);

                // check if rest of cards are different face
                if (NumberOfAKind(ref cards) > 1) return false;
                else return true;
            }
            else return false;
        }

        public bool IsHighCard(IHand hand)
        {
            if (hand == null)
            {
                throw new ArgumentNullException("hand");
            }

            if (hand.Cards.Count < 5 || hand.Cards.Count > 5)
            {
                throw new ApplicationException("Hand should have exactly 5 cards!");
            }

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                var currentCard = hand.Cards[i];
                hand.Cards.RemoveAt(i);

                bool haveSameCardFace = hand.Cards.Any(x => x.Face == currentCard.Face);
                if (haveSameCardFace)
                {
                    return false;
                }

                hand.Cards.Insert(i, currentCard);
            }

            return true;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
