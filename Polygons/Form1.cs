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
        List<Shape> figures = new List<Shape>();
        int _x, _y, RadMem = 20;
        float k, b;
        Form2 set_r;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            bool IsMove = false;
            _x = e.X; _y = e.Y;
            foreach (Shape p in figures.ToArray())
            {
                if (p.IsInside(e.X, e.Y))
                {
                    p.FLAG = true;
                    p.REMOVE = true;
                    IsMove = true;
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                for (int i = figures.Count - 1; i >= 0; i--)
                {
                    if (figures[i].REMOVE)
                    {
                        figures.RemoveAt(i);
                        Refresh();
                        break;
                    }
                }
            }
            if (!IsMove && e.Button == MouseButtons.Left)
            {
                if (circleToolStripMenuItem.Checked == true)
                {
                    figures.Add(new Circle(e.X, e.Y));
                    Refresh();
                }
                else if (triangleToolStripMenuItem1.Checked == true)
                {
                    figures.Add(new Triangle(e.X, e.Y));
                    Refresh();
                }
                else if (squareToolStripMenuItem1.Checked == true)
                {
                    figures.Add(new Rectangl(e.X, e.Y));
                    Refresh();
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            figures.Add(new Circle(ClientSize.Width / 2, ClientSize.Height / 2));
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
            //foreach (Shape p1 in figures.ToArray())
            //{

            //        if (p1.TOREMOVE == true)
            //        {
            //            figures.Remove(p1);
            //            Refresh();
            //        }
            //
            Refresh();
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void radiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            //re-open lock
            //
            if (set_r == null || set_r.IsDisposed)
            {
                set_r = new Form2();
                set_r.Owner = this;
                set_r.RadMem(RadMem);
                set_r.Show();
            }
            else set_r.Activate();
            set_r.RadiusChanged += Set_r_RadiusChanged;
        }

        private void Set_r_RadiusChanged(object sender, EventArgs e)
        {
            foreach (Shape p in figures)
            {
                p.RADIUS = set_r.Radius;
                Refresh();
            }
            RadMem = set_r.Radius;
        }
        private void insideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            foreach (Shape p1 in figures)
            {
                p1.COL = colorDialog1.Color;
                Refresh();
            }
        }
        private void outsideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            foreach (Shape p1 in figures)
            {
                p1.PEN = colorDialog1.Color;
                Refresh();
            }
        }
        int Orientation(Shape p1, Shape p2, Shape p)
        {
            int Orin = (p2.X - p1.X) * (p.Y - p1.Y) - (p.X - p1.X) * (p2.Y - p1.Y);
            if (Orin > 0)
                return -1; 
            if (Orin < 0)
                return 1; 
            return 0; 
        }
        List<Shape> ConvexHull_Main (List<Shape> figures)
        {
            if (figures.Count < 3)
                return null;
            List<Shape> hull = new List<Shape>();
            Shape vPointOnHull = figures.Where(p => p.X == figures.Min(min => min.X)).First();
            Shape vEndpoint;
            do
            {
                hull.Add(vPointOnHull);
                vEndpoint = figures[0];
                for (int i = 1; i < figures.Count; i++)
                {
                    if ((vPointOnHull == vEndpoint)
                        || (Orientation(vPointOnHull, vEndpoint, figures[i]) == -1))
                    {
                        vEndpoint = figures[i];
                    }
                }
                vPointOnHull = vEndpoint;
            }
            while (vEndpoint != hull[0]);
            return hull;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shape p1 in figures)
            {
                p1.Draw(e.Graphics); 
            }
            #region ConvexHull_ByDefenition
            if (byDefenitionToolStripMenuItem.Checked)
            {
                if (figures.Count >= 3)
                {
                    int down = 0, up = 0;
                    for (int i = 0; i < figures.Count; i++)
                    {
                        for (int j = i + 1; j < figures.Count; j++)
                        {
                            k = ((float)figures[i + 1].Y - figures[i].Y) / (figures[i + 1].X - figures[i].X);
                            //k = figures[i].Y / figures[i].X;
                            b = figures[i + 1].Y - k * figures[i + 1].X;
                            //b = figures[i + 1].Y - ((figures[i + 1].Y - figures[i].Y) / (figures[i + 1].X - figures[i].X)) * figures[i + 1].X;
                            for (int z = 0; z < figures.Count; z++)
                            {
                                if (figures[z] != figures[i] && figures[z] != figures[i + 1])
                                {
                                    if (figures[z].X * k < figures[z].Y)
                                    {
                                        down++;
                                    }
                                    if (figures[z].X * k > figures[z].Y)
                                    {
                                        up++;
                                    }
                                    if (up == 0 || down == 0)
                                    {
                                        figures[i].TOREMOVE = true;
                                        figures[i + 1].TOREMOVE = false;
                                        e.Graphics.DrawLine(new Pen(Color.Black), figures[0].X, figures[0].Y, figures[figures.Count - 1].X, figures[figures.Count - 1].Y);
                                        e.Graphics.DrawLine(new Pen(Color.Black), figures[i].X, figures[i].Y, figures[i + 1].X, figures[i + 1].Y);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #region ConvexHull_ByJarvis
            if (byJarvisToolStripMenuItem.Checked)
            {
                if (figures.Count >= 3)
                {
                    figures = ConvexHull_Main(figures);
                    e.Graphics.DrawLine(new Pen(Color.Black), figures[0].X, figures[0].Y, figures[figures.Count - 1].X, figures[figures.Count - 1].Y);
                    for (int i = 0; i < figures.Count - 1; i++)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Black), figures[i].X, figures[i].Y, figures[i + 1].X, figures[i + 1].Y);
                    }
                }

            }
            #endregion
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox1.Text) <= 0) throw new IndexOutOfRangeException();
                timer1.Interval = int.Parse(textBox1.Text);
                timer1.Enabled = true;
            }
            catch(FormatException)
            {
                textBox1.Text = null; 
                timer1.Enabled = false;
                MessageBox.Show("Error: Only numbers\nInterval must be set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(IndexOutOfRangeException)
            {
                textBox1.Text = null;
                timer1.Enabled = false;
                MessageBox.Show("Error: Interval must be > or = 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void byDefenitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byJarvisToolStripMenuItem.Checked = false;
        }

        private void byJarvisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byDefenitionToolStripMenuItem.Checked = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox1.Text) <= 0) throw new IndexOutOfRangeException();
                timer1.Interval = int.Parse(textBox1.Text);
            }
            catch (FormatException)
            {
                textBox1.Text = null;
                timer1.Enabled = false;
                MessageBox.Show("Error: Only numbers\nInterval must be set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IndexOutOfRangeException)
            {
                textBox1.Text = null;
                timer1.Enabled = false;
                MessageBox.Show("Error: Interval must be > or = 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Bitmap img = new Bitmap();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Shape p in figures)
            {
                p.X = p.X + rnd.Next(-1, 2);
                p.Y = p.Y + rnd.Next(-1, 2);
                Refresh();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}