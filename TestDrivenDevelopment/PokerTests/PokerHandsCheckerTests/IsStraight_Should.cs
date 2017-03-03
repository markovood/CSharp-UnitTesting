using Moq;
using NUnit.Framework;
using Poker;
using System;
using System.Collections.Generic;

namespace PokerTests.PokerHandsCheckerTests
{
    [TestFixture]
    public class IsStraight_Should
    {
        // A straight is a hand containing five cards of sequential rank, not all of the same suit

        [Test]
        public void ThrowArgumentNullException_WhenNullIsPassed()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => handChecker.IsStraight(null));
        }

        [Test]
        public void ThrowApplicationException_WhenHandHasLessThan5Cards()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var handMock = new Mock<IHand>();
            var cardStub = new Mock<ICard>();
            var cardsStub = new List<ICard>
            {
                cardStub.Object,
                cardStub.Object,
                cardStub.Object,
                cardStub.Object
            };

            handMock.Setup(h => h.Cards).Returns(cardsStub);

            // Act & Assert
            Assert.Throws<ApplicationException>(() => handChecker.IsStraight(handMock.Object));
        }

        [Test]
        public void ThrowApplicationException_WhenHandHasMoreThan5Cards()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var handMock = new Mock<IHand>();
            var cardStub = new Mock<ICard>();

            var cardsStub = new List<ICard>
            {
                cardStub.Object,
                cardStub.Object,
                cardStub.Object,
                cardStub.Object,
                cardStub.Object,
                cardStub.Object
            };

            handMock.Setup(h => h.Cards).Returns(cardsStub);

            // Act & Assert
            Assert.Throws<ApplicationException>(() => handChecker.IsStraight(handMock.Object));
        }

        [Test]
        public void ReturnTrue_WhenAllCardsAreSequentialFace_AndDifferentSuit()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var handMock = new Mock<IHand>();
            var card1Mock = new Mock<ICard>();
            var card2Mock = new Mock<ICard>();
            var card3Mock = new Mock<ICard>();
            var card4Mock = new Mock<ICard>();
            var card5Mock = new Mock<ICard>();

            var cardsStub = new List<ICard>
            {
                card1Mock.Object,
                card2Mock.Object,
                card3Mock.Object,
                card4Mock.Object,
                card5Mock.Object
            };

            handMock.Setup(h => h.Cards).Returns(cardsStub);
            card1Mock.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card2Mock.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card3Mock.SetupGet(c => c.Face).Returns(CardFace.King);
            card4Mock.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card5Mock.SetupGet(c => c.Face).Returns(CardFace.Ace);

            card1Mock.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card2Mock.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card3Mock.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card4Mock.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card5Mock.SetupGet(c => c.Suit).Returns(CardSuit.Spades);


            // Act
            var result = handChecker.IsStraight(handMock.Object);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnFalse_WhenAtLeastOneCardIsNotSequential()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var handMock = new Mock<IHand>();
            var card1Mock = new Mock<ICard>();
            var card2Mock = new Mock<ICard>();
            var card3Mock = new Mock<ICard>();
            var card4Mock = new Mock<ICard>();
            var card5Mock = new Mock<ICard>();

            var cardsStub = new List<ICard>
            {
                card1Mock.Object,
                card2Mock.Object,
                card3Mock.Object,
                card4Mock.Object,
                card5Mock.Object
            };

            handMock.Setup(h => h.Cards).Returns(cardsStub);
            card1Mock.SetupGet(c => c.Face).Returns(CardFace.Nine);
            card2Mock.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card3Mock.SetupGet(c => c.Face).Returns(CardFace.King);
            card4Mock.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card5Mock.SetupGet(c => c.Face).Returns(CardFace.Ace);

            // Act
            var result = handChecker.IsStraight(handMock.Object);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnFalse_WhenThereIsMoreThanOneCardOfTheSameFace()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var handMock = new Mock<IHand>();
            var card1Mock = new Mock<ICard>();
            var card2Mock = new Mock<ICard>();
            var card3Mock = new Mock<ICard>();
            var card4Mock = new Mock<ICard>();
            var card5Mock = new Mock<ICard>();

            var cardsStub = new List<ICard>
            {
                card1Mock.Object,
                card2Mock.Object,
                card3Mock.Object,
                card4Mock.Object,
                card5Mock.Object
            };

            handMock.Setup(h => h.Cards).Returns(cardsStub);
            card1Mock.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card2Mock.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card3Mock.SetupGet(c => c.Face).Returns(CardFace.King);
            card4Mock.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card5Mock.SetupGet(c => c.Face).Returns(CardFace.Ace);

            // Act
            var result = handChecker.IsStraight(handMock.Object);

            // Assert
            Assert.IsFalse(result);
        }
        
        [Test]
        public void ReturnFalse_WhenAllCardsAreSequentialFace_AndSameSuit()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var handMock = new Mock<IHand>();
            var card1Mock = new Mock<ICard>();
            var card2Mock = new Mock<ICard>();
            var card3Mock = new Mock<ICard>();
            var card4Mock = new Mock<ICard>();
            var card5Mock = new Mock<ICard>();

            var cardsStub = new List<ICard>
            {
                card1Mock.Object,
                card2Mock.Object,
                card3Mock.Object,
                card4Mock.Object,
                card5Mock.Object
            };

            handMock.Setup(h => h.Cards).Returns(cardsStub);
            card1Mock.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card2Mock.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card3Mock.SetupGet(c => c.Face).Returns(CardFace.King);
            card4Mock.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card5Mock.SetupGet(c => c.Face).Returns(CardFace.Ace);

            card1Mock.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card2Mock.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card3Mock.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card4Mock.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Mock.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);


            // Act
            var result = handChecker.IsStraight(handMock.Object);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
