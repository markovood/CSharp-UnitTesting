using NUnit.Framework;
using Moq;
using Santase.Logic.PlayerActionValidate;
using Santase.Logic.Players;
using Santase.Logic.PlayerActionValidate.Contracts;
using Santase.Logic.Cards;
using System.Collections.Generic;
using Santase.Logic.RoundStates;

namespace PlayerActionValidatorTests
{
    [TestFixture]
    public class IsValid_Should
    {
        [Test]
        public void CallGetPossibleAnnounce_WhenContextStateCanAnnounce20Or40IsTrue()
        {
            // Arrange
            var pav = new PlayerActionValidator();
            var playerActionMock = new Mock<IPlayerAction>();
            var announceValidatorMock = new Mock<IAnnounceValidator>();
            var playerTurnContextMock = new Mock<IPlayerTurnContext>();
            var stateMock = new Mock<IBaseRoundState>();
            var playerCards = new List<Card>();

            stateMock.SetupAllProperties();
            stateMock.SetupGet(s => s.CanAnnounce20Or40).Returns(true);
            playerTurnContextMock.SetupAllProperties();
            playerTurnContextMock.SetupGet(c => c.State); //.Returns(stateMock.Object);
            announceValidatorMock.Setup(a => a.GetPossibleAnnounce(null, null, null, true)).Verifiable();
            
            // Act
            pav.IsValid(playerActionMock.Object, playerTurnContextMock.Object, playerCards);

            // Assert

        }
    }
}
