using System;
using System.Collections.Generic;

using Moq;
using NUnit.Framework;
using Poker;

namespace PokerTests.PokerHandsCheckerTests
{
    [TestFixture]
    public class IsHighCard_Should
    {
        // High card is a hand containing five cards not all of sequential rank or of the same suit, and none of which
        // are of the same rank

        [Test]
        public void ThrowArgumentNullException_WhenNullIsPassed()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => handChecker.IsHighCard(null));
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
            Assert.Throws<ApplicationException>(() => handChecker.IsHighCard(handMock.Object));
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
            Assert.Throws<ApplicationException>(() => handChecker.IsHighCard(handMock.Object));
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
            var result = handChecker.IsHighCard(handMock.Object);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnFalse_WhenAtLeast2CardsAreSameFace()
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
            card3Mock.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card4Mock.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card5Mock.SetupGet(c => c.Face).Returns(CardFace.Queen);

            // Act
            var result = handChecker.IsHighCard(handMock.Object);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnTrue_WhenAllCardsAreDifferentFace_AndNotSequential()
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
            card2Mock.SetupGet(c => c.Face).Returns(CardFace.Seven);
            card3Mock.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card4Mock.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Mock.SetupGet(c => c.Face).Returns(CardFace.Ace);

            // Act
            var result = handChecker.IsHighCard(handMock.Object);

            // Assert
            Assert.IsTrue(result);
        }
    }
}