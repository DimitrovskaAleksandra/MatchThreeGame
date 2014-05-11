using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace MatchThreeGame
{
    public partial class Scores : Form
    {
        public Scores()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Scores_Load(object sender, EventArgs e)
        {
            
            String s="";
            int br = 0;
            foreach(Igrach i in MatchThreeForm.igrachi)
            {
                br++;
                s = s + br.ToString();
                s = s + ".";
                s = s + i.Ime;
                s = s + "           ";
                s = s + MatchThreeForm.igrachi.ElementAt(br-1).Poeni + Environment.NewLine;
               
            }
            textBox1.Text = s;
           
        }
    }
}
