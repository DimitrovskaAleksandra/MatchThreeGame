using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MatchThreeGame
{
    public class Slika
    {
        public Image image;
        public int X { get; set; }
        public int Y { get; set; }
        public int Strana { get; set; }
        public bool Selected { get; set; }
        public Pen pen { get; set; }
        public int brojSlika
        {
            get;
            set;
        }
        public int brojSlikaSporedba
        {
            get;
            set;
        }
        public Slika(int x, int y, int s, Image i)
        {
            X = x;
            Y = y;
            Strana = s;
            image = i;
            pen = new Pen(Color.Black, 3);
        }
        public void Draw(Graphics g)
        {
            g.DrawImage(image, X, Y, Strana, Strana);
            if (Selected)
                g.DrawRectangle(pen, X, Y, Strana, Strana);
        }

        public bool IsHit(float x, float y)
        {
            return (((x - X) <= Strana) && ((x - X) > 0) && ((y - Y) <= Strana) && ((y - Y) > 0));
        }
    }
}
