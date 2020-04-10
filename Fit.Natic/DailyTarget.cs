using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Xml.Schema;
using DateTime = System.DateTime;

namespace Fit.Natic
{
    // TODO: finish DailyTarget() method
    // TODO: decide if Workout, Sleep, Meal classes are public or inner class of Daily Target
    // TODO: finish removeMeal() method
    // TODO: decide if "actual" variables need to be stored in DailyTarget class or another (performance, etc.) 
    // TODO: create tests for objects and functions
    
    public class DailyTarget
    {
        public DateTime date;

        public int calorieTarget;
        public int sleepTarget;
        public int workoutTarget;

        public Workout workout;
        public Sleep sleep;
        public List<Meal> meals;

        // not sure if these 3 are needed or should be in Performance
        public int actualCalories; 
        public int actualSleep;
        public int actualWorkout;


        public DailyTarget()
        {
            this.calorieTarget = 0;
            this.sleepTarget = 8;
            this.workoutTarget = 30;

            this.meals = new List<Meal>();
            this.workout = new Workout();
            this.sleep = new Sleep();
            this.actualCalories = 0;
            this.actualSleep = 0;
            this.actualWorkout = 0;

        }

        /*Adds a meal to the generic list of meals
         *  Takes the name of the meal as a string, number of calories as integer,
         *  and a string of the meal notes as parameters
         */
        public void logMeal(string name, int cals, string notes)
        {
            this.meals.Add(new Meal { mealName = name, mealCalories = cals, notes = notes , mealTime = DateTime.Now});
            //updating the current days calorie intake
            this.actualCalories += cals;
        }


        /* removes a meal from the generic list of meals
         *  returns true if successful, false if error
         */
        public Boolean removeMeal(Meal meal)
        {
            try
            {
                this.meals.Remove(meal);
                //updating the current days calorie intake
                this.actualCalories -= meal.mealCalories;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /*Not sure if getMeal is going to be needed?
         */
        public List<Meal> getMeals()
        {
            return this.meals;
        }

        /* iterates through the arraylist of meals and 
         * grabs each meals notes and appends it to a string
         */
        public string getMealNotes()
        {
            string allMealNotes = "";
            foreach (Meal meal in meals)
            {
                allMealNotes = allMealNotes + meal.mealName + ": " + meal.notes + "\n ";
            }
            return allMealNotes;
        }

        /*We can either have just a function to enter the sleep, or we
         * can create a sleep object, only benefit to that would be
         * the sleep object has its own dedicate notes variable.
         */
        public void logSleep(int sleepDur)
        {
            if(sleepDur >= 0 && actualSleep >=0)
            {
                this.actualSleep += sleepDur;
            }
            else
            {
                //print error message saying you cant have negative sleep
            }
        }

        /* just grabs the workout object from DailyTarget
         */
        public Workout getWorkout() {

            return this.workout;
        }

        /* lets you update the workout information
         */
        public bool logWorkout(string type, float duration, string notes) {
            try
            {
                this.workout.workoutType = type;
                this.workout.duration = duration;
                this.workout.notes = notes;
                return true;
            }
            catch (Exception s)
            {
                return false;
            }
        }



        /* returns just the notes from meal, sleep and workout
         */
        public string getNotes()
        {
            string allNotes;
            allNotes =  "Meals: \n" + this.getMealNotes() + "\n" +
                    "Workout: " + this.workout.notes + "\n" +  "Sleep: " +
                    this.sleep.notes;
            return allNotes;
        }

        /* resets all logged information for the day to zero
         * actualCalories, actualSleep, actualWorkout, meals, and all notes 
         */
        public void resetLoggedInfo()
        {
            this.actualCalories = 0;
            this.actualSleep = 0;
            this.actualWorkout = 0;
            this.workout = new Workout();
            this.meals = new List<Meal>();
            this.sleep = new Sleep();
        }


        /*returns the whole toString of the object formatted 
         */
        public string toString()
        {
            return "Daily Target - " + DateTime.Now.ToShortDateString() + " \n"
                    + "Calorie Consumption Target: " + calorieTarget + " \t Actual Consumed: " + actualCalories + "\n"
                        + "\t notes: " + this.getMealNotes() + "\n"
                    + "Workout Target: " + workoutTarget + " \t Actual: " + actualWorkout + "\n"
                        + "\t notes: " + this.workout.notes + "\n"
                    + "Sleep Target: " + sleepTarget + " \t Actual: " + actualSleep + "\n"
                        + "\t notes: " + this.sleep.notes + "\n";
        }

    }

    public class Meal
    {
        public string mealName { get; set; }
        public string notes { get; set; }
        public int mealCalories { get; set; }
        public DateTime mealTime { get; set; }
    }


    public class Workout
    {
        public string workoutType { get; set; }
        public float duration { get; set; }
        public string notes { get; set; }

    }

    public class Sleep
    {
        public float duration { get; set; }
        public string notes { get; set; }

    }

    public class Performance
    {
        public int CalorieDeficit;
        public float WorkoutDeficit;
        public int SleepDeficit;

        public Performance(int calorieDeficit, float workoutDeficit, int sleepDeficit)
        {
            this.CalorieDeficit = calorieDeficit;
            this.WorkoutDeficit = workoutDeficit;
            this.SleepDeficit = sleepDeficit;
        }

        public virtual void CalcPerformance(int calorieTarget, float workoutTarget, int sleepTarget, int actualCalories,
            int actualWorkout, int actualSleep)
        {
            this.CalorieDeficit = calorieTarget - actualCalories;
            this.WorkoutDeficit = workoutTarget - actualWorkout;
            this.SleepDeficit = sleepTarget - actualSleep;
        }

        public class Daily : Performance
        {
            public Daily(int calorie, float workout, int sleep) : base(calorie, workout, sleep)
            { }

            public override void CalcPerformance(int calorieTarget, float workoutTarget, int sleepTarget,
                int actualCalories,
                int actualWorkout, int actualSleep)
            {
                this.CalorieDeficit = calorieTarget - actualCalories;
                this.WorkoutDeficit = workoutTarget - actualWorkout;
                this.SleepDeficit = sleepTarget - actualSleep;
            }
        }

        public class Weekly : Performance
        {
            public Weekly(int calorie, float workout, int sleep) : base(calorie, workout, sleep)
            { }


            //ADD FUNCTION TO FIND CURRENT WEEK FROM DATE 
            //TOTAL ALL DAILY TARGETS IN WEEK

            /*This method gets the current day, figures out what day in the week
             * it is, then gets the date for the start of that week
             * and queries the database for all the DailyResults from the
             * start of that week, up to the current day. It receives the DailyResults
             * objects in list, which it iterates through, calculating the difference
             * between each days targets and actual results, adding them up
             *
             */
            public  void CalculateWeekly()
            {
                //get which day of the week it is
                DayOfWeek todaysDate = DateTime.Today.DayOfWeek;

                // number of how many days to go back
                int total = 7 - (int)todaysDate;

                // get the date for however many days back
                DateTime otherDate = DateTime.Today.AddDays(-(int)todaysDate).Date;

                //Call Database method to get list of results within date range
                List<DailyResults> results = App.Database.GetDateRange(otherDate, DateTime.Today.Date).Result;

                //Go through list of results and do math to calculate the deficits
                foreach (DailyResults day in results)
                 {
   
                     int tempDayCalorieDeficit = day.caloriesLogged - day.calorieTarget;
                     int tempDayWorkoutDeficit = day.workoutLogged - day.workoutTarget;
                     int tempDaySleepDeficit = day.sleepLogged - day.sleepTarget;

                     this.CalorieDeficit += tempDayCalorieDeficit;
                     this.WorkoutDeficit += tempDayWorkoutDeficit;
                     this.SleepDeficit += tempDaySleepDeficit;

                 }
            }

        }


        public class Monthly : Performance
        {
            String Date = DateTime.Now.ToString();
            public Monthly(int calorie, float workout, int sleep) : base(calorie, workout, sleep)
            { }
            //ADD FUNCTION TO FIND CURRENT MONTH FROM DATE
            //TOTAL ALL DAILY TARGETS IN MONTH
        }

    }



}
