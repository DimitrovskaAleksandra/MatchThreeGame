using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MatchThreeGame.Properties;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Media;


namespace MatchThreeGame
{
    public partial class Level3 : Form
    {
        Slika[,] sliki;
        Random broj;
        int brojSlika;
        Image image;
        int brSlika;
        Vreme vreme=new Vreme();
        int brojac;
        public Level3()
        {

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            broj = new Random();
            sliki = new Slika[7, 9];
            Inicijalizacija();
            vreme = new Vreme();
            brojac = 0;
            label3.Text = Level1.i.Ime;
            label5.Text = Level1.i.Poeni.ToString();
            this.DoubleBuffered = true;
            timer1.Start();
            timer5.Start();
        }

        public void Inicijalizacija()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    brojSlika = broj.Next(0, 5);
                    if (brojSlika == 0)
                    {
                        image = Resources.CvetRozov;
                        brSlika = 0;

                    }
                    else if (brojSlika == 1)
                    {
                        image = Resources.cvetRozov1;
                        brSlika = 1;
                    }
                    else if (brojSlika == 2)
                    {
                        image = Resources.cvetBel;
                        brSlika = 2;
                    }
                    else if (brojSlika == 3)
                    {
                        image = Resources.cvetCrven;
                        brSlika = 3;
                    }
                    else if (brojSlika == 4)
                    {
                        image = Resources.cvetPortokalov;
                        brSlika = 4;
                    }

                    sliki[i, j] = new Slika(55 * (j + 5) + 15, 55 * i + 30, 50, image);
                    sliki[i, j].brojSlika = brSlika;
                    sliki[i, j].brojSlikaSporedba = brSlika;

                }
            }
        }

        public void Crtaj(Graphics g)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    sliki[i, j].Draw(g);
                }
            }
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Crtaj(e.Graphics);
        }

        public void UnselectAll()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sliki[i, j].Selected = false;
                }
            }
        }

        public void Swap(Slika[,] k, int i1, int j1, int i2, int j2)
        {

            Slika tmp = k[i1, j1];
            k[i1, j1] = k[i2, j2];
            k[i2, j2] = tmp;
            int x1, y1;
            x1 = sliki[i1, j1].X;
            y1 = sliki[i1, j1].Y;
            sliki[i1, j1].X = sliki[i2, j2].X;
            sliki[i1, j1].Y = sliki[i2, j2].Y;
            sliki[i2, j2].X = x1;
            sliki[i2, j2].Y = y1;
        }
        private void playSoundFromResource()
        {
            SoundPlayer sndPing = new SoundPlayer(Resources.ding);
            sndPing.Play();
        }


        public void Fall()
        {
            bool flag = false;
            for (int i = 6; i >= 1; i--)
            {
                for (int j = 8; j >= 0; j--)
                {
                    if (sliki[i, j].brojSlika == 5)
                    {
                        for (int l = i - 1; l >= 0; l--)
                        {
                            if (sliki[l, j].brojSlika != 5)
                            {
                                flag = true;

                            }
                        }
                        if (flag == true)
                        {
                            for (int k = i; k >= 1; k--)
                                Swap(sliki, k, j, k - 1, j);
                            j++;
                            flag = false;
                            Invalidate();
                        }

                    }

                }
            }
            Invalidate();
            timer3.Start();
            timer2.Stop();
        }
        //Metod za proverka dali ima povekje od 3 isti objekti 
        public void MoreThan2()
        {
            bool flag = true;
            bool flag1 = true;
            int od = 0, od1 = 0, br = 0, br1 = 0;
            for (int k = 0; k < 7; k++)
            {
                for (int l = 0; l < 7; l++)
                {
                    if ((sliki[k, l].brojSlikaSporedba == sliki[k, l + 1].brojSlikaSporedba))
                    {

                        if (sliki[k, l + 2].brojSlikaSporedba == sliki[k, l + 1].brojSlikaSporedba)
                        {
                            br++;
                            if (flag == true)
                            {
                                od = l;
                                flag = false;
                            }
                            Invalidate();
                            if (l == 6)
                            {
                                for (int g = od; g <= 6; g++)
                                {
                                    sliki[k, g].image = Resources.bela;
                                    sliki[k, g].brojSlika = 5;
                                }
                                sliki[k, 6].image = Resources.bela;
                                sliki[k, 6].brojSlika = 5;
                                sliki[k, 7].image = Resources.bela;
                                sliki[k, 7].brojSlika = 5;
                                sliki[k, 8].image = Resources.bela;
                                sliki[k, 8].brojSlika = 5;
                                br = 0;
                                flag = true;
                            }

                        }
                        else if (sliki[k, l + 2].brojSlikaSporedba != sliki[k, l + 1].brojSlikaSporedba)
                        {
                            if (br >= 1)
                            {
                                for (int i = od; i < l + 2; i++)
                                {
                                    sliki[k, i].image = Resources.bela;
                                    sliki[k, i].brojSlika = 5;
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
                    if ((sliki[k, l].brojSlikaSporedba == sliki[k + 1, l].brojSlikaSporedba))
                    {
                        if (sliki[k + 2, l].brojSlikaSporedba == sliki[k + 1, l].brojSlikaSporedba)
                        {
                            br1++;
                            if (flag1 == true)
                            {
                                od1 = k;
                                flag1 = false;
                            }
                            if (k == 4)
                            {
                                for (int g = od1; g <= 4; g++)
                                {
                                    sliki[g, l].image = Resources.bela;
                                    sliki[g, l].brojSlika = 5;
                                }
                                sliki[4, l].image = Resources.bela;
                                sliki[4, l].brojSlika = 5;
                                sliki[5, l].image = Resources.bela;
                                sliki[5, l].brojSlika = 5;
                                sliki[6, l].image = Resources.bela;
                                sliki[6, l].brojSlika = 5;
                                br1 = 0;
                                flag1 = true;
                                Invalidate();
                            }
                        }
                        else if (sliki[k + 2, l].brojSlikaSporedba != sliki[k + 1, l].brojSlikaSporedba)
                        {
                            if (br1 >= 1)
                            {
                                for (int i = od1; i < k + 2; i++)
                                {
                                    sliki[i, l].image = Resources.bela;
                                    sliki[i, l].brojSlika = 5;
                                }
                                Invalidate();
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

                    if (sliki[i, j].brojSlika == 5)
                    {
                        sliki[i, j].image = Resources.bela;
                  
                        MatchThreeForm.igrachi.ElementAt(MatchThreeForm.igrachi.Count - 1).Poeni++;

                    }
                    else if (sliki[i, j].brojSlika == 4)
                    {
                        sliki[i, j].image = Resources.cvetPortokalov;
                    }
                    else if (sliki[i, j].brojSlika == 3)
                    {
                        sliki[i, j].image = Resources.cvetCrven;

                    }
                    else if (sliki[i, j].brojSlika == 2)
                    {
                        sliki[i, j].image = Resources.cvetBel;

                    }
                    else if (sliki[i, j].brojSlika == 1)
                    {
                        sliki[i, j].image = Resources.cvetRozov1;

                    }
                    if (sliki[i, j].brojSlika == 0)
                    {
                        sliki[i, j].image = Resources.CvetRozov;

                    }
                    sliki[i, j].brojSlikaSporedba = sliki[i, j].brojSlika;
                    Invalidate();
                }
            }
            timer2.Start();
        }

        public void GenerateNew()
        {
            Random r = new Random();
            int brSlika;
            int brojSlika = 0;
            Image slika1 = Resources.jabolko; ;
            for (int i = 0; i <= 6; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    brSlika = r.Next(0, 5);
                    if (brSlika == 0)
                    {
                        slika1 = Resources.CvetRozov;
                        brojSlika = 0;
                    }
                    else if (brSlika == 1)
                    {
                        slika1 = Resources.cvetRozov1;
                        brojSlika = 1;
                    }
                    else if (brSlika == 2)
                    {
                        slika1 = Resources.cvetBel;
                        brojSlika = 2;
                    }
                    else if (brSlika == 3)
                    {
                        slika1 = Resources.cvetCrven;
                        brojSlika = 3;
                    }
                    else if(brSlika==4)
                    {
                        slika1=Resources.cvetPortokalov;
                        brojSlika=4;
                    }
                    if (sliki[i, j].brojSlika == 5)
                    {
                        sliki[i, j].image = slika1;
                        sliki[i, j].brojSlika = brojSlika;
                        sliki[i, j].brojSlikaSporedba = brojSlika;
                    }
                }
            }
            Invalidate();
            timer3.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoreThan2();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Fall();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            GenerateNew();
        }

        private void Level3_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (sliki[i, j].IsHit(e.X, e.Y))
                    {
                        playSoundFromResource();
                        sliki[i, j].Selected = true;
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

                    if (sliki[i, j].Selected == true)
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
                        if (sliki[i, j].Selected == true)
                        {
                            if (((i == ii && j == jj + 1) || (i == ii && j == jj - 1) || (j == jj && i == ii + 1) || (j == jj && i == ii - 1)))
                            {

                                Swap(sliki, ii, jj, i, j);
                                UnselectAll();
                            }

                        }

                    }
                }
                UnselectAll();
            }
        }

        private void Level3_Paint(object sender, PaintEventArgs e)
        {
            Crtaj(e.Graphics);
            vreme.Draw(e.Graphics);
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            vreme.Tick();
            brojac += 1;
            lblvreme.Text = string.Format("{0}/120 sec", brojac);
            label5.Text = MatchThreeForm.igrachi.ElementAt(MatchThreeForm.igrachi.Count - 1).Poeni.ToString() ;
            Invalidate();
            nextLevel();
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
                MessageBox.Show(String.Format("You have completed all 3 levels.\n {0}, you get {1} points.\nCongradulations! ",label3.Text, MatchThreeForm.igrachi.ElementAt(MatchThreeForm.igrachi.Count-1).Poeni ), "Congradulation", MessageBoxButtons.OK);
                this.Close();
            }

        }

        private void Level3_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileStream fs = File.Open("doc.sfi", FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fs, MatchThreeForm.igrachi);
            fs.Close();
        }
    }
}
