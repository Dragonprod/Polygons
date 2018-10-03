using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Polygons
{
    abstract class Shape
    {
        protected Color col, pen;
        protected static int radius;
        protected int x,y;
        protected bool flag, remove;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public bool FLAG
        {
            get { return flag; }
            set { flag = value; }
        }
        public bool REMOVE
        {
            get { return remove; }
            set { remove = value; }
        }
        public int RADIUS
        {
            get { return radius; }
            set { radius = value; }
        }
        public Color COL
        {
            get { return col; }
            set { col = value; }
        }
        public Color PEN
        {
            get { return pen; }
            set { pen = value; }
        }
        public Shape(Color col, Color pen, int x, int y)
        {
            radius = 20;
            this.x = x;
            this.y = y;
            this.col = col;
            this.pen = pen;        
        }
        static Shape()
        {
            radius = 20;
        }
        public abstract void Draw(Graphics gr);
        public abstract bool IsInside(int mouse_x, int mouse_y);
        public abstract bool ToRemove(int mouse_x, int mouse_y);
        static int Orientation(Shape p1, Shape p2, Shape p)
        {
            if (((p2.X - p1.X) * (p.Y - p1.Y) - (p.X - p1.X) * (p2.Y - p1.Y)) > 0)
                return -1; 
            if (((p2.X - p1.X) * (p.Y - p1.Y) - (p.X - p1.X) * (p2.Y - p1.Y)) < 0)
                return 1; 
            return 0; 
        }
        public static List<Shape> ConvexHull(List<Shape> figures)
        {
            List<Shape> hull = new List<Shape>();
            Shape vPointOnHull = figures.Where(p => p.X == figures.Min(min => min.X)).First();
            Shape vEndpoint;
            do
            {
                hull.Add(vPointOnHull);
                vEndpoint = figures[0];
                for (int i = 1; i < figures.Count; i++)
                {
                    if ((vPointOnHull == vEndpoint) || (Orientation(vPointOnHull, vEndpoint, figures[i]) == -1))
                    {
                        vEndpoint = figures[i];
                    }
                }
                vPointOnHull = vEndpoint;
            }
            while (vEndpoint != hull[0]);
            return hull;
        }
    }
}
