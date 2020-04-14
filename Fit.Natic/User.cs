using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Fit.Natic
{
    /* User class is instantiated when app is loaded or when user page is loaded,
     * variables are read in from json, and when edited, saved to json
     *
     * it is important that the data gets written back to json if it has been edited
     *  this may need need to be checked in the PageAppearing/Disappearing methods
     */

    public class User
    {
        public string name { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public float weight { get; set; } // in lbs
        public float height { get; set; } // in inches
        public DailyTarget userTarget { get; set; }
        
        /* readFromJson reads in the temporarily stored information
         * on the users info, their daily target, and goals achieved.
         *
         */
        public static User readFromJson()
        {
            var filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "userInfo.json");
            try
            {
                User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(filePath));
                return user;

            }
            catch (System.IO.FileNotFoundException e)
            {
                System.Console.WriteLine("couldnt find json file, creating a new one");

                User user = new User();
                user.name = "MCD";
                user.age = 70;
                user.gender = "m";
                user.height = 62;
                user.weight = 180;
                user.userTarget = new DailyTarget();
                user.userTarget.logMeal("pasta", 1000, "was bomb");
                user.userTarget.sleepTarget = 2;
                user.userTarget.calorieTarget = 10000;
                user.userTarget.logWorkout("bench press", 30, "got sweaty");
                user.userTarget.logSleep(8, "");
                user.userTarget.sleep.notes = "couldnt sleep";
                return user;
            }
            
        }


        public async System.Threading.Tasks.Task<bool> saveToJsonAsync()
        {
            string data = JsonConvert.SerializeObject(this);
            try
            {
                var filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "userInfo.json");
                using (var writer = File.CreateText(filePath))
                {
                    await writer.WriteLineAsync(data);
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        /* Would be used by front end if the user makes any changes to their daily target
         * Should take in a value for each of the daily target values and update all of them.
         */
        public void setDailyTarget(DailyTarget newTarget)
        {
            this.userTarget = newTarget;
            this.saveToJsonAsync();
        }


        public DailyTarget getDailyTarget()
        {
            return this.userTarget;
        }

    }
}
