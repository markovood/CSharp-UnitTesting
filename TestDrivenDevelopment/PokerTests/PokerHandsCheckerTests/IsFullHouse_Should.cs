using Moq;
using NUnit.Framework;
using Poker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTests.PokerHandsCheckerTests
{
    [TestFixture]
    public class IsFullHouse_Should
    {
        // A full house is a hand containing three cards of one rank and two cards of another rank.

        [Test]
        public void ThrowArgumentNullException_WhenNullIsPassed()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => handChecker.IsFullHouse(null));
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
            Assert.Throws<ApplicationException>(() => handChecker.IsFullHouse(handMock.Object));
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
            Assert.Throws<ApplicationException>(() => handChecker.IsFullHouse(handMock.Object));
        }

        [Test]
        public void ReturnFalse_WhenHandHas3CardsOfTheSameFace_ButOther2AreDifferentFaces()
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
            card1Mock.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card2Mock.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card3Mock.SetupGet(c => c.Face).Returns(CardFace.King);
            card4Mock.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card5Mock.SetupGet(c => c.Face).Returns(CardFace.Jack);

            // Act
            var result = handChecker.IsFullHouse(handMock.Object);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnTrue_WhenHandHas3CardsOfTheSameFace_And2CardsOfAnotherFace()
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
            card1Mock.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card2Mock.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card3Mock.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card4Mock.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card5Mock.SetupGet(c => c.Face).Returns(CardFace.Jack);

            // Act
            var result = handChecker.IsFullHouse(handMock.Object);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnFalse_WhenHandDoesntHave3CardsOfTheSameFace()
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
            card1Mock.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card2Mock.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card3Mock.SetupGet(c => c.Face).Returns(CardFace.King);
            card4Mock.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Mock.SetupGet(c => c.Face).Returns(CardFace.Jack);

            // Act
            var result = handChecker.IsFullHouse(handMock.Object);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
