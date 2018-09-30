﻿using System;
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
    }
}