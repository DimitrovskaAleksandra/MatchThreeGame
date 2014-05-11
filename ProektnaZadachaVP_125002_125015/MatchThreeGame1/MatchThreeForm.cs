using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using MatchThreeGame.Properties;

namespace MatchThreeGame
{
    public partial class MatchThreeForm : Form
    {

        public static List<Igrach> igrachi;

        public MatchThreeForm()
        {
            InitializeComponent();
            igrachi = new List<Igrach>();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //using (var soundPlayer = new SoundPlayer(@"d:\sound1.mp3"))
            //{

            //    soundPlayer.Play(); // can also use soundPlayer.PlaySync()
            //}
            EnterName forma = new EnterName();
            playSoundFromResource();
            forma.Show();
        }
        private void playSoundFromResource()
        {
            SoundPlayer sndPing = new SoundPlayer(Resources.btnClick);
            sndPing.Play();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            playSoundFromResource();
            HowToPlay howToPlay = new HowToPlay();
            howToPlay.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            playSoundFromResource();
            Scores s = new Scores();
            s.Show();
        }

        private void MatchThreeForm_Load(object sender, EventArgs e)
        {
            MatchThreeForm.igrachi.Clear();

            FileStream fs = File.Open("doc.sfi", FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();

            MatchThreeForm.igrachi = (List<Igrach>)b.Deserialize(fs);
            fs.Close();
        }
    }
}











