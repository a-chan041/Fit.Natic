using System;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;
namespace Fit.Natic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityPage : ContentPage
    {
        Performance.Daily daily_stats;
        Performance.Weekly weekly_stats;
        Performance.Monthly monthly_stats;
        public ActivityPage()
        {
            InitializeComponent();
            daily_stats = new Performance.Daily(0,0,0);
            weekly_stats = new Performance.Weekly(0,0,0);
            monthly_stats = new Performance.Monthly(0,0,0);
            loadCharts();
        }

        public void loadCharts()
        {
            daily_stats.CalcPerformance(App.todaysTarget.calorieTarget, App.todaysTarget.workoutTarget,App.todaysTarget.sleepTarget, App.todaysTarget.actualCalories, App.todaysTarget.actualWorkout,App.todaysTarget.actualSleep);
            weekly_stats.CalculateWeekly();
            monthly_stats.CalculateMonthly();

            var dailyEntries = new[]
            {
                new Entry((1 - (daily_stats.SleepDeficit / App.todaysTarget.sleepTarget)) * 100)
                {
                    Label = "Sleep (hrs)",

                    ValueLabel = App.todaysTarget.actualSleep.ToString(),
                    Color = SKColor.Parse("#70fbf0")
                },


                new Entry((1-(daily_stats.CalorieDeficit / App.todaysTarget.calorieTarget))*100)
                {
                    Label = "Calories",
                    ValueLabel = App.todaysTarget.actualCalories.ToString(),
                    Color = SKColor.Parse("#cc3366")
                },

                new Entry((1-(daily_stats.WorkoutDeficit / App.todaysTarget.workoutTarget))*100)
                {
                    Label = "Workout (min)",
                    ValueLabel =  App.todaysTarget.actualWorkout.ToString(),
                    Color = SKColor.Parse("#c3e949")
                }
            };

            var weeklyEntries = new[]
            {
                new Entry(weekly_stats.SleepDeficit)
                {

                    Color = SKColor.Parse("#70fbf0")
                },


                new Entry(weekly_stats.CalorieDeficit)
                {
                    Color = SKColor.Parse("#cc3366")
                },

                new Entry(weekly_stats.WorkoutDeficit)
                {
                    Color = SKColor.Parse("#c3e949")
                }
            };

            var monthlyEntries = new[]
            {
                new Entry(monthly_stats.SleepDeficit)
                {

                    Color = SKColor.Parse("#70fbf0")
                },


                new Entry(monthly_stats.CalorieDeficit)
                {
                    Color = SKColor.Parse("#cc3366")
                },

                new Entry(monthly_stats.WorkoutDeficit)
                {
                    Color = SKColor.Parse("#c3e949")
                }
            };

            TodayChart.Chart = new RadialGaugeChart { Entries = dailyEntries, LabelTextSize = 40, };
            WeekChart.Chart = new RadialGaugeChart { Entries = weeklyEntries  };
            MonthChart.Chart = new RadialGaugeChart { Entries = monthlyEntries};

        }

        public async void LogSleep (System.Object sender, EventArgs e)
        {

            await Navigation.PushAsync(new SleepLogPage());

        }


        void LogWorkout(System.Object sender, System.EventArgs e)
        {

        }

        void LogMeal(System.Object sender, System.EventArgs e)
        {

        }

        void ContentPage_Appearing(System.Object sender, System.EventArgs e)
        {
            //check if its first time launching the app
            if(App.firstTimeLaunched == true || App.statsPageViewed == false )
            {
                DisplayAlert("Resources", "This page has buttons where you can log your meals, calories, and sleep. Below there are charts where you can track your progress!", "OK");
                App.statsPageViewed = true;
            }
            //want to reload charts in case anything has changed since leaving / coming back to the page
            loadCharts();
        }

        void ContentPage_Disappearing(System.Object sender, System.EventArgs e)
        {

        }
    }
}
