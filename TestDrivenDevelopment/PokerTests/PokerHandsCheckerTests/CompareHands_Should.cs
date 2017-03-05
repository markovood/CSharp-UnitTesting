using Moq;
using NUnit.Framework;
using Poker;
using System;
using System.Collections.Generic;

namespace PokerTests.PokerHandsCheckerTests
{
    [TestFixture]
    public class CompareHands_Should
    {
        // CompareHands(…) should return -1, 0 or 1.

        [Test]
        public void ThrowArgumentNullException_WhenFirstHandIsNull()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();
            var handMock = new Mock<IHand>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => handChecker.CompareHands(null, handMock.Object));
        }

        [Test]
        public void ThrowApplicationException_WhenFirstHandHasLessThan5Cards()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var hand1Mock = new Mock<IHand>();
            var hand2Mock = new Mock<IHand>();

            var cardStub = new Mock<ICard>();
            var cardsStub = new List<ICard>
            {
                cardStub.Object,
                cardStub.Object,
                cardStub.Object,
                cardStub.Object
            };

            hand1Mock.Setup(h => h.Cards).Returns(cardsStub);

            // Act & Assert
            Assert.Throws<ApplicationException>(() => handChecker.CompareHands(hand1Mock.Object, hand2Mock.Object));
        }

        [Test]
        public void ThrowApplicationException_WhenFirstHandHasMoreThan5Cards()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var hand1Mock = new Mock<IHand>();
            var hand2Mock = new Mock<IHand>();
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

            hand1Mock.Setup(h => h.Cards).Returns(cardsStub);

            // Act & Assert
            Assert.Throws<ApplicationException>(() => handChecker.CompareHands(hand1Mock.Object, hand2Mock.Object));
        }

        [Test]
        public void ThrowArgumentException_WhenFirstHandIsInvalid()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var hand1Mock = new Mock<IHand>();
            var hand2Mock = new Mock<IHand>();
            var cardStub = new Mock<ICard>();

            var cardsStub = new List<ICard>
            {
                cardStub.Object,
                cardStub.Object,
                cardStub.Object,
                cardStub.Object,
                cardStub.Object
            };

            hand1Mock.Setup(h => h.Cards).Returns(cardsStub);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => handChecker.CompareHands(hand1Mock.Object, hand2Mock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenSecondHandIsNull()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var handMock = new Mock<IHand>();
            var card1Stub = new Mock<ICard>();
            var card2Stub = new Mock<ICard>();
            var card3Stub = new Mock<ICard>();
            var card4Stub = new Mock<ICard>();
            var card5Stub = new Mock<ICard>();

            var cardsStub = new List<ICard>
            {
                card1Stub.Object,
                card2Stub.Object,
                card3Stub.Object,
                card4Stub.Object,
                card5Stub.Object
            };

            handMock.Setup(h => h.Cards).Returns(cardsStub);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => handChecker.CompareHands(handMock.Object, null));
        }

        [Test]
        public void ThrowApplicationException_WhenSecondHandHasLessThan5Cards()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var hand1Mock = new Mock<IHand>();
            var hand2Mock = new Mock<IHand>();

            var card1Stub = new Mock<ICard>();
            var card2Stub = new Mock<ICard>();
            var card3Stub = new Mock<ICard>();
            var card4Stub = new Mock<ICard>();
            var card5Stub = new Mock<ICard>();

            var firstHandCardsStub = new List<ICard>
            {
                card1Stub.Object,
                card2Stub.Object,
                card3Stub.Object,
                card4Stub.Object,
                card5Stub.Object
            };

            var secondHandCardsStub = new List<ICard>
            {
                card1Stub.Object,
                card1Stub.Object,
                card1Stub.Object,
                card1Stub.Object
            };

            hand1Mock.Setup(h => h.Cards).Returns(firstHandCardsStub);
            hand2Mock.Setup(h => h.Cards).Returns(secondHandCardsStub);

            // Act & Assert
            Assert.Throws<ApplicationException>(() => handChecker.CompareHands(hand1Mock.Object, hand2Mock.Object));
        }

        [Test]
        public void ThrowApplicationException_WhenSecondHandHasMoreThan5Cards()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var hand1Mock = new Mock<IHand>();
            var hand2Mock = new Mock<IHand>();

            var card1Stub = new Mock<ICard>();
            var card2Stub = new Mock<ICard>();
            var card3Stub = new Mock<ICard>();
            var card4Stub = new Mock<ICard>();
            var card5Stub = new Mock<ICard>();

            var firstHandCardsStub = new List<ICard>
            {
                card1Stub.Object,
                card2Stub.Object,
                card3Stub.Object,
                card4Stub.Object,
                card5Stub.Object
            };

            var secondHandCardsStub = new List<ICard>
            {
                card1Stub.Object,
                card1Stub.Object,
                card1Stub.Object,
                card1Stub.Object,
                card1Stub.Object,
                card1Stub.Object
            };

            hand1Mock.Setup(h => h.Cards).Returns(firstHandCardsStub);
            hand2Mock.Setup(h => h.Cards).Returns(secondHandCardsStub);

            // Act & Assert
            Assert.Throws<ApplicationException>(() => handChecker.CompareHands(hand1Mock.Object, hand2Mock.Object));
        }

        [Test]
        public void ThrowArgumentException_WhenSecondHandIsInvalid()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var hand1Mock = new Mock<IHand>();
            var hand2Mock = new Mock<IHand>();

            var card1Stub = new Mock<ICard>();
            var card2Stub = new Mock<ICard>();
            var card3Stub = new Mock<ICard>();
            var card4Stub = new Mock<ICard>();
            var card5Stub = new Mock<ICard>();

            var firstHandCardsStub = new List<ICard>
            {
                card1Stub.Object,
                card2Stub.Object,
                card3Stub.Object,
                card4Stub.Object,
                card5Stub.Object
            };

            var secondHandCardsStub = new List<ICard>
            {
                card1Stub.Object,
                card1Stub.Object,
                card1Stub.Object,
                card1Stub.Object,
                card1Stub.Object
            };

            hand1Mock.Setup(h => h.Cards).Returns(firstHandCardsStub);
            hand2Mock.Setup(h => h.Cards).Returns(secondHandCardsStub);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => handChecker.CompareHands(hand1Mock.Object, hand2Mock.Object));
        }

        [Test]
        public void ReturnMinus1_WhenFirstHandIsBiger()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var hand1Mock = new Mock<IHand>();
            var hand2Mock = new Mock<IHand>();

            var card1Stub = new Mock<ICard>();
            var card2Stub = new Mock<ICard>();
            var card3Stub = new Mock<ICard>();
            var card4Stub = new Mock<ICard>();
            var card5Stub = new Mock<ICard>();

            var card6Stub = new Mock<ICard>();
            var card7Stub = new Mock<ICard>();
            var card8Stub = new Mock<ICard>();
            var card9Stub = new Mock<ICard>();
            var card10Stub = new Mock<ICard>();

            card1Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card1Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.Eight);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Seven);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Nine);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Six);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card10Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);

            var firstHandCardsStub = new List<ICard>
            {
                card1Stub.Object,
                card2Stub.Object,
                card3Stub.Object,
                card4Stub.Object,
                card5Stub.Object
            };

            var secondHandCardsStub = new List<ICard>
            {
                card6Stub.Object,
                card7Stub.Object,
                card8Stub.Object,
                card9Stub.Object,
                card10Stub.Object
            };

            hand1Mock.Setup(h => h.Cards).Returns(firstHandCardsStub);
            hand2Mock.Setup(h => h.Cards).Returns(secondHandCardsStub);

            // Act
            var result = handChecker.CompareHands(hand1Mock.Object, hand2Mock.Object);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Return0_WhenHandsAreEqual()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var hand1Mock = new Mock<IHand>();
            var hand2Mock = new Mock<IHand>();

            var card1Stub = new Mock<ICard>();
            var card2Stub = new Mock<ICard>();
            var card3Stub = new Mock<ICard>();
            var card4Stub = new Mock<ICard>();
            var card5Stub = new Mock<ICard>();

            var card6Stub = new Mock<ICard>();
            var card7Stub = new Mock<ICard>();
            var card8Stub = new Mock<ICard>();
            var card9Stub = new Mock<ICard>();
            var card10Stub = new Mock<ICard>();

            card1Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card1Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.Eight);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Seven);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Nine);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Six);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Eight);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Seven);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Nine);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Six);
            card10Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);

            var firstHandCardsStub = new List<ICard>
            {
                card1Stub.Object,
                card2Stub.Object,
                card3Stub.Object,
                card4Stub.Object,
                card5Stub.Object
            };

            var secondHandCardsStub = new List<ICard>
            {
                card6Stub.Object,
                card7Stub.Object,
                card8Stub.Object,
                card9Stub.Object,
                card10Stub.Object
            };

            hand1Mock.Setup(h => h.Cards).Returns(firstHandCardsStub);
            hand2Mock.Setup(h => h.Cards).Returns(secondHandCardsStub);

            // Act
            var result = handChecker.CompareHands(hand1Mock.Object, hand2Mock.Object);

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Return1_WhenSecondHandsIsBigger()
        {
            // Arrange
            var handChecker = new PokerHandsChecker();

            var hand1Mock = new Mock<IHand>();
            var hand2Mock = new Mock<IHand>();

            var card1Stub = new Mock<ICard>();
            var card2Stub = new Mock<ICard>();
            var card3Stub = new Mock<ICard>();
            var card4Stub = new Mock<ICard>();
            var card5Stub = new Mock<ICard>();

            var card6Stub = new Mock<ICard>();
            var card7Stub = new Mock<ICard>();
            var card8Stub = new Mock<ICard>();
            var card9Stub = new Mock<ICard>();
            var card10Stub = new Mock<ICard>();

            card1Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card1Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Seven);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Nine);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Six);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card10Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);

            var firstHandCardsStub = new List<ICard>
            {
                card1Stub.Object,
                card2Stub.Object,
                card3Stub.Object,
                card4Stub.Object,
                card5Stub.Object
            };

            var secondHandCardsStub = new List<ICard>
            {
                card6Stub.Object,
                card7Stub.Object,
                card8Stub.Object,
                card9Stub.Object,
                card10Stub.Object
            };

            hand1Mock.Setup(h => h.Cards).Returns(firstHandCardsStub);
            hand2Mock.Setup(h => h.Cards).Returns(secondHandCardsStub);

            // Act
            var result = handChecker.CompareHands(hand1Mock.Object, hand2Mock.Object);

            // Assert
            Assert.AreEqual(1, result);
        }

        // TODO: TEST FOR HANDS OF THE SAME KIND BUT DIFFERENT VALUE e.g. 10♦ 10♠ 2♠ 2♣ K♣ & 5♣ 5♠ 4♦ 4♥ 10♥
    }
}
