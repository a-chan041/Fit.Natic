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
            double value = args.NewValue;//Hello
            //displayLabel.Text = String.Format("", value);
        }

        void PageAppearing(System.Object sender, System.EventArgs e)
        {

        }
        void ContentPage_Disappearing(System.Object sender, System.EventArgs e)
        {
            App.appUser.saveToJsonAsync();
        }

    }
}
