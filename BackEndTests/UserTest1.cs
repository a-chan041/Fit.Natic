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
        public void saveToandReadFromJsonTest()
        {

            User testUser = new User();
            testUser.name = "MCD";
            testUser.age = 70;
            testUser.gender = "m";
            testUser.height = 62;
            testUser.weight = 180;
            testUser.userTarget = new DailyTarget();
            testUser.userTarget.logMeal("pasta",1000,"was bomb");
            testUser.userTarget.sleepTarget = 2;
            testUser.userTarget.calorieTarget = 10000;
            testUser.userTarget.logWorkout("bench press", 30, "got sweaty");
            testUser.userTarget.logSleep(8);
            testUser.userTarget.sleep.notes = "couldnt sleep";


            testUser.saveToJsonAsync();

           
            User testUser2 = User.readFromJson();


            //make sure nothing is null
            Assert.NotNull(testUser2.gender);
            Assert.NotNull(testUser2);
            Assert.NotNull(testUser2.age);
            Assert.NotNull(testUser2.name);
            Assert.NotNull(testUser2.height);
            Assert.NotNull(testUser2.weight);
            Assert.NotNull(testUser2.userTarget);

            //make sure the initialized object variables match what was in the json file

            Assert.AreEqual("MCD", testUser2.name);
            Assert.AreEqual(70, testUser2.age);
            Assert.AreEqual("m", testUser2.gender);
            Assert.AreEqual(180.0, testUser2.weight);
            Assert.AreEqual(62, testUser2.height);

            System.Console.WriteLine(testUser2.getDailyTarget().getNotes());

        }

        [Test]

        public void loadDatabaseTest()
        {
            User testUser = User.readFromJson();
            DailyTarget testTarget = testUser.getDailyTarget();
            DailyResults testDailyResults = new DailyResults {
                date = testTarget.date.Date,
                calorieTarget = testTarget.calorieTarget,
                sleepTarget = testTarget.sleepTarget,
                workoutTarget = testTarget.workoutTarget,
                caloriesLogged = testTarget.actualCalories,
                sleepLogged = testTarget.actualSleep,
                workoutLogged = testTarget.actualWorkout,
                notesLogged = " ",
            };

            App.Database.SaveTargetAsync(testDailyResults);

            Assert.NotNull(App.Database.GetDailyTargetsAsync());
            System.Console.WriteLine(App.Database.GetDailyTargetsAsync().ToString());


        }

        [Test]

        public void searchDatabaseDateRangeTest()
        {



        }


    }
}