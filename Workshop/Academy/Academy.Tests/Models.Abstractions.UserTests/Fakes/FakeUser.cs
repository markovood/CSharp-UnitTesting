using Academy.Models.Abstractions;

namespace Academy.Tests.Models.Abstractions.UserTests.Fakes
{
    public class FakeUser : User
    {
        public FakeUser(string username) :
            base(username)
        {
        }
    }
}