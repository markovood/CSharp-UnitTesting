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

        private ICard GetCards(IList<ICard> cards, int numberOfCards)
        {
            // cards are/must be sorted in advance
            ICard cardNeeded = null;
            switch (numberOfCards)
            {
                case 2:
                    for (int i = 0; i < cards.Count - 1; i++)
                    {
                        var currentCard = cards[i];
                        var nextCard = cards[i + 1];
                        if (currentCard.Face == nextCard.Face)
                        {
                            cardNeeded = currentCard;
                            break;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < cards.Count - 2; i++)
                    {
                        var currentCard = cards[i];
                        var nextCard = cards[i + 1];
                        var nextOfTheNextCard = cards[i + 2];
                        if (currentCard.Face == nextCard.Face && nextCard.Face == nextOfTheNextCard.Face)
                        {
                            cardNeeded = currentCard;
                            break;
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < cards.Count - 3; i++)
                    {
                        var currentCard = cards[i];
                        var nextCard = cards[i + 1];
                        var thirdCard = cards[i + 2];
                        var fourthCard = cards[i + 3];
                        if (currentCard.Face == nextCard.Face &&
                            nextCard.Face == thirdCard.Face &&
                            thirdCard.Face == fourthCard.Face)
                        {
                            cardNeeded = currentCard;
                            break;
                        }
                    }
                    break;
            }

            return cardNeeded;
        }

        private void RemoveCards(ICard cardToRemove, IList<ICard> cards, int repeat)
        {
            // cards must be sorted in advance
            int index = cards.IndexOf(cardToRemove);
            for (int i = 0; i < repeat; i++)
            {
                cards.RemoveAt(index);
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
                bool isFlush = true;
                for (int i = 0; i < hand.Cards.Count - 1; i++)
                {
                    var currentCard = hand.Cards[i];
                    var nextCard = hand.Cards[i + 1];
                    if (currentCard.Suit != nextCard.Suit)
                    {
                        isFlush = false;
                        break;
                    }
                }

                if (isFlush)
                {
                    // check if cards are sequential
                    var cards = hand.Cards.OrderByDescending(c => c.Face).ToList();
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
                    var pairCard = GetCards(cards, 2);
                    RemoveCards(pairCard, cards, 2);
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
                    var pairCard = GetCards(cards, 2);
                    RemoveCards(pairCard, cards, 2);

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
                bool isHighCard = false;
                for (int i = 0; i < cards.Count - 1; i++)
                {
                    var currentCard = cards[i];
                    var nextCard = cards[i + 1];
                    if (Math.Abs(currentCard.Face - nextCard.Face) != 1)
                    {
                        isHighCard = true;
                        break;
                    }
                }

                // check if cards are same suit
                if (isHighCard)
                {
                    for (int i = 0; i < cards.Count - 1; i++)
                    {
                        var currentCard = cards[i];
                        var nextCard = cards[i + 1];
                        if (currentCard.Suit != nextCard.Suit)
                        {
                            return true;
                        }
                    }

                    return false;
                }
                else return false;
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
            else
            {
                //IMPLEMENT comparison of hands of the same kind
                var firstHandCards = firstHand.Cards.OrderByDescending(c => c.Face).ToList();
                var secondHandCards = secondHand.Cards.OrderByDescending(c => c.Face).ToList();
                int returnValue = int.MinValue;
                switch (firstHandValue)
                {
                    case 1: // HighCard
                        returnValue = CompareHighCards(firstHandCards, secondHandCards);
                        break;
                    case 2: // OnePair
                        returnValue = CompareOnePairCards(firstHandCards, secondHandCards);
                        break;
                    case 3: // TwoPair
                        returnValue = CompareTwoPairCards(firstHandCards, secondHandCards);
                        break;
                    case 4: // ThreeOfAKind
                        returnValue = CompareThreeOfAKindCards(firstHandCards, secondHandCards);
                        break;
                    case 5: // Straight
                        returnValue = CompareStraightCards(firstHandCards, secondHandCards);
                        break;
                    case 6: // Flush
                        returnValue = CompareFlushCards(firstHandCards, secondHandCards);
                        break;
                    case 7: // FullHouse
                        returnValue = CompareFullHouseCards(firstHandCards, secondHandCards);
                        break;
                    case 8: // FourOfAKind
                        returnValue = CompareFourOfAKindCards(firstHandCards, secondHandCards);
                        break;
                    case 9: // StraightFlush
                        returnValue = CompareStraightFlushCards(firstHandCards, secondHandCards);
                        break;
                }

                return returnValue;
            }
        }

        private int CompareStraightFlushCards(IList<ICard> firstHandCards, IList<ICard> secondHandCards)
        {
            return CompareStraightCards(firstHandCards, secondHandCards);
        }

        private int CompareFourOfAKindCards(IList<ICard> firstHandCards, IList<ICard> secondHandCards)
        {
            // get the quadruplet
            var firstHandQuadrupletCard = GetCards(firstHandCards, 4);
            var secondHandQuadrupletCard = GetCards(secondHandCards, 4);
            // compare it
            if (firstHandQuadrupletCard.Face > secondHandQuadrupletCard.Face) return -1;
            else if (firstHandQuadrupletCard.Face < secondHandQuadrupletCard.Face) return 1;
            else
            {
                // remove the quadruplet & compare the only card left(the kicker)
                RemoveCards(firstHandQuadrupletCard, firstHandCards, 4);
                RemoveCards(secondHandQuadrupletCard, secondHandCards, 4);
                if (firstHandCards.First().Face > secondHandCards.First().Face) return -1;
                else if (firstHandCards.First().Face < secondHandCards.First().Face) return 1;
                else return 0;
            }
        }

        private int CompareFullHouseCards(IList<ICard> firstHandCards, IList<ICard> secondHandCards)
        {
            // get the triplet
            var firstHandTripletCard = GetCards(firstHandCards, 3);
            var secondHandTripletCard = GetCards(secondHandCards, 3);
            // compare it
            if (firstHandTripletCard.Face > secondHandTripletCard.Face) return -1;
            else if (firstHandTripletCard.Face < secondHandTripletCard.Face) return 1;
            else
            {
                // remove triplets
                RemoveCards(firstHandTripletCard, firstHandCards, 3);
                RemoveCards(secondHandTripletCard, secondHandCards, 3);
                // the triplets are equal, so compare the pairs
                if (firstHandCards[0].Face > secondHandCards[0].Face) return -1;
                else if (firstHandCards[0].Face < secondHandCards[0].Face) return 1;
                else return 0;
            }
        }

        private int CompareFlushCards(IList<ICard> firstHandCards, IList<ICard> secondHandCards)
        {
            return CompareHighCards(firstHandCards, secondHandCards);
        }

        private int CompareStraightCards(IList<ICard> firstHandCards, IList<ICard> secondHandCards)
        {
            var firstHandFirstCard = firstHandCards.First();
            var secondHandFirstCard = secondHandCards.First();
            if (firstHandFirstCard.Face > secondHandFirstCard.Face) return -1;
            else if (firstHandFirstCard.Face < secondHandFirstCard.Face) return 1;
            else return 0;
        }

        private int CompareThreeOfAKindCards(IList<ICard> firstHandCards, IList<ICard> secondHandCards)
        {
            // get the triplet
            var firstHandTripletCard = GetCards(firstHandCards, 3);
            var secondHandTripletCard = GetCards(secondHandCards, 3);
            // remove it
            RemoveCards(firstHandTripletCard, firstHandCards, 3);
            RemoveCards(secondHandTripletCard, secondHandCards, 3);
            // compare it
            if (firstHandTripletCard.Face > secondHandTripletCard.Face) return -1;
            else if (firstHandTripletCard.Face < secondHandTripletCard.Face) return 1;
            else
            {
                // if triplets are equal compare kickers
                if (firstHandCards[0].Face > secondHandCards[0].Face) return -1;
                else if (firstHandCards[0].Face < secondHandCards[0].Face) return 1;
                else
                {
                    if (firstHandCards[1].Face > secondHandCards[1].Face) return -1;
                    else if (firstHandCards[1].Face < secondHandCards[1].Face) return 1;
                    else return 0;
                }
            }

        }

        private int CompareTwoPairCards(IList<ICard> firstHandCards, IList<ICard> secondHandCards)
        {
            int resultOfFirstPairComparison;
            var firstPairCard = GetCards(firstHandCards, 2);
            var secondPairCard = GetCards(secondHandCards, 2);
            if (firstPairCard.Face > secondPairCard.Face) resultOfFirstPairComparison = -1;
            else if (firstPairCard.Face < secondPairCard.Face) resultOfFirstPairComparison = 1;
            else resultOfFirstPairComparison = 0;
            RemoveCards(firstPairCard, firstHandCards, 2);
            RemoveCards(secondPairCard, secondHandCards, 2);

            if (resultOfFirstPairComparison == 0)
            {
                return CompareOnePairCards(firstHandCards, secondHandCards);
            }
            else return resultOfFirstPairComparison;
        }

        private int CompareOnePairCards(IList<ICard> firstHandCards, IList<ICard> secondHandCards)
        {
            var firstPairCard = GetCards(firstHandCards, 2);
            var secondPairCard = GetCards(secondHandCards, 2);

            if (firstPairCard.Face > secondPairCard.Face) return -1;
            else if (firstPairCard.Face < secondPairCard.Face) return 1;
            else
            {
                RemoveCards(firstPairCard, firstHandCards, 2);
                RemoveCards(secondPairCard, secondHandCards, 2);
                return CompareHighCards(firstHandCards, secondHandCards);
            }
        }

        private int CompareHighCards(IList<ICard> firstHandCards, IList<ICard> secondHandCards)
        {
            for (int i = 0; i < firstHandCards.Count; i++)
            {
                if (firstHandCards[i].Face > secondHandCards[i].Face) return -1;
                else if (firstHandCards[i].Face < secondHandCards[i].Face) return 1;
            }

            return 0;
        }
    }
}
