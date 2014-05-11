using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MatchThreeGame
{
    public class Kvadrat
    {
        public float X
        {
            get;
            set;
        }
        public float Y
        {
            get;
            set;
        }
        public bool Selected
        {
            get;
            set;
        }
        public float Strana
        {
            get;
            set;
        }
        public Pen Pen
        {
            get;
            set;
        }
        public Brush Brush
        {
            get;
            set;
        }
        public Color boja
        {
            get;
            set;
        }
        public Color bojaZaSporedba
        {
            get;
            set;
        }
        public Kvadrat(float x,float y,float s,Color b)
        {
            X = x;
            Y = y;
            Strana = s;
            boja = b;
            bojaZaSporedba = b;
            Brush = new SolidBrush(bojaZaSporedba);
            Pen = new Pen(Color.FromArgb(135, 226, 147), 3);
        }

        public void Draw(Graphics g)
        {
    
            g.FillRectangle(Brush,X,Y,Strana,Strana);
            if (Selected)
            {
                g.DrawRectangle(Pen, X, Y, Strana, Strana);
            }
        }
        public bool IsHit(float x, float y)
        {
            return (((x - X) <= Strana) && ((x - X) > 0 )&& ((y - Y) <= Strana) && ((y - Y) >0));
        }
    }
}
