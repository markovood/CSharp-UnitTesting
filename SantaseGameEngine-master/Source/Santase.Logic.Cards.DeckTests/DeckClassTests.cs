using NUnit.Framework;

namespace Santase.Logic.Cards.DeckTests
{
    [TestFixture]
    public class DeckClassTests
    {
        private IDeck deck;

        [SetUp]
        public void SetUpNewDeck()
        {
            deck = new Deck();
        }

        [Test]
        public void Test_CardsLeftPropertyShouldBe23AfterDrawingOneCard()
        {
            // Arrange
            //var deck = new Deck();

            // Act 
            deck.GetNextCard();

            // Assert
            Assert.AreEqual(23, deck.CardsLeft);
        }

        [Test]
        public void Test_CardsLeftPropertyShouldBe24AtTheBeginning()
        {
            // Arrange
            //var deck = new Deck();

            // Assert
            Assert.AreEqual(24, deck.CardsLeft);
        }

        [Test]
        public void Test_CardsLeftPropertyShouldBe0AfterDrawingAllCards()
        {
            // Arrange
            //var deck = new Deck();

            // Act 
            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            // Assert
            Assert.AreEqual(0, deck.CardsLeft);
        }

        [Test]
        public void Test_GetNextCardShouldThrowExceptionIfDeckIsEmpty()
        {
            // Arrange
            //var deck = new Deck();

            // Act
            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            Assert.Throws(typeof(InternalGameException), () => deck.GetNextCard());
        }

        private static Card[] ExchangeCards =
        {
            Card.GetCard(CardSuit.Club,CardType.Nine),
            Card.GetCard(CardSuit.Diamond,CardType.Nine),
            Card.GetCard(CardSuit.Heart,CardType.Nine),
            Card.GetCard(CardSuit.Spade,CardType.Nine)
        };

        [TestCaseSource("ExchangeCards")]
        public void Test_ChangeTrumpCardShouldWorkProperly(Card exchangeCard)
        {
            // Arrange
            //var deck = new Deck();

            // Act
            var trumpCardSuit = deck.TrumpCard.Suit;

            // Assert
            if (trumpCardSuit == exchangeCard.Suit)
            {
                deck.ChangeTrumpCard(exchangeCard);
                Assert.AreSame(exchangeCard, deck.TrumpCard);
            }
            else
            {
                Assert.IsFalse(exchangeCard.Suit == deck.TrumpCard.Suit, "Exchange card must be from the same suit!");
            }
        }
    }
}
