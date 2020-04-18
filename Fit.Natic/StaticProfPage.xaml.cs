using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Fit.Natic
{
    public partial class StaticProfPage : ContentPage
    {
        public StaticProfPage()
        {
            this.BackgroundColor = Color.LightGray;
            InitializeComponent();
            BindingContext = App.appUser;
        }

        void ContentPage_Appearing(System.Object sender, System.EventArgs e)
        {
            this.BindingContext = App.appUser;
        }

        void ContentPage_Disappearing(System.Object sender, System.EventArgs e)
        {

        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ProfPage());
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;//Hello
                                         //displayLabel.Text = String.Format("", value);
        }
    }
}
