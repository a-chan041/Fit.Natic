using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Fit.Natic
{
    public partial class ResourceNav : ContentPage
    {
        public ResourceNav()
        {
            InitializeComponent();
        }

        void Resources_Appearing(System.Object sender, System.EventArgs e)
        {
            if (App.firstTimeLaunched == true || App.resourcesPageViewed == false)
            {
                DisplayAlert("Resources", "Use this page to find recipes, workouts, and calorie calculators", "OK");
                App.resourcesPageViewed = true;
            }
        }

        void Resources_Disappearing(System.Object sender, System.EventArgs e)
        {
        }
    }
}
