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
        }
        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;//Hello
            //displayLabel.Text = String.Format("", value);
        }

    }
}
