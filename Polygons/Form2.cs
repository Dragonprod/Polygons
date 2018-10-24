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
        public Form2()
        {
            InitializeComponent();
            trackBar1.ValueChanged += trackBar1_ValueChanged;
        }
        public int Radius
        {
            get { return trackBar1.Value; }
            protected set
            {
                if (value == trackBar1.Value)
                {
                    return;
                }
                trackBar1.Value = value;
                OnRadiusChanged();
            }
        }
        public event EventHandler RadiusChanged;
        protected void OnRadiusChanged()
        {
            RadiusChanged?.Invoke(this, EventArgs.Empty);
        }
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            OnRadiusChanged();
        }

    }
}
