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

        // TESTS FOR HANDS OF THE SAME KIND BUT DIFFERENT VALUE e.g. 10♦ 10♠ 2♠ 2♣ K♣ & 5♣ 5♠ 4♦ 4♥ 10♥
        [Test]
        [Category("HighCard")]
        public void ReturnMinus1_WhenBothHandsAre_HighCard_ButFirstHandIsBiger()
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
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.Three);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Seven);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
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
        [Category("HighCard")]
        public void Return0_WhenBothHandsAre_HighCard_AndAreEqual()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Six);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Eight);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Six);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
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
        [Category("HighCard")]
        public void Return1_WhenBothHandsAre_HighCard_ButSecondHandsIsBigger()
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
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
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
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
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

        [Test]
        [Category("OnePair")]
        public void ReturnMinus1_WhenBothHandsAre_OnePair_ButFirstHandIsBiger()
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
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
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
        [Category("OnePair")]
        public void ReturnMinus1_WhenBothHandsAre_OnePair_ButFirstHandHasBigerPair()
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
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
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
        [Category("OnePair")]
        public void Return1_WhenBothHandsAre_OnePair_ButSecondHandHasBigerPair()
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

            card1Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card1Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Seven);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Seven);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
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

        [Test]
        [Category("OnePair")]
        public void Return0_WhenBothHandsAre_OnePair_AndAreEqual()
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
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Six);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Six);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
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
        [Category("OnePair")]
        public void Return1_WhenBothHandsAre_OnePair_ButSecondHandsIsBigger()
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
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
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

        [Test]
        [Category("TwoPair")]
        public void ReturnMinus1_WhenBothHandsAre_TwoPair_ButFirstHandIsBiger()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
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
        [Category("TwoPair")]
        public void Return0_WhenBothHandsAre_TwoPair_AndAreEqual()
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
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Six);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
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
        [Category("TwoPair")]
        public void Return1_WhenBothHandsAre_TwoPair_ButSecondHandsIsBigger()
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

            card1Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card1Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Seven);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Seven);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Six);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
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

        [Test]
        [Category("TwoPair")]
        public void ReturnMinus1_WhenBothHandsAre_TwoPair_ButFirstHandHasBigerSecondPair()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
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
        [Category("TwoPair")]
        public void Return1_WhenBothHandsAre_TwoPair_ButSecondHandsHasBiggerSecondPair()
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
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Seven);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Six);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
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

        [Test]
        [Category("ThreeOfAKind")]
        public void ReturnMinus1_WhenBothHandsAre_ThreeOfAKind_ButFirstHandIsBigger()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
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
        [Category("ThreeOfAKind")]
        public void Return0_WhenBothHandsAre_ThreeOfAKind_AndAreEqual()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
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
            Assert.AreEqual(0, result);
        }

        [Test]
        [Category("ThreeOfAKind")]
        public void Return1_WhenBothHandsAre_ThreeOfAKind_ButSecondHandIsBigger()
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

            card1Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card1Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
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

        [Test]
        [Category("ThreeOfAKind")]
        public void ReturnMinus1_WhenHandsHaveEqualTriplet_ButFirstOneHasHigherKicker()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Nine);
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
        [Category("ThreeOfAKind")]
        public void Return1_WhenHandsHaveEqualTriplet_ButSecondOneHasHigherKicker()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
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

        [Test]
        [Category("ThreeOfAKind")]
        public void ReturnMinus1_WhenHandsHaveEqualTriplet_AndFirstKicker_ButSecondKickerInTheFirstHandIsHigher()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
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
        [Category("ThreeOfAKind")]
        public void Return1_WhenHandsHaveEqualTriplet_AndFirstKicker_ButSecondKickerInTheSecondHandIsHigher()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Seven);
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

        [Test]
        [Category("Straight")]
        public void ReturnMinus1_WhenBothHandsAre_Straight_ButFirstIsBigger()
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
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Nine);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Nine);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Eight);
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
        [Category("Straight")]
        public void Return1_WhenBothHandsAre_Straight_ButSecondIsBigger()
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

            card1Stub.SetupGet(c => c.Face).Returns(CardFace.Nine);
            card1Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.Seven);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Six);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Eight);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Nine);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
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

        [Test]
        [Category("Straight")]
        public void Return0_WhenBothHandsAre_Straight_AndAreEqual()
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

            card1Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card1Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
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
            Assert.AreEqual(0, result);
        }

        [Test]
        [Category("Flush")]
        public void ReturnMinus1_WhenBothHandsAre_Flush_ButFirstIsBigger()
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

            card1Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
            card1Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Three);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card10Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);

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
        [Category("Flush")]
        public void Return1_WhenBothHandsAre_Flush_ButSecondIsBigger()
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

            card1Stub.SetupGet(c => c.Face).Returns(CardFace.Nine);
            card1Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card10Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);

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
        
        [Test]
        [Category("Flush")]
        public void Return0_WhenBothHandsAre_Flush_AndAreEqual()
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

            card1Stub.SetupGet(c => c.Face).Returns(CardFace.Nine);
            card1Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Nine);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Two);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card10Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);

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
        [Category("FullHouse")]
        public void ReturnMinus1_WhenBothHandsAre_FullHouse_ButFirstHasBiggerTriplet()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card10Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);

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
        [Category("FullHouse")]
        public void Return1_WhenBothHandsAre_FullHouse_ButSecondHasBiggerTriplet()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card10Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);

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

        [Test]
        [Category("FullHouse")]
        public void Return0_WhenBothHandsAre_FullHouse_AndAreEqual()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card10Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);

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
        [Category("FullHouse")]
        public void ReturnMinus1_WhenBothHandsAre_FullHouse_ButFirstHasBiggerPair()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card10Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);

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
        [Category("FullHouse")]
        public void Return1_WhenBothHandsAre_FullHouse_ButSecondHasBiggerPair()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card10Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);

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

        [Test]
        [Category("FourOfAKind")]
        public void ReturnMinus1_WhenBothHandsAre_FourOfAKind_ButFirstHasBiggerQuadruplet()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
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
        [Category("FourOfAKind")]
        public void Return1_WhenBothHandsAre_FourOfAKind_ButSecondHasBiggerQuadruplet()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
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

        [Test]
        [Category("FourOfAKind")]
        public void ReturnMinus1_WhenBothHandsAre_FourOfAKind_ButFirstHasBiggerKicker()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Five);
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
        [Category("FourOfAKind")]
        public void Return1_WhenBothHandsAre_FourOfAKind_ButSecondHasBiggerKicker()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Three);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
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

        [Test]
        [Category("FourOfAKind")]
        public void Return0_WhenBothHandsAre_FourOfAKind_AndAreEqual()
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
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Spades);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Clubs);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
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
            Assert.AreEqual(0, result);
        }
        
        [Test]
        [Category("StraightFlush")]
        public void ReturnMinus1_WhenBothHandsAre_StraightFlush_ButFirstIsBigger()
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

            card1Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card1Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Nine);
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
        [Category("StraightFlush")]
        public void Return1_WhenBothHandsAre_StraightFlush_ButSecondIsBigger()
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

            card1Stub.SetupGet(c => c.Face).Returns(CardFace.Nine);
            card1Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
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

        [Test]
        [Category("StraightFlush")]
        public void Return0_WhenBothHandsAre_StraightFlush_AndAreEqual()
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

            card1Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
            card1Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card2Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card2Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card3Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card3Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card4Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card4Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);
            card5Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card5Stub.SetupGet(c => c.Suit).Returns(CardSuit.Diamonds);

            card6Stub.SetupGet(c => c.Face).Returns(CardFace.King);
            card6Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card7Stub.SetupGet(c => c.Face).Returns(CardFace.Jack);
            card7Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card8Stub.SetupGet(c => c.Face).Returns(CardFace.Queen);
            card8Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card9Stub.SetupGet(c => c.Face).Returns(CardFace.Ten);
            card9Stub.SetupGet(c => c.Suit).Returns(CardSuit.Hearts);
            card10Stub.SetupGet(c => c.Face).Returns(CardFace.Ace);
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
    }
}
