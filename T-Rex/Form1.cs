using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Media;
using System.Reflection.Metadata.Ecma335;



namespace T_Rex
{
    public partial class Form1 : Form
    {

        Image backgroundImage;
        Image backgroundImage2;
        int bgPositionX = 0, bgPositionY = 0, bg2PositionX = 0, cactusSpeed = 12, formWidth, attackTimer = 0, attackR = 0, score = 0, speed = 10;
        int[] flyingPosition = { 276, 350, 276, 350 };



        bool jumping = false, changeAnim = false, flyingAttack = false, gameover = false;
        Random random = new Random();
        List<PictureBox> obstacles = new List<PictureBox>();
        PictureBox hitBox = new PictureBox();
        PrivateFontCollection newFont = new PrivateFontCollection();
        SoundPlayer hitSound;
        SoundPlayer plusOneSound;




        public Form1()
        {

            InitializeComponent();
            GameSetUp();
            Reset();


        }


        private void KeyIsDown(object sender, KeyEventArgs e)
        {




            if (!gameover)
            {
                if (e.KeyCode == Keys.Up && !jumping)
                {
                    jumping = true;

                }



                if (e.KeyCode == Keys.Down && !jumping)
                {
                    if (changeAnim == false)


                    {
                        trex.Image = Properties.Resources.dino_crouch;

                        changeAnim = true;
                    }
                    trex.Top = 352;

                    changeAnim = false;
                }

                if (e.KeyCode == Keys.Enter && gameover)
                {


                    Reset();
                }






            }
        }





        private void KeyIsUp(object sender, KeyEventArgs e)
        {





            if (e.KeyCode == Keys.Down && !gameover)
            {


                trex.Image = Properties.Resources.dino_run;
                trex.Top = 313;
                changeAnim = false;


            }
            if (e.KeyCode == Keys.Enter && gameover)
            {
                Reset();
            }

        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            Graphics Canvas = e.Graphics;


           

            Canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;


        }



        private void GameTimerEvent(object sender, EventArgs e)
        {
            MoveBackgrounds();


            MoveObstacles();
            this.Invalidate(new Rectangle(bgPositionX, bgPositionY, Width, Height));

            lblScore.Text = "Score: " + score;

            hitBox.Left = trex.Right - (hitBox.Width + 20);

            hitBox.Top = trex.Top + 5;

            if (jumping)
            {
                trex.Top -= speed;

                if (trex.Top < 200)
                {

                    speed = -12;

                }
                if (trex.Top > 312)
                {

                    jumping = false;
                    trex.Top = 313;
                    speed = 10;

                }

            }
            foreach (PictureBox x in obstacles)
            {
                if (x.Bounds.IntersectsWith(hitBox.Bounds))
                {
                    GameTimer.Stop();
                    trex.Image = Properties.Resources.dead;
                    gameover = true;
                    trex.Top = 313;
                    gameend.Visible = true;


                }
            }


        }

        private void GameSetUp()
        {
            Width = 900;
            Height = 450;
            bg2PositionX = 900;
            backgroundImage2 = Properties.Resources.bgPixels;
            backgroundImage = Properties.Resources.bgPixels;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            formWidth = this.ClientSize.Width;
            this.BackColor = Color.LightGray;
            obstacles.Add(obstacle1);

            obstacles.Add(obstacle2);
            obstacles.Add(obstacle3);
            newFont.AddFontFile("font/pixel.ttf");
            lblScore.Font = new Font(newFont.Families[0], 30, FontStyle.Bold);
            lblScore.ForeColor = Color.White;
            lblScore.BackColor = Color.Transparent;
            lblScore.Text = "Score: 0";
            hitBox.BackColor = Color.Transparent;

            hitBox.Width = trex.Width / 2;
            hitBox.Height = trex.Height - 10;
            this.Controls.Add(hitBox);
           
            gameover = false;
            attackR = random.Next(12, 20);


        }

        private void Reset()
        {
            gameend.Visible = false;
            bgPositionX = 0;
            bg2PositionX = Width;
            trex.Image = Properties.Resources.dino_run;
            trex.Top = 313;
            obstacle1.Left = formWidth + random.Next(100, 200);
            obstacle2.Left = obstacle1.Left + random.Next(600, 800);
            obstacle3.Left = obstacle1.Left + random.Next(200, 200);
            GameTimer.Start();
            score = 0;
            attackTimer = 0;
            speed = 10;
            gameover = false;
            changeAnim = false;
            jumping = false;
            cactusSpeed = 12;
            this.Focus();


        }

        private void MoveBackgrounds()
        {
            bgPositionX -= 1;
            bg2PositionX -= 1;
            if (bgPositionX <= -Width)
            {
                bgPositionX = bg2PositionX + Width;
            }
            if (bg2PositionX <= -Width)
            {
                bg2PositionX = bg2PositionX + Width;
            }

        }

        private void MoveObstacles()
        {
            if (!flyingAttack)
            {
                obstacle1.Left -= cactusSpeed;
                obstacle2.Left -= cactusSpeed;
            }
            else
            {
                obstacle3.Left -= cactusSpeed;
            }
            if (attackTimer == attackR)
            {
                flyingAttack = true;
                attackR = random.Next(12, 20);
            }
            if (attackTimer == 0)
            {
                flyingAttack = false;
            }
            if (obstacle1.Left < -100)
            {
                obstacle1.Left = obstacle2.Left + obstacle2.Width + formWidth + random.Next(100, 300);
                attackTimer += 1;
                score += 1;

            }
            if (obstacle2.Left < -100)
            {
                obstacle2.Left = obstacle1.Left + obstacle1.Width + formWidth + random.Next(100, 300);
                attackTimer += 1;
                score += 1;

            }
            if (obstacle3.Left < -100)
            {
                obstacle3.Left = formWidth + random.Next(100, 300);
                obstacle3.Top = flyingPosition[random.Next(flyingPosition.Length)];
                attackTimer += 1;
                score += 1;

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
                 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)    
        {
             Reset();
        } 



        
       

        
       

        
        
            
            
               


            
        
    }
}
