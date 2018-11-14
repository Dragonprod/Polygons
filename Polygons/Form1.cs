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
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Polygons
{
    public partial class Form1 : Form
    {
        List<Shape> figures = new List<Shape>();
        int _x, _y, RadMem = 20, currentIndex = -1;
        string FileName_get = null;
        bool tmp_save_flag = true;
        Form2 set_r;
        Random rnd = new Random();
        SaveFileDialog saveD;
        OpenFileDialog openD;
        BinaryFormatter binFormat = new BinaryFormatter();
        Stream stream;
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }
        private void Log(string msg)
        {
            File.AppendAllText("log.txt", msg + "\n");
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
                if (byJarvisToolStripMenuItem.Checked || byDefenitionToolStripMenuItem.Checked)
                    if (IsinConvexHull(e.X, e.Y))
                    {
                        p.FLAG = true;
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
            //pre-load for ConvexHull
            if (byJarvisToolStripMenuItem.Checked)
            {
                if (figures.Count >= 3)
                {
                    figures = ConvexHull_Main(figures);
                    Refresh();
                }
            }
            for (int i = 0; i < figures.Count; i++)
            {
                if (byDefenitionToolStripMenuItem.Checked)
                    if (figures.Count >= 3)
                    {
                        if (figures[i].TOREMOVE)
                        {
                            figures.Remove(figures[i]);
                            Refresh();
                        }
                    }
            }
            Log(DateTime.Now.ToString() + ": EVENT MOUSE_DOWN");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            figures.Add(new Circle(ClientSize.Width / 2, ClientSize.Height / 2));
            Refresh();
            Log(DateTime.Now.ToString() + ": LOAD: Default circle add");
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
            Log(DateTime.Now.ToString() + ": EVENT MOUSE_MOVE");
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Shape p1 in figures)
            {
                p1.FLAG = false;
                p1.REMOVE = false;
            }
            for (int i = 0; i < figures.Count; i++)
            {
                if (byDefenitionToolStripMenuItem.Checked)
                    if (figures.Count >= 3)
                    {
                        if (figures[i].TOREMOVE)
                        {
                            figures.Remove(figures[i]);
                            Refresh();
                        }
                    }
            }
            if (byJarvisToolStripMenuItem.Checked)
                if (figures.Count >= 3)
                {
                    figures = ConvexHull_Main(figures);
                    Refresh();
                }
            Log(DateTime.Now.ToString() + ": EVENT MOUSE_UP");
        }
        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            triangleToolStripMenuItem1.Checked = false;
            squareToolStripMenuItem1.Checked = false;
            Log(DateTime.Now.ToString() + ": TYPE type changed, new type - circle");
        }
        private void triangleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            circleToolStripMenuItem.Checked = false;
            squareToolStripMenuItem1.Checked = false;
            Log(DateTime.Now.ToString() + ": TYPE type changed, new type - triangle");
        }
        private void squareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            triangleToolStripMenuItem1.Checked = false;
            circleToolStripMenuItem.Checked = false;
            Log(DateTime.Now.ToString() + ": TYPE type changed, new type - square");
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveD = new SaveFileDialog();
                saveD.Filter = "All files (*.*)|*.*|data file *.dat|*.dat";
                saveD.FilterIndex = 2;
                saveD.ShowDialog();
                figures.Clear();
                FileName_get = saveD.FileName;
                tmp_save_flag = false;
                figures.Add(new Circle(ClientSize.Width / 2, ClientSize.Height / 2));
                Refresh();
            }
            catch (InvalidOperationException)
            {
                Log(DateTime.Now.ToString() + ": Save error(InvalidOperationException)");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Error: name must be set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log(DateTime.Now.ToString() + ": Save error(ArgumentException");
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveD = new SaveFileDialog();
                if(tmp_save_flag)
                    if (!saveD.CheckFileExists)
                    {
                        saveD.Filter = "All files (*.*)|*.*|data file *.dat|*.dat";
                        saveD.FilterIndex = 2;
                        saveD.ShowDialog();
                        FileName_get = saveD.FileName;
                        tmp_save_flag = false;
                    }
                stream = File.OpenWrite(FileName_get);
                FileName_get = saveD.FileName;
                binFormat.Serialize(stream, figures);
                Log(DateTime.Now.ToString() + ": Save succes");
                stream.Close();

            }
            catch (InvalidOperationException)
            {
                Log(DateTime.Now.ToString() + ": Save error(InvalidOperationException)");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Error: name must be set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log(DateTime.Now.ToString() + ": Save error(ArgumentException)");
            }
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openD = new OpenFileDialog();
                openD.Filter = "All files (*.*)|*.*|data file *.dat|*.dat";
                openD.FilterIndex = 2;
                openD.ShowDialog();
                FileName_get = openD.FileName;
                stream = File.OpenRead(FileName_get);
                figures = (List<Shape>)binFormat.Deserialize(stream);
                Refresh();
                stream.Close();
                Log(DateTime.Now.ToString() + ": Load succes");
            }
            catch (InvalidOperationException)
            {
                Log(DateTime.Now.ToString() + ": Save error(InvalidOperationException)");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Error: name must be set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log(DateTime.Now.ToString() + ": Save error(ArgumentException");
            }
        }
        private void radiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            Log(DateTime.Now.ToString() + ": RADIUS radius changed, new radius - " + set_r.Radius.ToString());
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
            Log(DateTime.Now.ToString() + ": COLOR inside color changed, new color:" + colorDialog1.Color.ToString());
        }
        private void outsideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            foreach (Shape p1 in figures)
            {
                p1.PEN = colorDialog1.Color;
                Refresh();
            }
            Log(DateTime.Now.ToString() + ": COLOR outside color changed, new color:" + colorDialog1.Color.ToString());
        }
        bool IsinConvexHull(int mouse_X, int mouse_Y)
        {
            bool result = false;
            int j = figures.Count - 1;
            for (int i = 0; i < figures.Count; i++)
            {
                if ((((figures[i].Y <= mouse_Y) && (mouse_Y < figures[j].Y)) || ((figures[j].Y <= mouse_Y) && (mouse_Y < figures[i].Y))) &&
       (mouse_X > (figures[j].X - figures[i].X) * (mouse_Y - figures[i].Y) / (figures[j].Y - figures[i].Y) + figures[i].X))
                    result = !result;
                j = i;
            }
            return result;
        }
        private int Orientation(Shape p1, Shape p2, Shape p)
        {
            int Orin = (p2.X - p1.X) * (p.Y - p1.Y) - (p.X - p1.X) * (p2.Y - p1.Y);
            if (Orin > 0)
                return -1;
            if (Orin < 0)
                return 1;
            return 0;
        }
        private List<Shape> ConvexHull_Main(List<Shape> figures)
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
                    foreach (Shape p in figures)
                        p.TOREMOVE = true;
                    float k = 0, b = 0;
                    int up, down;
                    for (int i = 0; i < figures.Count; i++)
                    {
                        for (int j = i + 1; j < figures.Count; j++)
                        {
                            k = (float)(figures[i].Y - figures[j].Y) / (figures[i].X - figures[j].X);
                            b = (float)(figures[j].Y - k * figures[j].X);
                            up = 0;
                            down = 0;
                            for (int m = 0; m < figures.Count; m++)
                            {
                                if (m != i && m != j)
                                {
                                    if (figures[i].X != figures[j].X)
                                    {
                                        if (figures[m].X * k + b <= figures[m].Y)
                                        {
                                            up++;
                                        }
                                        if (figures[m].X * k + b > figures[m].Y)
                                        {
                                            down++;
                                        }
                                    }
                                    else
                                    {
                                        if (figures[m].X < figures[i].X)
                                        {
                                            up++;
                                        }
                                        if (figures[m].X > figures[i].X)
                                        {
                                            down++;
                                        }
                                    }
                                }
                            }
                            if (up == 0 || down == 0)
                            {
                                figures[i].TOREMOVE = false;
                                figures[j].TOREMOVE = false;
                                e.Graphics.DrawLine(new Pen(Color.Black), figures[j].X, figures[j].Y, figures[i].X, figures[i].Y);
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
                    //figures = ConvexHull_Main(figures);
                    e.Graphics.DrawLine(new Pen(Color.Black), figures[0].X, figures[0].Y, figures[figures.Count - 1].X, figures[figures.Count - 1].Y);
                    for (int i = 0; i < figures.Count - 1; i++)
                    {
                        e.Graphics.DrawLine(new Pen(Color.Black), figures[i].X, figures[i].Y, figures[i + 1].X, figures[i + 1].Y);
                    }
                }

            }
            #endregion
        }
        private void byDefenitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byJarvisToolStripMenuItem.Checked = false;
            Log(DateTime.Now.ToString() + ": CONVEXHULL Succes by Defenition");
            Refresh();
        }
        private void byJarvisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byDefenitionToolStripMenuItem.Checked = false;
            if (figures.Count >= 3)
            {
                figures = ConvexHull_Main(figures);
                Log(DateTime.Now.ToString() + ": CONVEXHULL Succes by Jarvis");
                Refresh();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox1.Text) <= 0) throw new IndexOutOfRangeException();
                timer1.Interval = int.Parse(textBox1.Text);
                timer1.Enabled = true;
                Log(DateTime.Now.ToString() + "ANIMATION Timer enavled");
            }
            catch (FormatException)
            {
                textBox1.Text = null;
                timer1.Enabled = false;
                MessageBox.Show("Error: Only numbers\nInterval must be set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log(DateTime.Now.ToString() + ": ANIMATION Error: Only numbers\nInterval must be set");
            }
            catch (IndexOutOfRangeException)
            {
                textBox1.Text = null;
                timer1.Enabled = false;
                MessageBox.Show("Error: Interval must be > or = 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log(DateTime.Now.ToString() + ": ANIMATION Error: Interval must be > or = 0");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Log(DateTime.Now.ToString() + "ANIMATION Timer disabled");
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
                Log(DateTime.Now.ToString() + ": ANIMATION Error: Only numbers\nInterval must be set");
            }
            catch (IndexOutOfRangeException)
            {
                textBox1.Text = null;
                timer1.Enabled = false;
                MessageBox.Show("Error: Interval must be > or = 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log(DateTime.Now.ToString() + ": ANIMATION Error: Interval must be > or = 0");
            }
        }
        #region UNDO_REDO
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //private bool CanUndo { get { return currentIndex >= 0; } }
        //private bool CanRedo { get { return figures.Count > 0 && currentIndex < figures.Count - 1; } }
        //private void Undo()
        //{
        //    if (!CanUndo)
        //        return;
        //    figures[currentIndex].Undo();
        //    currentIndex--;
        //}
        //private void Redo()
        //{
        //    if (!CanRedo)
        //        return;
        //    currentIndex++;
        //    figures[currentIndex].Redo(document);
        //}
        //public void Add()
        //{
        //    items.Add(item);
        //    this.currentIndex++;
        //}
        //private void CutOffHistory()
        //{
        //    int index = currentIndex + 1;
        //    if (index < figures.Count)
        //        figures.RemoveRange(index, figures.Count - index);
        //}
        //void DoAction()
        //{
        //    //HistoryItem item = CreateActionHistoryItem();
        //    document.History.Add(item);
        //    item.Redo(document);
        //}
        #endregion
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (byJarvisToolStripMenuItem.Checked)
                if (figures.Count >= 3)
                {
                    figures = ConvexHull_Main(figures);
                    Refresh();
                }
            foreach (Shape p in figures)
            {
                p.X = p.X + rnd.Next(-1, 2);
                p.Y = p.Y + rnd.Next(-1, 2);
                Refresh();
            }
            Refresh();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}