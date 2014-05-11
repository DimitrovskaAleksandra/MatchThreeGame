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
using System.Media;
using MatchThreeGame.Properties;

namespace MatchThreeGame
{
    public partial class Level1 : Form
    {
        
        public static Igrach i;
        Kvadrat[,] kvadrati;
        Random broj;
        int brojBoja;
        Color boja;
        Vreme vreme = new Vreme();
        int brojac;
        string currPlayer;
        public int Points;
        public const String docName = "doc.sfi";

        public Level1(string igrac, int poeni)
        {
            i = new Igrach();
            Points = 0;
            InitializeComponent();
            currPlayer = igrac;
            label2.Text = currPlayer;
            i.Ime = currPlayer;
            i.Poeni = Points;
            MatchThreeForm.igrachi.Add(i);
            vreme = new Vreme();
            kvadrati = new Kvadrat[7, 9];
            broj = new Random();
            this.DoubleBuffered = true;
            brojac = 0;
            Inicijalizacija();
            timer1.Start();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            timer5.Start();
            nextLevel();
        }
        public void Inicijalizacija()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    brojBoja = broj.Next(0, 6);
                    if (brojBoja == 0)
                    {
                        boja = Color.FromArgb(223, 148, 150);
                    }
                    else if (brojBoja == 1)
                    {
                        boja = Color.FromArgb(183, 175, 163);
                    }
                    else if (brojBoja == 2)
                    {
                        boja = Color.FromArgb(163, 30, 57);
                    }
                    else if (brojBoja == 3)
                    {
                        boja = Color.SlateBlue;
                    }
                    else if (brojBoja == 4)
                    {
                        boja = Color.FromArgb(121, 190, 219);
                    }
                    else if(brojBoja==5)
                    {
                        boja=Color.FromArgb(255, 255, 153);
                    }
                    kvadrati[i, j] = new Kvadrat(55*(j+5) + 15, 55 * i + 30, 50, boja);
                }
            }
            
        }
        public void Crtaj(Graphics g)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    kvadrati[i, j].Draw(g);
                }
            }

        }
        public void UnselectAll()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    kvadrati[i, j].Selected = false;
                }
            }
        }

        //Metod za zamena na dva objekti
        public void Swap(Kvadrat[,] k, int i1, int j1, int i2, int j2)
        {

            Kvadrat tmp = k[i1, j1];
            k[i1, j1] = k[i2, j2];
            k[i2, j2] = tmp;
            float x1, y1;
            x1 = kvadrati[i1, j1].X;
            y1 = kvadrati[i1, j1].Y;
            kvadrati[i1, j1].X = kvadrati[i2, j2].X;
            kvadrati[i1, j1].Y = kvadrati[i2, j2].Y;
            kvadrati[i2, j2].X = x1;
            kvadrati[i2, j2].Y = y1;


        }
       //Metod za pomestuvanje na objektite
        public void Fall()
        {
            bool flag = false;
            for (int i = 6; i >= 1; i--)
            {
                for (int j = 8; j >= 0; j--)
                {
                    if (kvadrati[i, j].boja == Color.Transparent)
                    {
                        for (int l = i - 1; l >= 0; l--)
                        {
                            if (kvadrati[l, j].boja != Color.Transparent)
                            {
                                flag = true;

                            }
                        }
                        if (flag == true)
                        {
                            for (int k = i; k >= 1; k--)
                                Swap(kvadrati, k, j, k - 1, j);
                            j++;
                            flag = false;
                            Invalidate();
                        }

                    }

                }
            }
            Invalidate();
            timer2.Stop();
            timer3.Start();
        }
        //Metod za proverka dali ima povekje od 3 isti objekti 
        //i menuvanje na nivnata boja vo Transparent
        public void MoreThan2()
        {
            Brush cetka = new SolidBrush(Color.Transparent);
            bool flag = true;
            bool flag1 = true;
            int od = 0, od1 = 0, br = 0, br1 = 0;
            for (int k = 0; k < 7; k++)
            {
                for (int l = 0; l < 7; l++)
                {
                    if ((kvadrati[k, l].bojaZaSporedba == kvadrati[k, l + 1].bojaZaSporedba))
                    {

                        if (kvadrati[k, l + 2].bojaZaSporedba == kvadrati[k, l + 1].bojaZaSporedba)
                        {
                            br++;
                            if (flag == true)
                            {
                                od = l;
                                flag = false;
                            }
                            kvadrati[k, l].Brush = cetka;
                            kvadrati[k, l + 1].Brush = cetka;
                            kvadrati[k, l + 2].Brush = cetka;
                            Invalidate();
                            if (l == 6)
                            {
                                for (int g = od; g <= 6; g++)
                                {
                                    kvadrati[k, g].boja = Color.Transparent;
                                }
                                kvadrati[k, 6].boja = Color.Transparent;
                                kvadrati[k, 7].boja = Color.Transparent;
                                kvadrati[k, 8].boja = Color.Transparent;
                                br = 0;
                                flag = true;

                            }

                        }
                        else if (kvadrati[k, l + 2].bojaZaSporedba != kvadrati[k, l + 1].bojaZaSporedba)
                        {
                            if (br >= 1)
                            {
                                for (int i = od; i < l + 2; i++)
                                {
                                    kvadrati[k, i].boja = Color.Transparent;
                                }
                            }
                            br = 0;
                            flag = true;
                        }
                    }
                }
            }
            for (int l = 0; l < 9; l++)
            {
                for (int k = 0; k < 5; k++)
                {
                    if ((kvadrati[k, l].bojaZaSporedba == kvadrati[k + 1, l].bojaZaSporedba))
                    {
                        if (kvadrati[k + 2, l].bojaZaSporedba == kvadrati[k + 1, l].bojaZaSporedba)
                        {
                            br1++;
                            if (flag1 == true)
                            {
                                od1 = k;
                                flag1 = false;
                            }
                            kvadrati[k, l].Brush = cetka;
                            kvadrati[k + 1, l].Brush = cetka;
                            kvadrati[k + 2, l].Brush = cetka;
                            Invalidate();
                            if (k == 4)
                            {
                                for (int g = od1; g <= 4; g++)
                                {
                                    kvadrati[g, l].boja = Color.Transparent;
                                }
                                kvadrati[4, l].boja = Color.Transparent;
                                kvadrati[5, l].boja = Color.Transparent;
                                kvadrati[6, l].boja = Color.Transparent;
                                br1 = 0;
                                flag1 = true;

                            }
                        }
                        else if (kvadrati[k + 2, l].bojaZaSporedba != kvadrati[k + 1, l].bojaZaSporedba)
                        {
                            if (br1 >= 1)
                            {
                                for (int i = od1; i < k + 2; i++)
                                {
                                    kvadrati[i, l].boja = Color.Transparent;
                                }
                            }
                            flag1 = true;
                            br1 = 0;
                        }
                    }
                }
            }
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    if (kvadrati[i, j].boja == Color.Transparent)
                    {
                        kvadrati[i, j].bojaZaSporedba = Color.Transparent;
                        MatchThreeForm.igrachi.ElementAt(MatchThreeForm.igrachi.Count-1).Poeni++;
                        kvadrati[i, j] = new Kvadrat(55 * (j+ 5) + 15, 55 * i + 30, 50, Color.Transparent);
                    }
                }
            }
            timer2.Start();
        }
        
       

        //Metod za generiranje novi objekti
        //Site objekti koi imaat boja Transparent im se menuva vo sluchajno generirana boja
        public void GenerateNew()
        {
            Random r = new Random();
            int brboja;
            Color boja1 = Color.FromArgb(255, 255, 153);
            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    brboja = r.Next(0, 6);
                    if (brboja == 0)
                    {
                        boja1 = Color.FromArgb(183, 175, 163);
                    }
                    else if (brboja == 1)
                    {
                        boja1 = Color.FromArgb(223, 148, 150);
                    }
                    else if (brboja == 2)
                    {
                        boja1 = Color.FromArgb(163, 30, 57);
                    }
                    else if (brboja == 3)
                    {
                        boja1 = Color.FromArgb(255, 255, 153);
                        
                    }
                    else if (brojBoja == 4)
                    {
                        boja1 = Color.FromArgb(121, 190, 219);
                    }
                    else if (brojBoja == 5)
                    {
                        boja1 = Color.SlateBlue;   
                    }
                    if (kvadrati[i, j].boja == Color.Transparent)
                    {
                        kvadrati[i, j].boja = boja1;
                        kvadrati[i, j].bojaZaSporedba = boja1;
                        kvadrati[i, j].Brush = new SolidBrush(boja1);
                    }
                }
            }
            Invalidate();
            timer3.Stop();
        }


        private void timer3_Tick(object sender, EventArgs e)
        {

            GenerateNew();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Fall();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoreThan2();
            label5.Text = String.Format("{0}", MatchThreeForm.igrachi.ElementAt(MatchThreeForm.igrachi.Count - 1).Poeni);
        }
       
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Crtaj(e.Graphics);
            vreme.Draw(e.Graphics);
        }
       
        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (kvadrati[i, j].IsHit(e.X, e.Y))
                    {
                        playSoundFromResource();
                        kvadrati[i, j].Selected = true;
                        Invalidate();
                    }
                }
            }
            int br = 0;
            int ii = 0, jj = 0;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    if (kvadrati[i, j].Selected == true)
                    {
                        br++;
                        ii = i;
                        jj = j;


                    }
                }
            }

            if (br == 2)
            {
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (kvadrati[i, j].Selected == true)
                        {
                            if (((i == ii && j == jj + 1) || (i == ii && j == jj - 1) || (j == jj && i == ii + 1) || (j == jj && i == ii - 1)))
                            {

                                Swap(kvadrati, ii, jj, i, j);

                                UnselectAll();
                            }

                        }

                    }
                }
                UnselectAll();

            }
        }


        private void timer5_Tick(object sender, EventArgs e)
        {

              vreme.Tick();
              brojac += 1;
              lblvreme.Text = string.Format("{0}/120 sec", brojac);
              Invalidate();
              nextLevel();
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

        private void nextLevel()
        {
            if (brojac == 120)
            {
                timer5.Stop();
                playSoundFromResource1();
                MessageBox.Show("You have completed this level.\n Congratulations! You are now Level 2.", "Next level", MessageBoxButtons.OK);
                Level2 l2 = new Level2();
                l2.Show();
                this.Close();
            }

        }

        private void Level1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileStream fs = File.Open(docName, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fs,MatchThreeForm.igrachi);
            fs.Close();
        }


        


    }
}
