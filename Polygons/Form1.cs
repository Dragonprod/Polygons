using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace Polygons
{
	public partial class Form1 : Form
	{
		
		bool unsaved = false;
		List<Shape> figures = new List<Shape>();
		List<string> plugins = new List<string>();
		Stack<List<Shape>> F_Undo = new Stack<List<Shape>>();
		Stack<List<Shape>> F_Redo = new Stack<List<Shape>>();
		int _x, _y, RadMem = 20;
		string DefaultFileName = null;
		string UserFileName = null;
		Form2 set_r;
		Random rnd = new Random();
		//BinaryFormatter binFormat = new BinaryFormatter();
		//Stopwatch timer = new Stopwatch();
		//TimeSpan ts;

		void AutoGen()
		{
			for (int i = 0; i < 10000; i++)
			{
				figures.Add(new Circle(rnd.Next(0, ClientSize.Width), rnd.Next(0, ClientSize.Height)));
			}
		}
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
			unsaved = true;
			if (unsaved) this.Text = "Polygons (unsaved)";
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
			//if (e.Button == MouseButtons.Middle) { AutoGen(); Refresh(); }
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
					F_Undo.Push(figures);
					Refresh();
				}
				else if (triangleToolStripMenuItem1.Checked == true)
				{
					figures.Add(new Triangle(e.X, e.Y));
					F_Undo.Push(figures);
					Refresh();
				}
				else if (squareToolStripMenuItem1.Checked == true)
				{
					figures.Add(new Rectangl(e.X, e.Y));
					F_Undo.Push(figures);
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
			if (byDefenitionToolStripMenuItem.Checked)
			{
				for (int i = 0; i < figures.Count; i++)
				{
					if (figures[i].TOREMOVE)
						figures.Remove(figures[i]);
					Refresh();
				}
			}
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			DefaultFileName = "Polygons1.dat";
			figures.Add(new Circle(ClientSize.Width / 2, ClientSize.Height / 2));
			//timer.Reset();
		}
		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			foreach (Shape p1 in figures)
			{
				if (p1.FLAG)
				{
					p1.X += e.X - _x;
					p1.Y += e.Y - _y;
				}
			}
			_x = e.X;
			_y = e.Y;
			Refresh();
		}
		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			foreach (Shape p1 in figures)
			{
				p1.FLAG = false;
				p1.REMOVE = false;
			}
			if (byDefenitionToolStripMenuItem.Checked)
			{
				for (int i = 0; i < figures.Count; i++)
				{
					if (figures[i].TOREMOVE)
						figures.Remove(figures[i]);
					Refresh();
				}
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
		private void fileNew() 
		{
			try
			{
				FormClosingEventArgs closing = new FormClosingEventArgs(CloseReason.None, true);
				if (unsaved)
				{
					DialogResult dialoresult = MessageBox.Show("You've got unsaved changes\nWould you like to save them?", "INFO", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
					switch (dialoresult)
					{
						case DialogResult.Yes:
							fileSaveAS();
							figures.Clear();
							figures.Add(new Circle(ClientSize.Width / 2, ClientSize.Height / 2));
							Shape.R = 20;
							Shape.COL = Color.Red;
							Shape.PEN = Color.Green;
							Refresh();
							break;
						case DialogResult.No:
							figures.Clear();
							figures.Add(new Circle(ClientSize.Width / 2, ClientSize.Height / 2));
							Shape.R = 20;
							Shape.COL = Color.Red;
							Shape.PEN = Color.Green;
							Refresh();
							break;
						case DialogResult.Cancel: closing.Cancel = (dialoresult == DialogResult.Cancel); break;
					}
				}
			}
			catch (InvalidOperationException)
			{
				Log(DateTime.Now.ToString() + ": Save error(InvalidOperationException)");
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Файл должен быть выбран\nПовторите операцию");
				Log(DateTime.Now.ToString() + ": Load error(ArgumentException)");
			}
		}
		private void fileSave()
		{
			try
			{
				BinaryFormatter binFormat = new BinaryFormatter();
				unsaved = false;
				this.Text = "Polygons";
				FileStream stream = new FileStream(DefaultFileName, FileMode.Create, FileAccess.Write);
				binFormat.Serialize(stream, figures);
				stream.Close();

			}
			catch (InvalidOperationException)
			{
				Log(DateTime.Now.ToString() + ": Save error(InvalidOperationException)");
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Файл должен быть выбран\nПовторите операцию");
				Log(DateTime.Now.ToString() + ": Load error(ArgumentException)");
			}
		}
		private void fileSaveAS()
		{
			try
			{
				SaveFileDialog saveDialog = new SaveFileDialog();

				if (unsaved)
				{
					if (!saveDialog.CheckFileExists)
					{
						saveDialog.Filter = "All files (*.*)|*.*|data file *.dat|*.dat";
						saveDialog.FilterIndex = 2;
						saveDialog.ShowDialog();
						UserFileName = saveDialog.FileName;
						unsaved = false;
						this.Text = "Polygons";
					}
				}
				BinaryFormatter binFormat = new BinaryFormatter();
				FileStream stream = new FileStream(UserFileName, FileMode.Create, FileAccess.Write);
				binFormat.Serialize(stream, figures);
				stream.Close();
			}
			catch (InvalidOperationException)
			{
				Log(DateTime.Now.ToString() + ": Save error(InvalidOperationException)");
				MessageBox.Show("FATAL ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Error: name must be set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void fileLoad()
		{
			try
			{
				BinaryFormatter binFormat = new BinaryFormatter();
				OpenFileDialog openDialog = new OpenFileDialog();
				openDialog.Filter = "All files (*.*)|*.*|data file *.dat|*.dat";
				openDialog.FilterIndex = 2;
				openDialog.ShowDialog();
				unsaved = false;
				UserFileName = openDialog.FileName;
				FileStream stream = new FileStream(UserFileName, FileMode.Open, FileAccess.Read);
				figures = (List<Shape>)binFormat.Deserialize(stream);
				
				Refresh();
				stream.Close();
			}
			catch (InvalidOperationException)
			{
				Log(DateTime.Now.ToString() + ": Load error(InvalidOperationException)");
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Файл должен быть выбран\nПовторите операцию");
				Log(DateTime.Now.ToString() + ": Load error(ArgumentException)");
			}
		}
		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			fileNew();
		}
		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			fileSave();
		}
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			fileSaveAS();
		}
		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			fileLoad();
		}
		private void radiusToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (set_r == null || set_r.IsDisposed)
			{
				set_r = new Form2();
				set_r.RadMem(RadMem);
				set_r.Show();

			}
			else { set_r.Activate(); set_r.WindowState = FormWindowState.Normal; }
			set_r.RC += Set_r_RC;
		}
		private void Set_r_RC(object sender, RadiusEventArgs e)
		{
			Shape.R = e.Radius;
			RadMem = e.Radius;
			Refresh();
			unsaved = true;
		}
		private void insideToolStripMenuItem_Click(object sender, EventArgs e)
		{
			colorDialog1.ShowDialog();
			Shape.COL = colorDialog1.Color;
			Refresh();
			unsaved = true;
		}
		private void outsideToolStripMenuItem_Click(object sender, EventArgs e)
		{
			colorDialog1.ShowDialog();
			Shape.PEN = colorDialog1.Color;
			Refresh();
			unsaved = true;
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
		private double Cosinus(int x1, int y1, int x2, int y2, int x3, int y3)
		{
			return ((x2 - x1) * (x3 - x1) + (y2 - y1) * (y3 - y1)) /
			(Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)) *
			Math.Sqrt((x3 - x1) * (x3 - x1) + (y3 - y1) * (y3 - y1)));

		}
		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			Graphics gr = e.Graphics;
			gr.SmoothingMode = SmoothingMode.HighQuality;
			foreach (Shape p1 in figures)
			{
				p1.Draw(e.Graphics);
			}
			#region ConvexHull_ByDefenition
			if (byDefenitionToolStripMenuItem.Checked)
			{
				//timer.Reset();
				//timer.Start();
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
				//timer.Stop();
				//ts = timer.Elapsed;
				//Log("DEFENITON FOR " + figures.Count + " OBJ " + +(float)ts.TotalMilliseconds);
				//timer.Reset();
			}
			#endregion
			#region ConvexHull_ByJarvis
			if (byJarvisToolStripMenuItem.Checked)
			{
				//timer.Start();
				if (figures.Count >= 3)
				{
					figures = ConvexHull_Main(figures);
					e.Graphics.DrawLine(new Pen(Color.Black), figures[0].X, figures[0].Y, figures[figures.Count - 1].X, figures[figures.Count - 1].Y);
					for (int i = 0; i < figures.Count - 1; i++)
					{
						e.Graphics.DrawLine(new Pen(Color.Black), figures[i].X, figures[i].Y, figures[i + 1].X, figures[i + 1].Y);
					}
				}
				//timer.Stop();
				//ts = timer.Elapsed;
				//Log("Jarvis FOR " + figures.Count + " OBJ " + (float)ts.TotalMilliseconds);
				//timer.Reset();
			}
			#endregion
		}
		private void byDefenitionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			byJarvisToolStripMenuItem.Checked = false;
			Refresh();
		}
		private void byJarvisToolStripMenuItem_Click(object sender, EventArgs e)
		{
			byDefenitionToolStripMenuItem.Checked = false;
			if (figures.Count >= 3)
			{
				figures = ConvexHull_Main(figures);
				Refresh();
			}
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
		#region UNDO_REDO
		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
		{

			if (figures.Count < 1)
				return;
			
			F_Redo.Push(figures);
			MessageBox.Show("Redo " + F_Redo.Count.ToString());
			figures.RemoveAt(figures.Count - 1);
			figures = F_Undo.Pop();
			MessageBox.Show("Undo " + F_Undo.Count.ToString());
			Refresh();
		}
		private void redoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (figures.Count < 1)
				return;
			MessageBox.Show("Redo " + F_Redo.Count.ToString());
			figures = F_Redo.Pop();
			MessageBox.Show("Fig " + figures.Count.ToString());
			Refresh();
		}
		#endregion
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (unsaved)
			{
				DialogResult dialoresult = MessageBox.Show("You've got unsaved changes\nWould you like to save them?", "INFO", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
				switch (dialoresult)
				{
					case DialogResult.Yes:
						saveAsToolStripMenuItem_Click(null, null);
						break;
					case DialogResult.No:
						break;
					case DialogResult.Cancel: e.Cancel = (dialoresult == DialogResult.Cancel); break;
				}
			}
		}
		private void playToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (int.Parse(textBox1.Text) <= 0) throw new IndexOutOfRangeException();
				timer1.Interval = int.Parse(textBox1.Text);
				timer1.Enabled = true;
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
		private void stopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			timer1.Enabled = false;
		}
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.S)
			{
				fileSave();
			}
			else if(e.Control && e.KeyCode == Keys.O)
			{
				fileLoad();
			}
			else if(e.Control && e.KeyCode == Keys.N)
			{
				fileNew();
			}
			else if (e.Control && e.KeyCode == Keys.Z)
			{
				undoToolStripMenuItem_Click(null, null);
			}
			else if (e.Control && e.KeyCode == Keys.Back && e.KeyCode == Keys.Shift)
			{
				redoToolStripMenuItem_Click(null, null);
			}
			else if (e.Control && e.KeyCode == Keys.J)
			{
				byJarvisToolStripMenuItem.Checked = true;
				byDefenitionToolStripMenuItem.Checked = false;
			}
			else if (e.Control && e.KeyCode == Keys.D)
			{
				byJarvisToolStripMenuItem.Checked = false;
				byDefenitionToolStripMenuItem.Checked = true;
			}
			else if (e.Control && e.KeyCode == Keys.F2)
			{
				radiusToolStripMenuItem_Click(null, null);
			}
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (byJarvisToolStripMenuItem.Checked)
				if (figures.Count >= 3)
				{
					figures = ConvexHull_Main(figures);
				}
			foreach (Shape p in figures)
			{
				p.X = p.X + rnd.Next(-1, 2);
				p.Y = p.Y + rnd.Next(-1, 2);
			}
			Refresh();
		}
	}
}