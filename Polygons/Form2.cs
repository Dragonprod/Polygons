using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygons
{
    
    public partial class Form2 : Form
    {
        struct Colors
        {
            Color col;
            string name;
            public Colors(Color col, string name)
            {
                this.col = col;
                this.name = name;
            }
            public Color COl
            {
                get { return col; }
            }
            public string NAME
            {
                get { return name; }
            }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Colors[] color =
            {
                new Colors(Color.Red, "Red"),
                new Colors(Color.Green, "Green"),
                new Colors(Color.Blue, "Blue"),
                new Colors(Color.White, "White"),
                new Colors(Color.Black, "Black"),
                new Colors(Color.Yellow, "Yellow"),
                new Colors(Color.Orange, "Orange")
            };
            Colors[] color1 =
            {
                new Colors(Color.Red, "Red"),
                new Colors(Color.Green, "Green"),
                new Colors(Color.Blue, "Blue"),
                new Colors(Color.White, "White"),
                new Colors(Color.Black, "Black"),
                new Colors(Color.Yellow, "Yellow"),
                new Colors(Color.Orange, "Orange")
            };
            comboBox1.DataSource = color;
            comboBox1.DisplayMember = "NAME";
            comboBox1.ValueMember = "COL";
            comboBox2.DataSource = color1;
            comboBox2.DisplayMember = "NAME";
            comboBox2.ValueMember = "COL";
        }
        public string SET_COLOR_INSIDE()
        {
            return comboBox1.Text;
        }
        public string SET_COLOR_OUTSIDE()
        {
            return comboBox2.Text;
        }
    }
}
