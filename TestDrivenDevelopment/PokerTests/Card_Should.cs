namespace PokerTests
{
    using Poker;
    using NUnit.Framework;

    [TestFixture]
    public class Card_Should
    {
        [Test]
        public void ReturnCardDescriptionWithFaceFirst_WhenToStringIsInvoked()
        {
            // Arrange
            var cardFace = CardFace.Ace;
            var cardSuit = CardSuit.Diamonds;
            var card = new Card(cardFace, cardSuit);

            // Act
            var result = card.ToString();

            // Assert
            StringAssert.StartsWith(cardFace.ToString(), result, "String should start with card face");
        }

        [Test]
        public void ReturnCardDescriptionWithSuitAtTheEnd_WhenToStringIsInvoked()
        {
            // Arrange
            var cardFace = CardFace.Ace;
            var cardSuit = CardSuit.Diamonds;
            var card = new Card(cardFace, cardSuit);

            // Act
            var result = card.ToString();

            // Assert
            StringAssert.EndsWith(cardSuit.ToString(), result, "String should end with card suit");
        }
    }
}
