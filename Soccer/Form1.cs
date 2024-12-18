using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace Soccer
{
    public partial class Soccer : Form
    {
        //Global Variables
        Rectangle player1 = new Rectangle(10, 130, 20, 20);
        Rectangle player2 = new Rectangle(330, 130, 20, 20);
        Rectangle ball = new Rectangle(160, 100, 25, 25);

        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 3;
        int ballXSpeed = 4;
        int ballYSpeed = -4;

        bool wPressed = false;
        bool sPressed = false;
        bool upArrowPressed = false;
        bool downArrowPressed = false;

        bool aPressed = false;
        bool dPressed = false;
        bool leftArrowPressed = false;
        bool rightArrowPressed = false;

        SolidBrush whiteBrush = new SolidBrush(Color.White);


        SoundPlayer Goal = new SoundPlayer(Properties.Resources.cheer);
        SoundPlayer Hit = new SoundPlayer(Properties.Resources.hit);

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = true;
                    break;
                case Keys.S:
                    sPressed = true;
                    break;
                case Keys.Up:
                    upArrowPressed = true;
                    break;
                case Keys.Down:
                    downArrowPressed = true;
                    break;
                case Keys.A:
                    aPressed = true;
                    break;
                case Keys.Left:
                    leftArrowPressed = true;
                    break;
                case Keys.D:
                    dPressed = true;
                    break;
                case Keys.Right:
                    rightArrowPressed = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.Up:
                    upArrowPressed = false;
                    break;
                case Keys.Down:
                    downArrowPressed = false;
                    break;
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.Left:
                    leftArrowPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;
                case Keys.Right:
                    rightArrowPressed = false;
                    break;
            }


        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            ball.X += ballXSpeed;
            ball.Y += ballYSpeed;

            if (wPressed == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }




            if (aPressed == true && player1.X > 0)
            {
                player1.X -= playerSpeed;
            }

            if (dPressed == true && player1.X < this.Width - player1.Width)
            {
                player1.X += playerSpeed;
            }




            if (leftArrowPressed == true && player2.X > 0)
            {
                player2.X -= playerSpeed;
            }

            if (rightArrowPressed == true && player2.X < this.Width - player2.Width)
            {
                player2.X += playerSpeed;
            }





            if (sPressed == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }

            if (upArrowPressed == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowPressed == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }











            if (ball.Y < 0 || ball.Y > 280 - ball.Height)
            {
                ballYSpeed *= -1;
            }

            if (ball.X < 0 || ball.X > this.Width - ball.Width)
            {
                ballXSpeed *= -1;
            }


            if (player1.IntersectsWith(ball))

            {
                Rectangle topRec = new Rectangle(player1.X, player1.Y - 5, 20, 5);
                Rectangle rightRec = new Rectangle(player1.X + 25, player1.Y, 5, 20);
                Rectangle bottomRec = new Rectangle(player1.X, player1.Y + 25, 20, 5);
                Rectangle leftRec = new Rectangle(player1.X - 5, player1.Y, 5, 20);

                if (ball.IntersectsWith(topRec))
                {
                    ballYSpeed *= -1;
                    ball.Y = player1.Y - ball.Height;

                }

                if (ball.IntersectsWith(rightRec))
                {
                    ballXSpeed *= -1;
                    ball.X = player1.X + player1.Width;

                }

                if (ball.IntersectsWith(bottomRec))
                {
                    ballYSpeed *= -1;
                    ball.Y = player1.Y + player1.Height;

                }

                if (ball.IntersectsWith(leftRec))
                {
                    ballXSpeed *= -1;
                    ball.X = player1.X - ball.Width;

                }

                Hit.Play();


            }

            else if (player2.IntersectsWith(ball))
            {
                Rectangle topRec2 = new Rectangle(player2.X, player2.Y - 5, 20, 5);
                Rectangle rightRec2 = new Rectangle(player2.X + 20, player2.Y, 5, 20);
                Rectangle bottomRec2 = new Rectangle(player2.X, player2.Y + 25, 20, 5);
                Rectangle leftRec2 = new Rectangle(player2.X - 5, player2.Y, 5, 20);

                if (ball.IntersectsWith(topRec2))
                {
                    ballYSpeed *= -1;
                    ball.Y = player2.Y - ball.Height;
                }

                if (ball.IntersectsWith(rightRec2))
                {
                    ballXSpeed *= -1;
                    ball.X = player2.X + player2.Width;
                }

                if (ball.IntersectsWith(bottomRec2))
                {
                    ballYSpeed *= -1;
                    ball.Y = player2.Y + player2.Height;
                }

                if (ball.IntersectsWith(leftRec2))
                {
                    ballXSpeed *= -1;
                    ball.X = player2.X - ball.Width;
                }

                Hit.Play();
                ;
            }


            if (ball.X < 0 && 180 > ball.Y && ball.Y > 100)
            {
                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";

                ball.X = 170;
                ball.Y = 110;


                player1.Y = 110;
                player2.Y = 110;
                player1.X = 10;
                player2.X = 330;

                Goal.Play();

                Thread.Sleep(1000);
               // Refresh();

            }

            else if (ball.X > 340 && 180 > ball.Y && ball.Y > 100)
            {
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";

                ball.X = 120;
                ball.Y = 110;

                player1.Y = 110;
                player2.Y = 110;
                player1.X = 10;
                player2.X = 330;

                Goal.Play();

                Thread.Sleep(1000);
              //  Refresh();

            }

            if (player1Score == 3)
            {
                endLabel.Text = "Player 1 wins!";
                gameTimer.Stop();
            }

            if (player2Score == 3)
            {
                endLabel.Text = "Player 2 wins!";
                gameTimer.Stop();
            }

            if (ball.Y > this.Height)
            {
                ball.Y = this.Height - ball.Height;
            }

            if (ball.Y < 0)
            {
                ball.Y = 0;
            }

            if (ball.X > this.Width)
            {
                ball.X = this.Width - ball.Width;
            }

            if (ball.X < 0)
            {
                ball.X = 0 ;
            }

            Refresh();
        }

        public Soccer()
        {
            InitializeComponent();
        }
        private void Soccer_Load(object sender, EventArgs e)
        {

        }

        private void Soccer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(whiteBrush, player1);
            e.Graphics.FillRectangle(whiteBrush, player2);
            e.Graphics.FillEllipse(whiteBrush, ball);
            e.Graphics.FillRectangle(whiteBrush, 180, 0, 15, this.Height);
            e.Graphics.FillRectangle(whiteBrush, 0, 100, 10, 80);
            e.Graphics.FillRectangle(whiteBrush, 362, 100, 10, 80);

        }

        private void p2ScoreLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
