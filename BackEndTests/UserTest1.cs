using NUnit.Framework;
using Fit.Natic;
namespace BackEndTests
{
    public class UserTest1
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void readFromJsonTest()
        {

            User testUser = User.readFromJson();

            //make sure nothing is null
            Assert.NotNull(testUser.gender);
            Assert.NotNull(testUser);
            Assert.NotNull(testUser.age);
            Assert.NotNull(testUser.name);
            Assert.NotNull(testUser.height);
            Assert.NotNull(testUser.weight);
            Assert.NotNull(testUser.userTarget);

            //make sure the initialized object variables match what was in the json file
            Assert.AreEqual(18, testUser.age);

        }
    }
}