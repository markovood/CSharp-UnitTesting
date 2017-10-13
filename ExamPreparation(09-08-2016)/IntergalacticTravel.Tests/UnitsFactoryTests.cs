using IntergalacticTravel.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class UnitsFactoryTests
    {
        [Test]
        public void GetUnitShouldReturnNewProcyonUnit_WhenAValidCorrespondingCommandIsPassed()
        {
            // Arrange
            const string validCorrespondingCommand = "create unit Procyon Gosho 1";
            var factory = new UnitsFactory();

            // Act
            var unit = factory.GetUnit(validCorrespondingCommand);

            // Assert
            Assert.IsInstanceOf(typeof(Procyon), unit);
        }

        [Test]
        public void GetUnitShouldReturnNewLuytenUnit_WhenAValidCorrespondingCommandIsPassed()
        {
            // Arrange
            const string validCorrespondingCommand = "create unit Luyten Pesho 2";
            var factory = new UnitsFactory();

            // Act
            var unit = factory.GetUnit(validCorrespondingCommand);

            // Assert
            Assert.IsInstanceOf(typeof(Luyten), unit);
        }

        [Test]
        public void GetUnitShouldReturnNewLacailleUnit_WhenAValidCorrespondingCommandIsPassed()
        {
            // Arrange
            const string validCorrespondingCommand = "create unit Lacaille Tosho 3";
            var factory = new UnitsFactory();

            // Act
            var unit = factory.GetUnit(validCorrespondingCommand);

            // Assert
            Assert.IsInstanceOf(typeof(Lacaille), unit);
        }
        
        [TestCase("create Luyten Pesho 2")]
        [TestCase("unit Luyten Pesho 2")]
        [TestCase("create new unit Luyten Pesho 2")]
        [TestCase("create Luyten unit Pesho 2")]
        [TestCase("create unit Pesho 2")]
        [TestCase("a b c d e")]
        [TestCase("create unit a b c")]
        [TestCase("create unit Luyten Pesho a")]
        public void GetUnitShouldThrowInvalidUnitCreationCommandException_WhenTheCommandPassedIsNotInTheValidFormat(string command)
        {
            // Arrange
            var factory = new UnitsFactory();

            // Act & Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit(command));
        }
    }
}
