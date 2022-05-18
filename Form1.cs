using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman_v2
{
    public partial class Form1 : Form
    {

        bool goup, godown, goleft, goright, isGameOver;

        int score, playspeed, Alphaspeed, Betaspeed, GamaX, GamaY;

        private void Alpha_Click(object sender, EventArgs e)
        {

        }

        private void Gama_Click(object sender, EventArgs e)
        {

        }

        private void Beta_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();

            resetgame();

        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                goup = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }


        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }

            if(e.KeyCode == Keys.Enter && isGameOver == true)
            {
                resetgame();
            }
        }

        private void maingametimer(object sender, EventArgs e)
        {
            txtscore.Text = "score: " + score;

            if (goleft == true)
            {
                Pacman.Left -= playspeed;
                Pacman.Image = Properties.Resources.left;
            }

            if (goright == true)
            {
                Pacman.Left += playspeed;
                Pacman.Image = Properties.Resources.right;
            }

            if (godown == true)
            {
                Pacman.Top += playspeed;
                Pacman.Image = Properties.Resources.down;
            }

            if (goup == true)
            {
                Pacman.Top -= playspeed;
                Pacman.Image = Properties.Resources.Up;
            }

            if(Pacman.Left < -10)
            {
                Pacman.Left = 680;
            }

            if(Pacman.Left > 680)
            {
                Pacman.Left = -10;
            }

            if(Pacman.Top < -10)
            {
                Pacman.Top = 550; 
            }

            if(Pacman.Top > 550)
            {
                Pacman.Top = -0;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if ((string)x.Tag == "coin" && x.Visible == true)
                    {
                        if (Pacman.Bounds.IntersectsWith(x.Bounds))
                        {

                            score += 1;
                            x.Visible = false;
                             
                        }

                    }

                    if((string)x.Tag == "wall")
                    {
                        if (Pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameover("YOU LOSE!!");
                        }
                    }

                    if((string)x.Tag == "ghost")
                    {
                        if (Pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameover("YOU LOSE!!");
                        }

                    }
                }
            }

            // moving ghost

            Alpha.Left += Alphaspeed;

            if(Alpha.Bounds.IntersectsWith(pictureBox4.Bounds) || Alpha.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                Alphaspeed = -Alphaspeed; 
            }

            Beta.Left -= Betaspeed;

            if (Beta.Bounds.IntersectsWith(pictureBox2.Bounds) || Beta.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                Betaspeed = -Betaspeed;
            }

            Gama.Left -= GamaX;
            Gama.Top -= GamaY;

            if(Gama.Top < 0 || Gama.Top > 520)
            {
                GamaY = -GamaY;
            }

            if(Gama.Left < 0 || Gama.Left > 620)
            {
                GamaX = -GamaX;
            }

            if (score == 57)
            {
                gameover("YOU WIN!!");
            }

        }

        private void resetgame()
        {

            txtscore.Text = "Score: 0";
            score = 0;

            Alphaspeed = 5;
            Betaspeed = 5;
            GamaX = 5;
            GamaY = 5;
            playspeed = 7;

            isGameOver = false;

            Pacman.Left = 31;
            Pacman.Top = 46;

            Alpha.Left = 439;
            Alpha.Top = 55;

            Beta.Left = 224;
            Beta.Top = 451;

            Gama.Left = 527;
            Gama.Top = 207;

            foreach (Control x in this.Controls)

            {
                if (x is PictureBox)
                {
                    x.Visible = true;
                }
            }
            GameTimer.Start();

        }


        private void gameover(string message)
        {
            isGameOver = true;
            GameTimer.Stop();

            txtscore.Text = "score: " + score + Environment.NewLine + message;

        }
    }

}
            

        
            