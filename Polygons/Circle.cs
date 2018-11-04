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
using System.Xml.Serialization;
namespace Polygons
{
    [Serializable]
    public class Circle : Shape
    {
        public Circle(int x, int y) : base(x, y)
        {

        }
        public override void Draw(Graphics gr)
        {
            gr.FillEllipse(new SolidBrush(col), x - radius, y - radius, 2 * radius, 2 * radius);
            gr.DrawEllipse(new Pen(pen, 3), x - radius, y - radius, 2 * radius, 2 * radius);
        }
        public override bool IsInside(int mouse_x, int mouse_y)
        {
            if (((mouse_x - x) * (mouse_x - x) + (mouse_y - y) * (mouse_y - y) <= radius * radius))
                return true;
            else return false;
        }
    }
}
