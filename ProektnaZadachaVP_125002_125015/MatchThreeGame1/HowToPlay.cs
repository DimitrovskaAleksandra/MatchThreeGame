using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MatchThreeGame.Properties;
using System.Media;

namespace MatchThreeGame
{
    public partial class HowToPlay : Form
    {
        public HowToPlay()
        {
            InitializeComponent();
            textBox1.Text = "This game is a puzzle game. There are 3 stages of passing. The first stage is with simple squares .You need to match 3 or more objects by exchanging two pieces. On every 10 seconds the matched pieces will disappear and then will be generated the new group of pieces. The exchanging of two pieces is consisted of clicking with the left button on the mouse and then choose another which is one row up or down or is one column on left or right, also with clicking on the left button. When you click on the first piece, it is selected and then when you click on the second piece, if they are neighbors they will change their places.  ";
            button1.Text = "Next";
            button1.Image = Resources.desno;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            flag = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public bool flag=true;
        private void button1_Click(object sender, EventArgs e)
        {
            playSoundFromResource();
            if(flag)
            {
                textBox1.Text = "If they are not neighbors the selected object will be unselected. For every hit you get points. The first level is 2 minutes. For two minutes you must matched as much pieces as possible. After that is the next level where the pieces are types of fruit. And when you complete the second level you continue with the last one.  ";
                button1.Text = "Prev";
            button1.Text = "Prev";
            button1.Image = Resources.levo;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
                flag=false;
            }
            else if (!flag)
            {
                textBox1.Text = "This game is a puzzle game. There are 3 stages of passing. The first stage is with simple squares .You need to match 3 or more objects by exchanging two pieces. On every 10 seconds the matched pieces will disappear and then will be generated the new group of pieces. The exchanging of two pieces is consisted of clicking with the left button on the mouse and then choose another which is one row up or down or is one column on left or right, also with clicking on the left button. When you click on the first piece, it is selected and then when you click on the second piece, if they are neighbors they will change their places. ";
                button1.Text="Next";
                button1.Image = Resources.desno;
                button1.ImageAlign = ContentAlignment.MiddleLeft;
                flag=true;
            }
        }
        private void playSoundFromResource()
        {
            SoundPlayer sndPing = new SoundPlayer(Resources.btnClick);
            sndPing.Play();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
