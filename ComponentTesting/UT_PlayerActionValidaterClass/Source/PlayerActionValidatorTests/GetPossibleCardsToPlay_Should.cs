using NUnit.Framework;
using Santase.Logic.PlayerActionValidate;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Santase.Logic.PlayerActionValidate.Contracts;
using Santase.Logic.Cards;

namespace PlayerActionValidatorTests
{
    [TestFixture]
    public class GetPossibleCardsToPlay_Should
    {
        [Test]
        public void ReturnCollectionOfCards()
        {
            // Arrange
            var pav = new PlayerActionValidator();

            var playerTurnContextMock = new Mock<IPlayerTurnContext>();
            var playerCards = new List<Card>();

            // Act
            var result = pav.GetPossibleCardsToPlay(playerTurnContextMock.Object, playerCards);

            // Assert
            Assert.IsInstanceOf(typeof(ICollection<Card>), result);
        }
    }
}
