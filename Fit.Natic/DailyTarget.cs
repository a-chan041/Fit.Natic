using System;
using System.Collections.Generic;
namespace Fit.Natic
{
    // TODO: finish DailyTarget() method
    // TODO: decide if Workout, Sleep, Meal classes are public or inner class of Daily Target
    // TODO: finish removeMeal() method
    // TODO: decide if "actual" variables need to be stored in DailyTarget class or another (performance, etc.) 
    // TODO: create tests for objects and functions
    
    public class DailyTarget
    {
        public int calorieTarget;
        public int sleepTarget;
        public int workoutTarget;

        private Workout workout;
        private Sleep sleep;
        public List<Meal> meals;

        public DateTime date;

        // not sure if these 3 are needed or should be in Performance
        public int actualCalories; 
        public int actualSleep;
        public int actualWorkout;


        public DailyTarget()
        {
            this.calorieTarget = 0;
            this.sleepTarget = 8;
            this.workoutTarget = 30;

        }

        /*Adds a meal to the generic list of meals
         *  Takes the name of the meal as a string, number of calories as integer,
         *  and a string of the meal notes as parameters
         */
        public void addMeal(string name, int cals, string notes)
        {
            this.meals.Add(new Meal(name, cals, notes));
        }


        /* removes a meal from the generic list of meals
         *  returns true if successful, false if error
         */
        public Boolean removeMeal(Meal meal)
        {
            try
            {
                this.meals.Remove(meal);
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
        public void enterSleep(int sleepDur)
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


        /* returns just the notes from meal, sleep and workout
         */
        public string getNotes()
        {
            string allNotes;
            allNotes = this.getMealNotes() + this.workout.notes + this.sleep.notes;
            return allNotes;
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
        public DateTime mealTime;

        public Meal()
        {
            this.mealName = "poop chicken";
            this.notes = "tasted shitty";
            this.mealCalories = 1000;
            this.mealTime = DateTime.Now;
        }

        public Meal(string name, int calories, string mealNotes)
        {
            this.mealName = name;
            this.mealCalories = calories;
            this.notes = mealNotes;
            this.mealTime = DateTime.Now;
        }
    }


    public class Workout
    {
        public string workoutType;
        public float duration { get; set; }
        public string notes { get; set; }

        public Workout()
        {
            this.workoutType = "none";
            this.duration = 0;
            this.notes = "";
        }
    }

    public class Sleep
    {
        public float duration { get; set; }
        public string notes { get; set; }

        public Sleep()
        {
            this.duration = 0;
            this.notes = "";
        }
    }





}
