using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Core
{
    [TestFixture]
    public class PackageInstallerTests
    {
        [Test]
        public void TestMethod()
        {
            Assert.Fail();
            // TODO:
            // Test for restoring packages when the object is constructed
            //  - should test when there are dependencies in the project

            // Recursion
            // Test for Install command and empty dependencies list
            //  - should call two times Download and one time Remove

            // Test for Install command and at least one dependency in the dependencies list
            //  - every dependency on the chain will multiply the calss to the Download and Remove mehtod by 2
        }
    }
}
