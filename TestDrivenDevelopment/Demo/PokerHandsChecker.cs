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
                    cards.Insert(i, currentCard);
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

        private int EvaluateHand(IHand hand)
        {
            if (IsHighCard(hand)) return 1;
            else if (IsOnePair(hand)) return 2;
            else if (IsTwoPair(hand)) return 3;
            else if (IsThreeOfAKind(hand)) return 4;
            else if (IsStraight(hand)) return 5;
            else if (IsFlush(hand)) return 6;
            else if (IsFullHouse(hand)) return 7;
            else if (IsFourOfAKind(hand)) return 8;
            else if (IsStraightFlush(hand)) return 9;
            else return 0;
        }
        
        public bool IsValidHand(IHand hand)
        {
            // A hand is valid when it consists of exactly 5 different cards.

            if (hand == null)
            {
                throw new ArgumentNullException("hand");
            }

            if (hand.Cards.Count < 5 || hand.Cards.Count > 5)
            {
                throw new ApplicationException("Hand should have exactly 5 cards!");
            }

            if (NotAllCardsAreDifferent(hand.Cards)) return false;
            else return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (IsValidHand(hand))
            {
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
            else return false;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (IsValidHand(hand))
            {
                var cards = hand.Cards;
                if (NumberOfAKind(ref cards) == 4) return true;
                else return false;
            }
            else return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (IsValidHand(hand))
            {
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
            else return false;
        }

        public bool IsFlush(IHand hand)
        {
            if (IsValidHand(hand))
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

                return true;
            }
            else return false;
        }

        public bool IsStraight(IHand hand)
        {
            if (IsValidHand(hand))
            {
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
            else return false;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (IsValidHand(hand))
            {
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
            else return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            if (IsValidHand(hand))
            {
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
            else return false;
        }

        public bool IsOnePair(IHand hand)
        {
            if (IsValidHand(hand))
            {
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
            else return false;
        }

        public bool IsHighCard(IHand hand)
        {
            if (IsValidHand(hand))
            {
                var cards = hand.Cards.OrderByDescending(c => c.Face).ToList();
                for (int i = 0; i < cards.Count; i++)
                {
                    var currentCard = cards[i];
                    cards.RemoveAt(i);

                    bool haveSameCardFace = cards.Any(x => x.Face == currentCard.Face);
                    if (haveSameCardFace)
                    {
                        //cards.Insert(i, currentCard);
                        return false;
                    }

                    cards.Insert(i, currentCard);
                }

                // check weather the cards are sequential
                for (int i = 0; i < cards.Count - 1; i++)
                {
                    var currentCard = cards[i];
                    var nextCard = cards[i + 1];
                    if (Math.Abs(currentCard.Face - nextCard.Face) != 1)
                    {
                        return true;
                    }
                }

                return false;
            }
            else return false;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            int firstHandValue = EvaluateHand(firstHand);
            if (firstHandValue == 0)
            {
                throw new ArgumentException("First hand is invalid!");
            }

            int secondHandValue = EvaluateHand(secondHand);
            if (secondHandValue == 0)
            {
                throw new ArgumentException("Second hand is invalid!");
            }

            if (firstHandValue > secondHandValue) return -1;
            else if (secondHandValue > firstHandValue) return 1;
            else return 0; // TODO: IMPLEMENT comparison of hands of the same kind
        }
    }
}
