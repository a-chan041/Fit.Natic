using System;
namespace Fit.Natic
{
    /* User class is instantiated when app is loaded or when user page is loaded,
     * variables are read in from json, and when edited, saved to json
     *
     * it is important that the data gets written back to json if it has been edited
     *  this may need need to be checked in the PageAppearing/Disappearing methods
     */

//TODO: create a function that reads in json to create the user object,
        //function can either live here or in app.xaml.cs

    public class User
    {
        public string name { get; set; }
        public int age { get; set; }
        public char gender { get; set; }
        public float weight { get; set; }
        public float height { get; set; }
        public DailyTarget userTarget;


        public User()
        {

        }

        public readFromJson()
        {

        }

        /* Would be used by front end if the user makes any changes to their daily target
         * Should take in a value for each of the daily target values and update all of them.
         */
        public Boolean updateDailyTarget() {
            
        }


        public string getDailyTarget()
        {

        }

        public string toString()
        {
           
        }


    }
}
