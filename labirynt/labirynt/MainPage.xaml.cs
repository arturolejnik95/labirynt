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
            InitializeComponent();
        }

        void OnLevelValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            levelLabel.Text = String.Format("{0}", Math.Ceiling(value+1));
        }

        void OnLivesValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            livesLabel.Text = String.Format("{0}", Math.Ceiling(value+1));
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            //TO DO
        }
    }
}
