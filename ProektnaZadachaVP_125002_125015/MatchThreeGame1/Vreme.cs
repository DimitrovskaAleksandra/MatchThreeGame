using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MatchThreeGame
{
    class Vreme
    {
        public Point Center { get; set; }
        public int Br { get; set; }
        public bool Stop { get; set; }
        public static readonly int RADIUS = 50;
        public static readonly int DEBELINNA = 10;


        public Vreme()
        {
            Stop = false;
            Br = 0;
        }

        public void Draw(Graphics g)
        {
                Brush b = new SolidBrush(Color.Pink);
                Pen p = new Pen(Color.FromArgb(121, 190, 219), DEBELINNA);
                g.FillPie(b, 40, 80, 2 * RADIUS, 2 * RADIUS, 270, Br * 3);
                g.DrawEllipse(p, 40, 80, 2 * RADIUS, 2 * RADIUS);
                b.Dispose();
                p.Dispose();
           
        }

        public void Tick()
        {
            Br+=1;
           
        }

    }
}
