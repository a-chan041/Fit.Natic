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
        public DailyTarget userTarget;


        public User()
        {

        }


        public User readFromJson()
        {
            User user;
            var filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "userInfo.json");

            using (StreamReader sr = new StreamReader(filePath))
            {
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    user = serializer.Deserialize<User>(reader);
                }
                //'reader' will be disposed by this point
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
        public Boolean updateDailyTarget() {

            //TODO: need to take in whatever parameters are necessary and update object variables


            saveToJsonAsync();
            return true;
        }


        public DailyTarget getDailyTarget()
        {
            return this.userTarget;
        }

        public void setDailyTarget(DailyTarget newTarget)
        {
            this.userTarget = newTarget;
        }

    }
}
