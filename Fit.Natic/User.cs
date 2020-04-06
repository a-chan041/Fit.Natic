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
         * if the information stored in the json file is from the previous day
         * (if todays date > date stored in json file)
         *      read in the information to a user object, create a DailyResults object,
         *      and store the daily results object in the database, then clear
         *      the daily results and increment the date to start a new slate for the day.
         *      The new updated User object and daily target object should be written back to json.
         *
         */
        public static User readFromJson()
        {
           // User user;
            var filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "userInfo.json");

            User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(filePath));

            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                User user2 = (User)serializer.Deserialize(file, typeof(User));
               // return user2;

            }
            return user;
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
