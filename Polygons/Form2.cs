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
        Shape shape;
        public Form2()
        {
            InitializeComponent();
        }

        public void Show1(Shape shape)
        {
            this.shape = shape;
            shape.Changed += Shape_Changed;
        }

        private void Shape_Changed(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            shape.Changed -= Shape_Changed;
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            shape.RADIUS = (sender as TrackBar).Value;
        }

    }
}
