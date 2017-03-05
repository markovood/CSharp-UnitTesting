using Moq;
using NUnit.Framework;
using Poker;
using System;
using System.Collections.Generic;

namespace PokerTests.PokerHandsCheckerTests
{
    [TestFixture]
    public class IsTwoPair_Should
    {
        // Two pair is a hand containing two cards of the same rank, two cards of another rank and one card of a third rank

        [Test]
        public void ThrowArgumentNullException_WhenNullIsPassed()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => handChecker.IsTwoPair(null));
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
            Assert.Throws<ApplicationException>(() => handChecker.IsTwoPair(handMock.Object));
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
            Assert.Throws<ApplicationException>(() => handChecker.IsTwoPair(handMock.Object));
        }

        [Test]
        public void ReturnFalse_WhenHandIsInvalid()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var handMock = new Mock<IHand>();
            var card1Mock = new Mock<ICard>();
            var card2Mock = new Mock<ICard>();
            var card3Mock = new Mock<ICard>();
            var card4Mock = new Mock<ICard>();

            var cardsStub = new List<ICard>
            {
                card1Mock.Object,
                card2Mock.Object,
                card3Mock.Object,
                card4Mock.Object,
                card4Mock.Object
            };

            handMock.Setup(h => h.Cards).Returns(cardsStub);

            // Act
            var result = handChecker.IsTwoPair(handMock.Object);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnTrue_WhenHandContains2PairsOfTheSameFaceAnd1CardOfDifferentFace()
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
            card1Mock.SetupGet(c => c.Face).Returns(CardFace.King);
            card2Mock.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card3Mock.SetupGet(c => c.Face).Returns(CardFace.King);
            card4Mock.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card5Mock.SetupGet(c => c.Face).Returns(CardFace.Nine);

            // Act
            var result = handChecker.IsTwoPair(handMock.Object);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnFalse_WhenHandIsAFullHouseAndCoversTheRequirementsForTwoPair()
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
            card1Mock.SetupGet(c => c.Face).Returns(CardFace.King);
            card2Mock.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card3Mock.SetupGet(c => c.Face).Returns(CardFace.King);
            card4Mock.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card5Mock.SetupGet(c => c.Face).Returns(CardFace.King);

            // Act
            var result = handChecker.IsTwoPair(handMock.Object);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnFalse_WhenHandDoesntContain2CardsOfTheSameFace()
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
            card1Mock.SetupGet(c => c.Face).Returns(CardFace.King);
            card2Mock.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card3Mock.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card4Mock.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Mock.SetupGet(c => c.Face).Returns(CardFace.Nine);

            // Act
            var result = handChecker.IsTwoPair(handMock.Object);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnFalse_WhenHandContainsOnly1PairOfTheSameFace()
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
            card1Mock.SetupGet(c => c.Face).Returns(CardFace.King);
            card2Mock.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card3Mock.SetupGet(c => c.Face).Returns(CardFace.King);
            card4Mock.SetupGet(c => c.Face).Returns(CardFace.Nine);
            card5Mock.SetupGet(c => c.Face).Returns(CardFace.Eight);

            // Act
            var result = handChecker.IsTwoPair(handMock.Object);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
