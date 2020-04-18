using System;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
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
            if (App.firstTimeLaunched == true)
            {
                Navigation.PushAsync(new Page1());
            }

            daily_stats = new Performance.Daily(0, 0, 0);
            weekly_stats = new Performance.Weekly(0, 0, 0);
            monthly_stats = new Performance.Monthly(0, 0, 0);
            InitializeComponent();
            loadCharts();
        }

        public async Task loadCharts()
        {
            daily_stats.CalcPerformance();
            await weekly_stats.CalculateWeekly();
            await monthly_stats.CalculateMonthly();

            var dailyEntries = new[]
            {
                new Entry(daily_stats.SleepDeficit)
                {
                    Label = "Sleep (hrs)",
                    ValueLabel = App.todaysTarget.actualSleep.ToString(),
                    Color = SKColor.Parse("#2eb9db")
                },


                new Entry(daily_stats.CalorieDeficit)
                {
                    Label = "Calories",
                    ValueLabel = App.todaysTarget.actualCalories.ToString(),
                    Color = SKColor.Parse("#e63076")
                },

                new Entry(daily_stats.WorkoutDeficit)
                {
                    Label = "Workout (min)",
                    ValueLabel =  App.todaysTarget.actualWorkout.ToString(),
                    Color = SKColor.Parse("#a5ed18")
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

            TodayChart.Chart = new RadialGaugeChart { Entries = dailyEntries, LabelTextSize = 40, MaxValue = 100};
            WeekChart.Chart = new RadialGaugeChart { Entries = weeklyEntries, MaxValue = 100 };
            MonthChart.Chart = new RadialGaugeChart { Entries = monthlyEntries, MaxValue = 100 };

        }

        public async void LogSleep (System.Object sender, EventArgs e)
        {

            await Navigation.PushAsync(new SleepLogPage());

        }


        public async void LogWorkout(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new WorkoutLogPage());
        }

        public async void LogMeal(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MealLogPage());
        }

        void ContentPage_Appearing(System.Object sender, System.EventArgs e)
        {
            //App.appUser.setDailyTarget(App.todaysTarget);

            //check if its first time launching the app
            if (App.firstTimeLaunched == true || App.statsPageViewed == false )
            {
        //        DisplayAlert("Activity", "This page has buttons where you can log your meals, calories, and sleep. Below there are charts where you can track your progress!", "OK");
                App.statsPageViewed = true;
            }
            //want to reload charts in case anything has changed since leaving / coming back to the page
            Task.Run(async () => { await loadCharts(); });
        }

        void ContentPage_Disappearing(System.Object sender, System.EventArgs e)
        {

        }
    }
}
