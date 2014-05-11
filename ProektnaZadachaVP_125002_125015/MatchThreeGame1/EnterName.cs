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
    public partial class EnterName : Form
    {
        public Igrach igrach
        {
            get;
            set;
        }
        public EnterName()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
        }
        private void playSoundFromResource()
        {
            SoundPlayer sndPing = new SoundPlayer(Resources.ding);
            sndPing.Play();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                playSoundFromResource();
                Igrach i = new Igrach();
                i.Ime = textBox1.Text;
                igrach = i;
                this.Close();
                ChooseLevel forma = new ChooseLevel(i.Ime);
                forma.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            playSoundFromResource();
            Igrach i = new Igrach();
            i.Ime = textBox1.Text;
            igrach = i;
            this.Close();
            ChooseLevel forma = new ChooseLevel(i.Ime);
            forma.Show();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

    }
}
