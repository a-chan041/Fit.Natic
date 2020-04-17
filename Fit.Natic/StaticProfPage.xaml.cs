using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fit.Natic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StaticProfPage : ContentPage
    {
        public StaticProfPage()
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
            System.Console.WriteLine("contentPage disappering");
            App.appUser.name = Name.Text;
            App.appUser.gender = Gender.Text;
            App.appUser.saveToJsonAsync();
        }
    }
}