﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fit.Natic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityPage : ContentPage
    {
        public ActivityPage()
        {
            InitializeComponent();

            //Children.Add(new ProfPage());
            //Children.Add(new WorkoutsPage());
            //Children.Add(new RecipesPage());
        }

        public async void LogSleep (object sender, EventArgs e)
        {

            await Navigation.PushAsync(new SleepLogPage());

        }
    }
}