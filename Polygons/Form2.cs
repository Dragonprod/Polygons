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
		}
		public event RadiusEventHandler RC;

		public void RadMem(int Rm)
		{
			trackBar1.Value = Rm;
		}
		private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
			if (RC != null)
				RC(this, new RadiusEventArgs(trackBar1.Value));
		}

    }
}
