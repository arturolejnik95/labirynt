using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace labirynt
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        void OnLevelValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            levelLabel.Text = Math.Ceiling(((Slider)sender).Value + 1).ToString("F0");
        }

        void OnLifesValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            lifesLabel.Text = Math.Ceiling(((Slider)sender).Value + 1).ToString("F0");
        }

        async void OnButtonClickedAsync(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new FirstLevel(lifesLabel.Text.ToString(), levelLabel.Text.ToString()));
        }
    }
}
