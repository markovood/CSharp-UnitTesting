using Moq;
using NUnit.Framework;
using Poker;
using System;
using System.Collections.Generic;

namespace PokerTests.PokerHandsCheckerTests
{
    [TestFixture]
    public class IsValidHand_Should
    {
        // A hand is valid when it consists of exactly 5 different cards.

        [Test]
        public void ThrowArgumentNullException_WhenNullIsPassed()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => handChecker.IsValidHand(null));
        }

        [Test]
        public void ReturnFalse_WhenHandHasLessThan5Cards()
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
            Assert.Throws<ApplicationException>(() => handChecker.IsValidHand(handMock.Object));
        }

        [Test]
        public void ReturnFalse_WhenHandHasMoreThan5Cards()
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
            Assert.Throws<ApplicationException>(() => handChecker.IsValidHand(handMock.Object));
        }

        [Test]
        public void ReturnFalse_WhenHandCardsAre5_ButNotAllAreDifferent()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var handMock = new Mock<IHand>();
            var cardStub1 = new Mock<ICard>();
            var cardStub2 = new Mock<ICard>();
            var cardStub3 = new Mock<ICard>();
            var cardStub4 = new Mock<ICard>();
            var cardsStub = new List<ICard>
            {
                cardStub1.Object,
                cardStub2.Object,
                cardStub3.Object,
                cardStub4.Object,
                cardStub4.Object
            };

            handMock.Setup(h => h.Cards).Returns(cardsStub);

            // Act
            var result = handChecker.IsValidHand(handMock.Object);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnTrue_WhenAllCardsAreDifferent()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var handMock = new Mock<IHand>();
            var cardStub1 = new Mock<ICard>();
            var cardStub2 = new Mock<ICard>();
            var cardStub3 = new Mock<ICard>();
            var cardStub4 = new Mock<ICard>();
            var cardStub5 = new Mock<ICard>();

            var cardsStub = new List<ICard>
            {
                cardStub1.Object,
                cardStub2.Object,
                cardStub3.Object,
                cardStub4.Object,
                cardStub5.Object
            };

            handMock.Setup(h => h.Cards).Returns(cardsStub);

            // Act
            var result = handChecker.IsValidHand(handMock.Object);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
