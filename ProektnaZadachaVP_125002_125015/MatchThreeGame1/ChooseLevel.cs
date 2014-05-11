using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using MatchThreeGame.Properties;

namespace MatchThreeGame
{
    public partial class ChooseLevel : Form
    {
        string currPlayer;
        int poinnts = 0;
        public ChooseLevel(string igrac )
        {
            currPlayer = igrac;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void playSoundFromResource()
        {
            SoundPlayer sndPing = new SoundPlayer(Resources.ding);
            sndPing.Play();
        }

        private void playSoundFromResource1()
        {
            SoundPlayer sndPing = new SoundPlayer(Resources.btnClick);
            sndPing.Play();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            playSoundFromResource();
            label2.Font = new Font("Arial Rounded MT Bold",35);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Level1 l1 = new Level1(currPlayer, poinnts);
            l1.Show();
            this.Close();
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            playSoundFromResource();
            label2.Font=new Font("Arial Rounded MT Bold",26);
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            playSoundFromResource();
            label3.Font = new Font("Arial Rounded MT Bold", 35);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.Font = new Font("Arial Rounded MT Bold", 26);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.Font = new Font("Arial Rounded MT Bold", 26);
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            playSoundFromResource();
            label4.Font = new Font("Arial Rounded MT Bold", 35);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            playSoundFromResource1();
            MessageBox.Show("You must pass first level!");
        }

        private void label4_Click(object sender, EventArgs e)
        {
            playSoundFromResource1();
            MessageBox.Show("You must first pass previous levels!");
        }
    }
}
