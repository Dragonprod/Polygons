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
    public partial class Form1 : Form
    {
        Color col, pen;
        List<Shape> figures = new List<Shape>();
        int _x, _y;
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            bool IsMove = false;
            _x = e.X; _y = e.Y;
            foreach (Shape p1 in figures.ToArray())
            {
                if (!IsMove && e.Button == MouseButtons.Left)
                {
                    if (circleToolStripMenuItem.Checked == true)
                    {
                        figures.Add(new Circle(col, pen, e.X, e.Y));
                        Refresh();
                    }
                    if (triangleToolStripMenuItem1.Checked == true)
                    {
                        figures.Add(new Triangle(col, pen, e.X, e.Y));
                        Refresh();
                    }
                    if (squareToolStripMenuItem1.Checked == true)
                    {
                        figures.Add(new Rectangl(col, pen, e.X, e.Y));
                        Refresh();
                    }
                }
                if (IsMove && e.Button == MouseButtons.Left)
                {
                    if (p1.IsInside(e.X, e.Y)) { p1.FLAG = true; }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if (p1.ToRemove(e.X, e.Y)) p1.REMOVE = true;
                    if (p1.REMOVE) { figures.Remove(p1); Refresh(); }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            col = Color.Red;
            pen = Color.Green;
            figures.Add(new Circle(col, pen, ClientSize.Width / 2, ClientSize.Height / 2));
            Refresh();
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Shape p1 in figures)
            {
                if (p1.FLAG)
                {
                    p1.X += e.X - _x;
                    p1.Y += e.Y - _y;
                    Refresh();
                } 
            }
            _x = e.X;
            _y = e.Y;
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Shape p1 in figures)
            {
                p1.FLAG = false;
                p1.REMOVE = false;
            }
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            triangleToolStripMenuItem1.Checked = false;
            squareToolStripMenuItem1.Checked = false;
        }

        private void triangleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            circleToolStripMenuItem.Checked = false;
            squareToolStripMenuItem1.Checked = false;
        }

        private void squareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            triangleToolStripMenuItem1.Checked = false;
            circleToolStripMenuItem.Checked = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shape p1 in figures)
            {
                p1.Draw(e.Graphics);
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
