namespace PokerTests
{
    using System.Collections.Generic;

    using NUnit.Framework;
    using Poker;

    [TestFixture]
    public class Hand_ToString_Should
    {
        [Test]
        public void ReturnStringOfAllCardsSeparatedByComaSpace_WhenNonEmptyCollectionIsPassed()
        {
            // Arrange
            var cards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)
            };

            var expectedString = string.Join(", ", cards);
            var hand = new Hand(cards);

            // Act
            var handToStr = hand.ToString();

            // Assert
            StringAssert.AreEqualIgnoringCase(expectedString, handToStr);
        }

        [Test]
        public void ReturnEmptyString_WhenCollectionOfCardsIsEmpty()
        {

            // Arrange
            var cards = new List<ICard>();

            var hand = new Hand(cards);

            // Act
            var handToStr = hand.ToString();

            // Assert
            StringAssert.AreEqualIgnoringCase(string.Empty, handToStr);
        }
    }
}
