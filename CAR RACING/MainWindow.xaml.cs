using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CAR_RACING
{
   
    public partial class MainWindow : Window
    {


        
       DispatcherTimer gameTimer = new DispatcherTimer();
        List<Rectangle> itemRemover = new List<Rectangle>();

        Random rand = new Random();

        ImageBrush playerImage = new ImageBrush();
        ImageBrush starImage = new ImageBrush();

        Rect playerHitBox;

        int speed = 15;
        int playerSpeed = 13;
        int carNum;
        int starCounter = 30;
        int powerModeCounter = 200;

        double score;
        double i;
        bool moveLeft, moveRight, gameOver, powerMode;





            

        
        



        public MainWindow()
        {
            InitializeComponent();

            myCanvas.Focus();

            gameTimer.Tick += GameLoop;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);

            StartGame();



        }

        private void GameLoop(object? sender, EventArgs e)
        {
            score += .05;

            starCounter -= 1;

            scoreText.Content = "Survived: " + score.ToString("#.#") + "s";

            playerHitBox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player),Player.Width,Player.Height);

            if (moveLeft == true && Canvas.GetLeft(Player) > 0)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - playerSpeed);

            }
            if (moveRight == true && Canvas.GetLeft(Player) + 90 < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + playerSpeed);
            }
            
            if (starCounter < 1)
            {
                MakeStar();
                starCounter = rand.Next(600, 900);
            }
            
            foreach (var x in myCanvas.Children.OfType<Rectangle>())
            {
                if((string) x.Tag == "roadMarks")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + speed);
                    
                        if(Canvas.GetTop(x) > 510)
                        {
                            Canvas.SetTop(x, -152);

                        }
                    
                    
                       
                   
                }

                if((string) x.Tag =="Car")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) +speed);
                    if (Canvas.GetTop(x)>500)
                    {
                       

                        ChangeCars(x);
                    }

                    Rect carHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);  

                    if (playerHitBox.IntersectsWith(carHitBox) &&powerMode==true)
                    {
                        ChangeCars(x);

                    }
                    else if(playerHitBox.IntersectsWith(carHitBox)&&powerMode==false)
                    {
                        gameTimer.Stop();
                        scoreText.Content += "Press Enter to replay";
                        gameOver = true;
                    }

                }

                if((string)x.Tag=="star")
                {
                    Canvas.SetTop(x,Canvas .GetTop(x) + speed);

                    Rect starHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (playerHitBox.IntersectsWith(starHitBox))
                    {
                        itemRemover.Add(x); 
                        powerMode=true;
                        powerModeCounter = 200;

                    }

                    if (Canvas.GetTop(x)>400)
                    {  
                        itemRemover.Add(x);
                    }
                }

            }
            if (powerMode == true)
            {
                powerModeCounter -= 1;
                PowerUp();
                if (powerModeCounter < 1)
                {
                    powerMode = false;
                }
            }
            else
            {
                playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/ASSETS/MyCar.png"));
                myCanvas.Background = Brushes.Gray;

            }
            foreach(Rectangle y in itemRemover)
            {
                myCanvas.Children.Remove(y);
            }


            if(score >= 10 && score < 20)
            {
                speed = 15;

            }
            if(score >= 20 && score<30)
            {
                speed = 17;
            }
            if (score >= 30 && score < 40)
            {
                speed = 19;
            }
            if (score >= 40 && score < 50)
            {
                speed = 21;
            }
            if (score >= 50 && score < 80)
            {
                speed = 23;
            }

            if(gameOver)
            {
                EndScreen.Visibility = Visibility.Visible;
                SurvivalTimeText.Text = $"Survived: {score.ToString("#.#")} Seconds";
                gameTimer.Stop();

                Storyboard fadeInStoryboard = (Storyboard)FindResource("FadeIn");
                fadeInStoryboard.Begin();
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            { 
                moveLeft = true;
            }
            if (e.Key == Key.Right)
            {
                moveRight = true;


            }










        }
        
            






        
        
         
            
               
            
          
            
        
            
                

            
            //this game was very hard to code using only c# without using any other game engine like unity so please consider voting

            
            
                
        

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                moveLeft = false;
            }
            if (e.Key == Key.Right)
            {
                moveRight = false;
            }

            if (e.Key == Key.Enter && gameOver == true)
            {
                StartGame();
            }










        }

        
        

        private void StartGame()
        {

            EndScreen.Visibility = Visibility.Collapsed;


            speed = 8;
            gameTimer.Start();

            moveLeft = false;
            moveRight = false;
            gameOver = false;
            powerMode = false;

            score = 0;

            scoreText.Content = "Survived: 0 Seconds";

            playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/ASSETS/MyCar.png"));
            starImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/ASSETS/star.png"));

            Player.Fill = playerImage;


            myCanvas.Background = Brushes.Gray;
            
            foreach (var x in myCanvas.Children.OfType<Rectangle>())
            {

                if ((string)x.Tag == "Car")
                {
                    Canvas.SetTop(x, (rand.Next(100, 400) * -1));
                    Canvas.SetLeft(x, rand.Next(0, 430));
                    ChangeCars(x);


                }




                if ((string)x.Tag == "star")
                {
                    itemRemover.Add(x);
                }






            }
            itemRemover.Clear();







                    
           

            







            














        }





        
         
            




        

        private void ChangeCars(Rectangle car)
        {
            carNum = rand.Next(1, 6);

            ImageBrush carImage = new ImageBrush();

            switch (carNum)
            {
                case 1:
                    carImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/car1.png"));
                    break;
                case 2:
                    
                    carImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/car1.png"));
                    break;
                case 3:
                    carImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/car3.png"));
                    break;
                case 4:
                    carImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/car4.png"));
                    break;
                case 5:
                    carImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/car5.png"));
                    break;
                case 6:
                    carImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/car6.png"));
                    break;








                      



































            }
            car.Fill = carImage;

            Canvas.SetTop(car, (rand.Next(100, 400) * -1));
            Canvas.SetLeft(car, rand.Next(0, 430));






























        }
        private void PowerUp() 
        {
            i += .5;

            if (i > 4)
            {
                i = 1;
            }

            switch (i)
            {
                case 1:
                    playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/car2.png"));
                    break;
                case 2:
                    playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/car2.png"));
                    break;
                case 3:
                    playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/car2.png"));
                    break;
                case 4:
                    playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/car2.png"));
                    break;




            }
            
            myCanvas.Background = Brushes.MediumPurple;
                








        }
        private void MakeStar()
        {

            Rectangle newstar = new Rectangle
            {
                Height = 50,
                 Width = 50,
                 Tag = "star",
                 Fill= starImage



            };
            Canvas.SetLeft(newstar, rand.Next(0, 430));
            Canvas.SetTop(newstar, (rand.Next(100, 400) * -1));

            myCanvas.Children.Add(newstar);










        }
        




    }
}