using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Numerics;
using System.Diagnostics;

namespace labirynt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstLevel : ContentPage
    {
        float GRAVITY;

        float life;
        float level;

        bool isStarted = false;
        bool isCollision = false;
        bool isEnd = false;


        TimeSpan lastTime;

        Vector3 accelerator;
        Vector2 ballPosition;
        Vector2 ballStart;
        Vector2 ballDirection = Vector2.Zero;
        
        Stopwatch stoper = new Stopwatch();

        public FirstLevel(String lifeLabel, String levelLabel)
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            life = float.Parse(lifeLabel);
            level = float.Parse(levelLabel);

            ballStart = new Vector2(float.Parse(ball.X.ToString()), float.Parse(ball.Y.ToString()));
            ballPosition = new Vector2(ballStart.X, ballStart.Y);

            GRAVITY = (level - 6) * 100 + 1000;

            Accelerometer.ReadingChanged += (sender, args) =>
            {
                accelerator = 0.5f * args.Reading.Acceleration + 0.5f * accelerator;
            };

            Device.StartTimer(TimeSpan.FromMilliseconds(33), () =>
            {
                TimeSpan newTime = stoper.Elapsed;
                float delta = (float)(newTime - lastTime).TotalSeconds;
                lastTime = newTime;

                if (isStarted)
                {
                    MoveBall(delta);
                    if (isCollision)
                    {
                        if(life == 0.0)
                        {
                            LoseGame();
                        }
                        life--;
                        ballPosition = new Vector2(ballStart.X, ballStart.Y);
                        ballDirection = Vector2.Zero;
                    } else if (!isCollision && isEnd)
                    {
                        WinGame();
                    }

                } 
                
                
                return true;
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                Accelerometer.Start(SensorSpeed.Default);
            }
            catch
            {
                Label label = new Label
                {
                    Text = "Błąd! Akcelerometr nie jest dostępny.",
                    FontSize = 24,
                    TextColor = Color.White,
                    BackgroundColor = Color.Black,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Margin = new Thickness(48, 0)
                };

                gameScreen.Children.Add(label,
                    new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize),
                    AbsoluteLayoutFlags.PositionProportional);
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Accelerometer.Stop();
            stoper.Stop();
        }

        void OnSizeChanged(object sender, EventArgs args)
        {
            if (Width > 0 && Height > 0)
            {
                gameScreen.SizeChanged -= OnSizeChanged;
            }
        }

        private void MoveBall(float delta)
        {
            float time = delta;

            Vector2 pos = ballPosition;
            Vector2 dir = ballDirection;

            Vector2 acc = GRAVITY * new Vector2(-accelerator.X, accelerator.Y);
            Vector2 newPos = new Vector2();
            Vector2 newDir = new Vector2();

            newPos = pos + dir * time + 0.5f * acc * time * time;
            newDir = dir + acc / time;

            ballPosition = newPos;
            ballDirection = newDir;

            ball.TranslateTo(ballPosition.X, ballPosition.Y);

            CheckCollision();
            CheckEnd();
        }

        private void CheckEnd()
        {
            if (ball.Bounds.IntersectsWith(meta.Bounds))
            {
                isEnd = true;
            }
        }

        private void CheckCollision()
        {
            if (ball.Bounds.IntersectsWith(wall1.Bounds) ||
                ball.Bounds.IntersectsWith(wall2.Bounds) ||
                ball.Bounds.IntersectsWith(wall3.Bounds) ||
                ball.Bounds.IntersectsWith(wall4.Bounds) ||
                ball.Bounds.IntersectsWith(wallin1.Bounds) ||
                ball.Bounds.IntersectsWith(wallin2.Bounds) ||
                ball.Bounds.IntersectsWith(wallin3.Bounds) ||
                ball.Bounds.IntersectsWith(wallin4.Bounds) ||
                ball.Bounds.IntersectsWith(wallin5.Bounds))
            {
                isCollision = true;
            }
        }

        private void LoseGame()
        {
            new NavigationPage(new MainPage());
        }

        private void WinGame()
        {
            new NavigationPage(new MainPage());
        }


    }
}