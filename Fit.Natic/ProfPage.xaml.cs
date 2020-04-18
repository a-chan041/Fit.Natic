using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Fit.Natic
{
    public partial class ProfPage : ContentPage
    {
        public ProfPage()
        {
            this.BackgroundColor = Color.LightGray;
            InitializeComponent();
            BindingContext = App.appUser;
        }
        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            CalorieLabel.Text = String.Format("{0}", value);
        }

        void OnSleepValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            SleepValue.Text = String.Format("{0}", value);
        }

        void PageAppearing(System.Object sender, System.EventArgs e)
        {

        }
        void ContentPage_Disappearing(System.Object sender, System.EventArgs e)
        {

        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            App.appUser.name = NameEntry.Text;
            App.appUser.gender = GenderEntry.Text;
            App.appUser.height = Convert.ToInt32(HeightEntry.Text);
            App.appUser.weight = Convert.ToInt32(WeightEntry.Text);
            App.todaysTarget.calorieTarget = Convert.ToInt32(CalorieSlider.Value);
            App.todaysTarget.workoutTarget = Convert.ToInt32(WorkoutTarget.Text);
            App.todaysTarget.sleepTarget = Convert.ToSingle(SleepSlider.Value);
            App.appUser.setDailyTarget(App.todaysTarget);

            Navigation.PopAsync();
        }
    }
}
