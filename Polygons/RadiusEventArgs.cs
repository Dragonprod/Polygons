using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygons
{
	public delegate void RadiusEventHandler(object sender, RadiusEventArgs e);
	public class RadiusEventArgs:EventArgs
	{
		int radius;
		public int Radius
		{
			get { return radius; }
			set { radius = value; }
		}
		public RadiusEventArgs(int radius)
		{
			this.radius = radius;
		}
	}
}
