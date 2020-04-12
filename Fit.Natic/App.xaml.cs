using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fit.Natic
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ActivityPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
