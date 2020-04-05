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
            Assert.NotNull(testUser);
            Assert.NotNull(testUser.name);
            Assert.NotNull(testUser.age);
            Assert.NotNull(testUser.gender);
            Assert.NotNull(testUser.height);
            Assert.NotNull(testUser.weight);
            Assert.NotNull(testUser.userTarget);

            //make sure the initialized object variables match what was in the json file

            Assert.AreEqual("John Jane Doe", testUser.name);
            Assert.AreEqual(18, testUser.age);
            Assert.AreEqual("x", testUser.gender);
            Assert.AreEqual(140.0, testUser.weight);
            Assert.AreEqual(64.5, testUser.height);






        }

        [Test]
        public void saveToJsonTest()
        {

            User testUser = new User();
            testUser.name = "MCD";
            testUser.age = 70;
            testUser.gender = "m";
            testUser.height = 62;
            testUser.weight = 180;
            testUser.userTarget = new DailyTarget();
            testUser.userTarget.addMeal("pasta",1000,"was bomb");
            testUser.userTarget.sleepTarget = 2;
            testUser.userTarget.calorieTarget = 10000;

            testUser.saveToJsonAsync();

           
            User testUser2 = User.readFromJson();


            //make sure nothing is null
            Assert.NotNull(testUser.gender);
            Assert.NotNull(testUser);
            Assert.NotNull(testUser.age);
            Assert.NotNull(testUser.name);
            Assert.NotNull(testUser.height);
            Assert.NotNull(testUser.weight);
            Assert.NotNull(testUser.userTarget);

            //make sure the initialized object variables match what was in the json file

            Assert.AreEqual("MCD", testUser.name);
            Assert.AreEqual(70, testUser.age);
            Assert.AreEqual("m", testUser.gender);
            Assert.AreEqual(180.0, testUser.weight);
            Assert.AreEqual(62, testUser.height);

        }
    }
}