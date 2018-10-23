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
    public abstract class Shape
    {
        protected static Color col, pen;
        protected static int radius;
        protected int x, y;
        protected bool flag, remove, ToRemove;
        public event EventHandler Changed = delegate { };
        protected virtual void OnChanged()
        {
            Changed(this, EventArgs.Empty); 
        }
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
        public bool TOREMOVE
        {
            get { return ToRemove; }
            set { ToRemove = value; }
        }
        public int RADIUS
        {
            get { return radius; }
            set { radius = value; OnChanged(); }
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
        public Shape(int x, int y)
        {
            radius = 20;
            this.x = x;
            this.y = y;
        }
        static Shape()
        {
            col = Color.Red;
            pen = Color.Green;
            radius = 20;
        }
        public abstract void Draw(Graphics gr);
        public abstract bool IsInside(int mouse_x, int mouse_y);
    }
}
