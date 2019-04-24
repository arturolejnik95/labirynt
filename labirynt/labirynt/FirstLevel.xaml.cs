using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using OpenTK;
using Xamarin.Formsbook.Platform;

namespace labirynt
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FirstLevel : ContentPage
	{
        Vector3 accelerator;
        Vector2 ballPosition;
        Vector2 ballDirection;

		public FirstLevel ()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
        }
        /*
                protected override void OnAppearing()
                {
                    base.OnAppearing();
                    try
                    {
                        OrientationSensor.Start(SensorSpeed.UI);
                    }
                    catch (FeatureNotSupportedException fnsEx)
                    {
                        // Feature not supported on device
                    }
                    catch (Exception ex)
                    {
                        // Other error has occurred.
                    }

                }

                protected override void OnDisappearing()
                {
                    base.OnDisappearing();
                    try
                    {
                        OrientationSensor.Stop();
                    }
                    catch (FeatureNotSupportedException fnsEx)
                    {
                        // Feature not supported on device
                    }
                    catch (Exception ex)
                    {
                        // Other error has occurred.
                    }
                }
        */
        async void OnSizeChanged(object sender, EventArgs args)
        {
            if (Width > 0 && Height > 0)
            {
                Game((float)gameScreen.Width, (float)gameScreen.Height);

                gameScreen.SizeChanged -= OnSizeChanged;
            }
        }

        async protected void Game(float w, float h)
        {
            //TODO
        }


    }
}