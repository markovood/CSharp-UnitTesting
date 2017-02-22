using NUnit.Framework;
using Moq;
using Santase.Logic.PlayerActionValidate;
using Santase.Logic.Players;
using Santase.Logic.PlayerActionValidate.Contracts;
using Santase.Logic.Cards;
using System.Collections.Generic;
using Santase.Logic.RoundStates;
using Santase.Logic;
using PlayerActionValidatorTests.Fakes;

namespace PlayerActionValidatorTests
{
    // TODO: Apply these tests to the original unchanged project
    [TestFixture]
    public class IsValid_Should
    {
        [Test]
        public void SetAnnounce_WhenContextStateCanAnnounce20Or40IsTrue()
        {
            // Arrange
            var pav = new PlayerActionValidator();

            var playerActionMock = new Mock<IPlayerAction>();
            var playerTurnContextMock = new Mock<IPlayerTurnContext>();
            var playerCardsStub = new List<Card>();
            
            var stateManagerStub = new Mock<IStateManager>();

            playerTurnContextMock.Setup(c => c.State).Returns(new FakeRoundStateCA2040True(stateManagerStub.Object));

            // Act
            pav.IsValid(playerActionMock.Object, playerTurnContextMock.Object, playerCardsStub);

            // Assert
            playerActionMock.VerifySet(pa => pa.Announce = It.IsAny<Announce>());
        }

        [Test]
        public void ReturnFalse_WhenActionIsNull()
        {
            // Arrange
            var pav = new PlayerActionValidator();

            var playerActionMock = new Mock<IPlayerAction>();
            var playerTurnContextMock = new Mock<IPlayerTurnContext>();
            var playerCards = new List<Card>();

            var stateStub = new Mock<IStateManager>();

            playerTurnContextMock.SetupGet(c => c.State).Returns(new FakeRoundStateCA2040False(stateStub.Object));

            // Act
            var result = pav.IsValid(null, playerTurnContextMock.Object, playerCards);

            // Assert
            Assert.IsFalse(result);
        }

        [TestCase(PlayerActionType.PlayCard)]
        [TestCase(PlayerActionType.ChangeTrump)]
        [TestCase(PlayerActionType.CloseGame)]
        public void ReturnTrueOrFalse_WhenActionTypeIs(PlayerActionType pa_type)
        {
            // Arrange
            var pav = new PlayerActionValidator();

            var playerActionMock = new Mock<IPlayerAction>();
            var playerTurnContextMock = new Mock<IPlayerTurnContext>();
            var playerCards = new List<Card>();

            var stateStub = new Mock<IStateManager>();

            playerActionMock.SetupGet(pa => pa.Type).Returns(pa_type);
            playerTurnContextMock.SetupGet(c => c.State).Returns(new FakeRoundStateCA2040False(stateStub.Object));

            // Act
            var result = pav.IsValid(playerActionMock.Object, playerTurnContextMock.Object, playerCards);

            // Assert
            Assert.That(result == It.IsAny<bool>());
        }
    }
}
